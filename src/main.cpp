
#include "memory_mapped_file.hpp"
#include "repack_texture.hpp"
#include "ucfb_editor.hpp"
#include "ucfb_writer.hpp"

import std;

using namespace std::literals;

namespace re {

namespace {

constexpr auto is_parent_chunk(const magic_number mn) noexcept
{
#if 0
   switch (mn) {
   case "modl"_mn:
   case "segm"_mn:
      return true;
   case "tern"_mn:
   case "PCHS"_mn:
   case "PTCH"_mn:
      return true;
   default:
      return false;
   };
#else
   return false;
#endif
}

void convert(ucfb::editor_parent_chunk& editor, const bool prefer_compressed_textures);

void convert_child_lvl(std::variant<ucfb::editor_data_chunk, ucfb::editor_parent_chunk>& editor,
                       const bool prefer_compressed_textures)
{
   auto [child_name, child_editor] = [&] {
      auto& data_editor = std::get<ucfb::editor_data_chunk>(editor);

      magic_number child_name{};
      std::memcpy(&child_name, data_editor.data(), sizeof(child_name));

      return std::pair{child_name,
                       ucfb::editor_parent_chunk{ucfb::reader{
                                                    std::span{data_editor.data(),
                                                              data_editor.size()}},
                                                 is_parent_chunk}};
   }();

   convert(child_editor, prefer_compressed_textures);

   ucfb::editor_parent_chunk lvl;

   lvl.emplace_back(child_name, std::move(child_editor));

   editor = std::move(lvl);
}

void convert(ucfb::editor_parent_chunk& editor, const bool prefer_compressed_textures)
{
   for (auto& [mn, child] : editor) {
      if (mn == "modl"_mn) {
         // convert_model(std::get<ucfb::Editor_parent_chunk>(child));
      }
      else if (mn == "tex_"_mn) {
         repack_texture(child, prefer_compressed_textures);
      }
      else if (mn == "tern"_mn) {
         // convert_terrain(std::get<ucfb::Editor_parent_chunk>(child));
      }
      else if (mn == "lvl_"_mn) {
         convert_child_lvl(child, prefer_compressed_textures);
      }
   }
}

void run(std::string path, const bool prefer_compressed_textures)
{
   ucfb::Editor editor{ucfb::reader_strict<"ucfb"_mn>{
                          win32::memory_mapped_file{path}.bytes()},
                       is_parent_chunk};

   convert(editor, prefer_compressed_textures);

   std::ofstream out_file{path, std::ios::binary};

   ucfb::writer output{out_file};

   editor.assemble(output);
}

}

}

int main(int arg_count, char* args[])
{
   if (arg_count < 2) {
      std::println("Usage: ./swbf-repack <file> "
                   "[prefer_compessed_textures]");

      return 1;
   }

   try {
      const bool prefer_compressed_textures =
         arg_count >= 3 ? args[2] == "prefer_compessed_textures"sv : false;

      re::run(args[1], prefer_compressed_textures);

      std::println("Successfully repacked {}\n", args[1]);
   }
   catch (std::exception& e) {
      std::println(std::cerr,
                   "Exception occurred while repacking file. Cryptic message "
                   "is as follows: {}\n",
                   e.what());

      return 1;
   }

   return 0;
}
