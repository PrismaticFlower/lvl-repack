#pragma once

import std;

#include <Windows.h>

namespace re::win32 {

struct handle_deleter {
   void operator()(HANDLE handle) noexcept
   {
      if (handle == INVALID_HANDLE_VALUE || handle == nullptr) return;

      CloseHandle(handle);
   }
};

using unique_handle = std::unique_ptr<void, handle_deleter>;

inline auto duplicate_handle(const unique_handle& other) noexcept -> unique_handle
{
   if (other.get() == INVALID_HANDLE_VALUE || other.get() == nullptr)
      return unique_handle{INVALID_HANDLE_VALUE};

   HANDLE duplicated;

   if (!DuplicateHandle(GetCurrentProcess(), other.get(), GetCurrentProcess(),
                        &duplicated, DUPLICATE_SAME_ACCESS, true, 0x0))
      std::terminate();

   return unique_handle{duplicated};
}

}
