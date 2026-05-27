## WE4 Binary Editing DLL

This DLL is a low-level binary editing library for Winning Eleven 4 / ISS Pro Evolution on PlayStation 1.

The library allows direct reading and writing of compressed player structures stored inside memory cards and game save data using bit-level manipulation techniques.

## Features

- Read and write packed player data
- Edit player attributes directly from binary save structures
- Full support for WE4 stat blocks
- National team player number management
- Club squad number editing
- Direct file editing using FileStream
- Binary bit-field decoding and encoding
- Endian byte inversion support
- Optimized for PS1 memory card structures

## Editable Player Attributes

The DLL supports editing of:

- Speed
- Acceleration
- Dribble
- Stamina
- Technique
- Passing accuracy
- Shot accuracy
- Shot power
- Defense
- Offense
- Aggression
- Curve
- Jump
- Heading
- Body balance
- Feint Type B
- Preferred foot
- Outside foot
- Boots
- Height
- Age
- Body type
- Skin color
- Hair styles
- Hair colors
- Face/hair combinations
- Position
- Squad number

## Team Management Features

### National Teams
- Read national team player slots
- Write national team player assignments
- 23-player support

### Club Teams
- Read club squad numbers
- Write club squad numbers
- Automatic binary conversion

## Technical Details

- Written in VB.NET
- Uses binary packed bit structures
- Reads and writes 12-byte player blocks
- Reverse byte order support for PS1 data structures
- Optimized for classic Konami save formats

## Purpose

This DLL was created to simplify the development of editors, roster tools and database managers for Winning Eleven 4 PS1 by exposing an easy-to-use API for manipulating binary player and team data directly from game files.
