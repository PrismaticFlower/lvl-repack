#pragma once

import std;

namespace re {

inline auto pack_unorm8(const float v, const std::uint32_t shift) noexcept -> std::uint32_t
{
   return (static_cast<std::uint32_t>(std::clamp(v, 0.0f, 1.0f) * 255.f + 0.5f) & 0xff)
          << shift;
}

inline auto pack_unorm8(const std::uint8_t v, const std::uint32_t shift) noexcept
   -> std::uint32_t
{
   return v << shift;
}

template<typename R, typename G, typename B, typename A>
inline auto pack_bgra_unorm32(const R r, const G g, const B b, const A a) noexcept
   -> std::uint32_t
{
   std::uint32_t packed = 0;

   packed |= pack_unorm8(r, 16);
   packed |= pack_unorm8(g, 8);
   packed |= pack_unorm8(b, 0);
   packed |= pack_unorm8(a, 24);

   return packed;
}

template<typename R, typename G, typename B>
inline auto pack_bgra_unorm32(const R r, const G g, const B b) noexcept -> std::uint32_t
{
   return pack_bgra_unorm32(r, g, b, std::uint8_t{});
}

template<typename R, typename G>
inline auto pack_bgra_unorm32(const R r, const G g) noexcept -> std::uint32_t
{
   return pack_bgra_unorm32(r, g, std::uint8_t{}, std::uint8_t{});
}

}