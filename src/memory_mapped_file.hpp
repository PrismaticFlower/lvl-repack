#pragma once

import std;

namespace re::win32 {

class memory_mapped_file {
public:
   enum class mode { read, read_write };

   memory_mapped_file() = default;

   memory_mapped_file(const std::filesystem::path& path, const mode mode = mode::read);

   memory_mapped_file(const memory_mapped_file&) = delete;
   memory_mapped_file& operator=(const memory_mapped_file&) = delete;

   memory_mapped_file(memory_mapped_file&&) = default;
   memory_mapped_file& operator=(memory_mapped_file&&) = default;

   ~memory_mapped_file() = default;

   auto bytes() noexcept -> std::span<std::byte>;

   auto bytes() const noexcept -> std::span<const std::byte>;

private:
   static void unmap(std::byte* mapping) noexcept;

   std::unique_ptr<std::byte, decltype(&unmap)> _view{nullptr, &unmap};
   std::uint32_t _size = 0;
};

}
