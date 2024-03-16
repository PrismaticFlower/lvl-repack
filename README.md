A tool for repacking .lvl files from SWBF (2004) and SWBF2 (2005) to decrease their size. Potentially to over half their original size.

### How it Works

First a quick overview of the structure of the game's PC textures

- `tex_`
  - `NAME` name of the texture
  - `INFO` list of format variants
  - `FMT_` a format variant of the texture
    - `INFO` format, resolution, mip count, type, detail bias
    - `FACE` a texture face (only cubemaps have multiple faces)
      - `LVL_` a mip level
        - `INFO` mip index, `BODY` size
        - `BODY` texture data
      - `LVL_` *repeats for each mip*
    - `FACE` *repeats for each texture face*
  - `FMT_` *repeats for each format variant*

There are two things to note here the first is

>  - `INFO` list of format variants

and the second

> - `FMT_` *repeats for each format variant*

Each texture can effectively have multiple copies of itself, each in a different format. Back in the day the game used this (presumably) pick the most suitable format at runtime based on the user's GPU and possibly other things.

Not every texture has multiple formats but when one does it usually (but not always) has 3, a BC1/BC2 compressed copy, a 16-bit copy and a 32-bit copy. These days though the game will by default almost always pick the compressed one to use. That leaves a total of 6 bytes per-pixel of wasted data being stored.

And that is what this tool does. It edits the `tex_` chunks in the .lvls and removes all but one format. By default it leaves the 32-bit format (if present) but it can be told to prefer leaving the compressed formats, further saving space.

Luminance formats like `D3DFMT_L8` and `D3DFMT_A8L8` are always preferred if present.

### Results

Below are the results from repacking the GoG copy of the game. Sound and movies were excluded.

| Method                      | Size         | Ratio |
| --------------------------- | ------------ | ----- |
| Original                    | 2041.655 MB  | 1.0   |
| Repacked                    | 1062.974 MB  | 0.52  |
| Repacked Prefer Compressed  | 833.532 MB   | 0.41  |
