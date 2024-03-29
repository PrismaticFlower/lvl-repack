
#include "memory_mapped_file.hpp"
#include "smart_win32_handle.hpp"

#include <Windows.h>

import std;

namespace re::win32 {

memory_mapped_file::memory_mapped_file(const std::filesystem::path& path, const mode mode)
{
   if (!std::filesystem::exists(path) || std::filesystem::is_directory(path)) {
      throw std::runtime_error{"File does not exist."};
   }

   const auto file_size = std::filesystem::file_size(path);

   if (file_size > std::numeric_limits<std::uint32_t>::max()) {
      throw std::runtime_error{"File too large."};
   }

   _size = static_cast<std::uint32_t>(file_size);

   const auto desired_access =
      mode == mode::read ? GENERIC_READ : GENERIC_READ | GENERIC_WRITE;

   const auto file = unique_handle{
      CreateFileW(path.wstring().c_str(), desired_access, FILE_SHARE_READ,
                  nullptr, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, nullptr)};

   if (file.get() == INVALID_HANDLE_VALUE) {
      throw std::invalid_argument{"Unable to open file."};
   }

   const auto page_access = mode == mode::read ? PAGE_READONLY : PAGE_READWRITE;

   const auto file_mapping = unique_handle{
      CreateFileMappingW(file.get(), nullptr, page_access, 0, 0, nullptr)};

   if (file_mapping == nullptr) {
      throw std::runtime_error{"Unable to create file mapping."};
   }

   const auto file_map_desired_access =
      mode == mode::read ? FILE_MAP_READ : FILE_MAP_READ | FILE_MAP_WRITE;

   _view = {static_cast<std::byte*>(
               MapViewOfFile(file_mapping.get(), file_map_desired_access, 0, 0, 0)),
            &unmap};

   if (_view == nullptr) {
      throw std::runtime_error{"Unable to create view of file mapping."};
   }
}

auto memory_mapped_file::bytes() noexcept -> std::span<std::byte>
{
   return std::span{_view.get(), _size};
}

auto memory_mapped_file::bytes() const noexcept -> std::span<const std::byte>
{
   return std::span{_view.get(), _size};
}

void memory_mapped_file::unmap(std::byte* mapping) noexcept
{
   if (mapping) UnmapViewOfFile(mapping);
}

}
