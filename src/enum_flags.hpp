#pragma once

import std;

namespace re {

template<typename Type>
constexpr bool marked_as_enum_flag(Type&&) noexcept
{
   return false;
}

template<typename Enum>
struct is_enum_flag : std::bool_constant<marked_as_enum_flag(Enum{})> {};

template<typename Enum>
constexpr bool is_enum_flag_v = is_enum_flag<Enum>::value;

template<typename Enum, typename = std::enable_if_t<is_enum_flag_v<Enum>>>
constexpr Enum operator|(const Enum l, const Enum r) noexcept
{
   return static_cast<Enum>(static_cast<std::underlying_type_t<Enum>>(l) |
                            static_cast<std::underlying_type_t<Enum>>(r));
}

template<typename Enum, typename = std::enable_if_t<is_enum_flag_v<Enum>>>
constexpr Enum operator&(Enum l, Enum r) noexcept
{
   return static_cast<Enum>(static_cast<std::underlying_type_t<Enum>>(l) &
                            static_cast<std::underlying_type_t<Enum>>(r));
}

template<typename Enum, typename = std::enable_if_t<is_enum_flag_v<Enum>>>
constexpr Enum operator^(const Enum l, const Enum r) noexcept
{
   return static_cast<Enum>(static_cast<std::underlying_type_t<Enum>>(l) ^
                            static_cast<std::underlying_type_t<Enum>>(r));
}

template<typename Enum, typename = std::enable_if_t<is_enum_flag_v<Enum>>>
constexpr Enum operator~(const Enum f) noexcept
{
   return static_cast<Enum>(~static_cast<std::underlying_type_t<Enum>>(f));
}

template<typename Enum, typename = std::enable_if_t<is_enum_flag_v<Enum>>>
constexpr Enum operator>>(const Enum l, const Enum r) noexcept
{
   return static_cast<Enum>(static_cast<std::underlying_type_t<Enum>>(l) >>
                            static_cast<std::underlying_type_t<Enum>>(r));
}

template<typename Enum, typename = std::enable_if_t<is_enum_flag_v<Enum>>>
constexpr Enum& operator|=(Enum& l, const Enum r) noexcept
{
   return l = l | r;
}

template<typename Enum, typename = std::enable_if_t<is_enum_flag_v<Enum>>>
constexpr Enum& operator&=(Enum& l, const Enum r) noexcept
{
   return l = l & r;
}

template<typename Enum, typename = std::enable_if_t<is_enum_flag_v<Enum>>>
constexpr Enum& operator^=(Enum& l, const Enum r) noexcept
{
   return l = l ^ r;
}

template<typename Enum>
constexpr bool flags_set(const Enum value, const Enum flag)
{
   return (value & flag) == flag;
}

template<typename Enum>
constexpr bool any_flag_set(const Enum value, const Enum flag)
{
   return (value & flag) != Enum{};
}

}
