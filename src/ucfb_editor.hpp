#pragma once

#include "magic_number.hpp"
#include "ucfb_reader.hpp"
#include "ucfb_tweaker.hpp"

import std;

namespace re::ucfb {

class writer;
class editor_data_chunk;

class editor_data_writer {
public:
   enum class Alignment : bool { unaligned, aligned };

   editor_data_writer(editor_data_chunk& data_chunk) noexcept;

   editor_data_writer() = default;
   editor_data_writer(const editor_data_writer&) = delete;
   editor_data_writer& operator=(const editor_data_writer&) = delete;
   editor_data_writer(editor_data_writer&&) = delete;
   editor_data_writer& operator=(editor_data_writer&&) = delete;

   void write(const std::span<const std::byte> bytes,
              Alignment alignment = Alignment::aligned);

   template<typename Type>
   void write(const Type& value, Alignment alignment = Alignment::aligned)
   {
      static_assert(std::is_standard_layout_v<Type>,
                    "Type must be standard layout!");
      static_assert(std::is_trivially_destructible_v<Type>,
                    "Type must be trivially destructible!");

      const auto bytes =
         std::span{reinterpret_cast<const std::byte*>(&value), sizeof(Type)};

      write(bytes, alignment);
   }

   template<typename Type>
   void write(const std::span<Type> span, Alignment alignment = Alignment::aligned)
   {
      static_assert(std::is_standard_layout_v<Type>,
                    "Type must be standard layout!");
      static_assert(std::is_trivially_destructible_v<Type>,
                    "Type must be trivially destructible!");

      const auto bytes = std::as_bytes(span);

      write(bytes, alignment);
   }

   void write(const std::string_view string, Alignment alignment = Alignment::aligned);

   void write(const std::string& string, Alignment alignment = Alignment::aligned);

   template<typename... Args>
   auto write(Args&&... args)
      -> std::enable_if_t<!std::disjunction_v<std::is_same<Alignment, Args>...>>
   {
      (this->write(args, Alignment::aligned), ...);
   }

   template<typename... Args>
   auto write_unaligned(Args&&... args)
      -> std::enable_if_t<!std::disjunction_v<std::is_same<Alignment, Args>...>>
   {
      (this->write(args, Alignment::unaligned), ...);
   }

private:
   void align() noexcept;

   editor_data_chunk& _data;
};

class editor_data_chunk : std::vector<std::byte> {
public:
   editor_data_chunk() = default;

   explicit editor_data_chunk(reader reader) noexcept
   {
      const auto init = reader.read_array<std::byte>(reader.size());

      assign(init.cbegin(), init.cend());
   }

   explicit editor_data_chunk(const editor_data_chunk&) = default;
   editor_data_chunk& operator=(const editor_data_chunk&) = delete;

   editor_data_chunk(editor_data_chunk&&) = default;
   editor_data_chunk& operator=(editor_data_chunk&&) = default;

   using value_type = std::byte;
   using size_type = std::uint32_t;
   using difference_type = std::int32_t;
   using reference = value_type&;
   using const_reference = const reference;
   using pointer = value_type*;
   using const_pointer = const value_type*;
   using iterator = std::vector<value_type>::iterator;
   using const_iterator = std::vector<value_type>::const_iterator;
   using reverse_iterator = std::vector<value_type>::reverse_iterator;
   using const_reverse_iterator = std::vector<value_type>::const_reverse_iterator;

   using std::vector<value_type>::begin;
   using std::vector<value_type>::end;
   using std::vector<value_type>::cbegin;
   using std::vector<value_type>::cend;
   using std::vector<value_type>::rbegin;
   using std::vector<value_type>::rend;

   using std::vector<value_type>::at;
   using std::vector<value_type>::operator[];
   using std::vector<value_type>::front;
   using std::vector<value_type>::back;
   using std::vector<value_type>::data;

   using std::vector<value_type>::empty;
   using std::vector<value_type>::size;
   using std::vector<value_type>::max_size;
   using std::vector<value_type>::reserve;
   using std::vector<value_type>::capacity;
   using std::vector<value_type>::shrink_to_fit;

   using std::vector<value_type>::clear;
   using std::vector<value_type>::insert;
   using std::vector<value_type>::emplace;
   using std::vector<value_type>::erase;
   using std::vector<value_type>::push_back;
   using std::vector<value_type>::emplace_back;
   using std::vector<value_type>::pop_back;

   auto writer() noexcept -> editor_data_writer
   {
      return *this;
   }

   auto span() noexcept -> std::span<value_type>
   {
      return std::span{data(), size()};
   }

   auto span() const noexcept -> std::span<const value_type>
   {
      return std::span{data(), size()};
   }
};

class editor_parent_chunk
   : std::vector<std::pair<magic_number, std::variant<editor_data_chunk, editor_parent_chunk>>> {
public:
   editor_parent_chunk() = default;

   template<typename Filter>
   editor_parent_chunk(reader reader, Filter is_parent_chunk) noexcept
   {
      static_assert(std::is_nothrow_invocable_r_v<bool, Filter, magic_number>, "is_parent_filter must be nothrow invocable, take a Magic_number of a chunk and return true or false depending on if the chunk is a parent or not.");

      while (reader) {
         const auto child = reader.read_child();

         if (is_parent_chunk(child.mn())) {
            emplace_back(child.mn(), editor_parent_chunk{child, is_parent_chunk});
         }
         else {
            emplace_back(child.mn(), editor_data_chunk{child});
         }
      }
   }

   explicit editor_parent_chunk(const editor_parent_chunk&) = default;
   editor_parent_chunk& operator=(const editor_parent_chunk&) = delete;

   editor_parent_chunk(editor_parent_chunk&&) = default;
   editor_parent_chunk& operator=(editor_parent_chunk&&) = default;

   using value_type =
      std::pair<magic_number, std::variant<editor_data_chunk, editor_parent_chunk>>;
   using size_type = std::uint32_t;
   using difference_type = std::int32_t;
   using reference = value_type&;
   using const_reference = const reference;
   using pointer = value_type*;
   using const_pointer = const value_type*;
   using iterator = std::vector<value_type>::iterator;
   using const_iterator = std::vector<value_type>::const_iterator;
   using reverse_iterator = std::vector<value_type>::reverse_iterator;
   using const_reverse_iterator = std::vector<value_type>::const_reverse_iterator;

   using std::vector<value_type>::begin;
   using std::vector<value_type>::end;
   using std::vector<value_type>::cbegin;
   using std::vector<value_type>::cend;
   using std::vector<value_type>::rbegin;
   using std::vector<value_type>::rend;

   using std::vector<value_type>::at;
   using std::vector<value_type>::operator[];
   using std::vector<value_type>::front;
   using std::vector<value_type>::back;

   using std::vector<value_type>::empty;
   using std::vector<value_type>::size;
   using std::vector<value_type>::max_size;
   using std::vector<value_type>::reserve;
   using std::vector<value_type>::capacity;
   using std::vector<value_type>::shrink_to_fit;

   using std::vector<value_type>::clear;
   using std::vector<value_type>::insert;
   using std::vector<value_type>::emplace;
   using std::vector<value_type>::erase;
   using std::vector<value_type>::push_back;
   using std::vector<value_type>::emplace_back;
   using std::vector<value_type>::pop_back;

   auto emplace_parent_chunk_back(const magic_number mn) -> editor_parent_chunk&
   {
      return std::get<editor_parent_chunk>(
         emplace_back(mn, editor_parent_chunk{}).second);
   }

   auto emplace_data_chunk_back(const magic_number mn) -> editor_data_chunk&
   {
      return std::get<editor_data_chunk>(emplace_back(mn, editor_data_chunk{}).second);
   }
};

class Editor : public editor_parent_chunk {
public:
   Editor() noexcept = default;

   template<typename Filter>
   Editor(reader_strict<"ucfb"_mn> reader, Filter&& is_parent_chunk) noexcept
      : editor_parent_chunk{reader, std::forward<Filter>(is_parent_chunk)}
   {
   }

   void assemble(writer& output) const noexcept;
};

inline auto make_reader(editor_parent_chunk::const_iterator it) noexcept -> ucfb::reader
{
   return ucfb::reader{it->first, std::get<editor_data_chunk>(it->second).span()};
}

template<magic_number mn>
inline auto make_strict_reader(editor_parent_chunk::const_iterator it) noexcept
   -> ucfb::reader_strict<mn>
{
   return ucfb::reader_strict<mn>{
      ucfb::reader{it->first, std::get<editor_data_chunk>(it->second).span()}};
}

template<magic_number mn>
inline auto make_strict_reader(editor_data_chunk& chunk) noexcept
   -> ucfb::reader_strict<mn>
{
   return ucfb::reader_strict<mn>{ucfb::reader{mn, chunk.span()}};
}

template<typename It_first, typename It_last>
inline auto find(It_first first, It_last last, const magic_number mn) noexcept -> It_first
{
   return std::find_if(first, last, [mn](const auto& v) { return v.first == mn; });
}

template<typename Editor>
inline auto find(Editor& editor, const magic_number mn) noexcept
{
   return std::find_if(editor.begin(), editor.end(),
                       [mn](const auto& v) { return v.first == mn; });
}

template<typename Editor>
inline auto find_all(Editor& editor, const magic_number mn) noexcept
{
   std::vector<decltype(editor.begin())> results;
   results.reserve(16);

   for (auto it = find(editor, mn); it != editor.end();
        it = ucfb::find(it + 1, editor.end(), mn)) {
      results.emplace_back(it);
   }

   return results;
}

}
