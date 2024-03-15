#pragma once

#include "ucfb_editor.hpp"

namespace re {

void repack_texture(std::variant<ucfb::editor_data_chunk, ucfb::editor_parent_chunk>& tex,
                    const bool prefer_compressed);

}
