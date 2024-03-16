#include "repack_texture.hpp"

#include <d3d9.h>

import std;

namespace re {

namespace {

enum class texture_type : std::uint32_t { _2d = 1, cubemap = 2, _3d = 3 };

using texture_level = std::vector<std::byte>;
using texture_face = std::vector<texture_level>;

struct texture {
   std::string name;

   D3DFORMAT format = D3DFMT_UNKNOWN;
   std::uint16_t width = 0;
   std::uint16_t height = 0;
   std::uint16_t depth = 0;
   std::uint16_t mip_count = 0;
   texture_type type = texture_type::_2d;
   std::uint32_t detail_bias = 0;

   std::vector<texture_face> faces;
};

auto pick_format(std::span<const D3DFORMAT> formats, const bool prefer_compressed)
   -> D3DFORMAT
{
   if (std::ranges::contains(formats, D3DFMT_L8)) return D3DFMT_L8;
   if (std::ranges::contains(formats, D3DFMT_A8L8)) return D3DFMT_A8L8;

   if (prefer_compressed) {
      if (std::ranges::contains(formats, D3DFMT_DXT3)) return D3DFMT_DXT3;
      if (std::ranges::contains(formats, D3DFMT_DXT1)) return D3DFMT_DXT1;
   }

   if (std::ranges::contains(formats, D3DFMT_A8R8G8B8)) return D3DFMT_A8R8G8B8;
   if (std::ranges::contains(formats, D3DFMT_X8R8G8B8)) return D3DFMT_X8R8G8B8;
   if (std::ranges::contains(formats, D3DFMT_A8B8G8R8)) return D3DFMT_A8B8G8R8;
   if (std::ranges::contains(formats, D3DFMT_X8B8G8R8)) return D3DFMT_X8B8G8R8;
   if (std::ranges::contains(formats, D3DFMT_DXT3)) return D3DFMT_DXT3;
   if (std::ranges::contains(formats, D3DFMT_DXT1)) return D3DFMT_DXT1;

   return formats.empty() ? D3DFMT_UNKNOWN : formats[0];
}

auto read_texture(ucfb::reader_strict<"tex_"_mn> tex, const bool prefer_compressed)
   -> std::optional<texture>
{
   texture out;

   out.name = tex.read_child_strict<"NAME"_mn>().read_string();

   D3DFORMAT picked_format = D3DFMT_UNKNOWN;

   {
      auto info = tex.read_child_strict<"INFO"_mn>();

      const std::uint32_t format_count = info.read<std::uint32_t>();

      picked_format =
         pick_format(info.read_array<D3DFORMAT>(format_count), prefer_compressed);
   }

   if (picked_format == D3DFMT_UNKNOWN) {
      std::print("Skipping texture {}\n", out.name);

      return std::nullopt;
   }

   while (tex) {
      auto child = tex.read_child();

      if (child.mn() != "FMT_"_mn) continue;
      const auto [format, width, height, depth, mip_count, packed_bias_type] =
         child.read_child_strict<"INFO"_mn>()
            .read_multi_unaligned<D3DFORMAT, std::uint16_t, std::uint16_t,
                                  std::uint16_t, std::uint16_t, std::uint32_t>();

      const texture_type type{packed_bias_type & 0xffu};
      const std::uint32_t detail_bias = packed_bias_type >> 8u;

      if (format != picked_format) continue;

      out.format = format;
      out.width = width;
      out.height = height;
      out.depth = depth;
      out.mip_count = mip_count;
      out.type = type;
      out.detail_bias = detail_bias;

      const std::size_t face_count = type == texture_type::cubemap ? 6 : 1;

      for (std::size_t face_index = 0; face_index < face_count; ++face_index) {
         auto face = child.read_child_strict<"FACE"_mn>();

         auto& face_out = out.faces.emplace_back();

         for (std::size_t mip = 0; mip < mip_count; ++mip) {
            auto lvl = face.read_child_strict<"LVL_"_mn>();

            const auto [mip_level, body_size] =
               lvl.read_child_strict<"INFO"_mn>()
                  .read_multi_unaligned<std::uint32_t, std::uint32_t>();

            if (mip_level != mip) {
               std::print("Skipping texture {}\n", out.name);

               return std::nullopt;
            }

            face_out.emplace_back().append_range(
               lvl.read_child_strict<"BODY"_mn>().read_array_unaligned<std::byte>(
                  body_size));
         }
      }
   }

   return out;
}

void pack_texture(const texture& tex, ucfb::editor_parent_chunk& out)
{
   out.emplace_data_chunk_back("NAME"_mn).writer().write(tex.name);

   {
      auto info = out.emplace_data_chunk_back("INFO"_mn).writer();

      info.write(std::uint32_t{1}, static_cast<std::uint32_t>(tex.format));
   }

   auto& fmt = out.emplace_parent_chunk_back("FMT_"_mn);

   {
      auto info = fmt.emplace_data_chunk_back("INFO"_mn).writer();

      info.write(tex.format);
      info.write_unaligned(tex.width, tex.height, tex.depth, tex.mip_count);
      info.write(static_cast<std::uint32_t>(tex.type) | (tex.detail_bias << 8u));
   }

   for (auto item = 0u; item < tex.faces.size(); ++item) {
      auto& face = fmt.emplace_parent_chunk_back("FACE"_mn);

      for (auto mip = 0u; mip < tex.faces[item].size(); ++mip) {
         auto& lvl = face.emplace_parent_chunk_back("LVL_"_mn);

         {
            auto info = lvl.emplace_data_chunk_back("INFO"_mn).writer();

            info.write(std::uint32_t{mip});
            info.write(static_cast<std::uint32_t>(tex.faces[item][mip].size()));
         }

         {
            auto body = lvl.emplace_data_chunk_back("BODY"_mn).writer();

            body.write_unaligned(std::span<const std::byte>{tex.faces[item][mip]});
         }
      }
   }
}

}

void repack_texture(std::variant<ucfb::editor_data_chunk, ucfb::editor_parent_chunk>& tex,
                    const bool prefer_compressed)
{
   std::optional<texture> texture =
      read_texture(ucfb::make_strict_reader<"tex_"_mn>(
                      std::get<ucfb::editor_data_chunk>(tex)),
                   prefer_compressed);

   if (not texture) return;
   if (texture->type == texture_type::_3d) return;

   tex = ucfb::editor_parent_chunk{};

   pack_texture(*texture, std::get<ucfb::editor_parent_chunk>(tex));
}

}