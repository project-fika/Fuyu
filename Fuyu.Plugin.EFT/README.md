# Fuyu.Plugin.EFT

A simple bepinex plugin that only disables and modifies EFT code preventing
Fuyu.Backend from functioning. Can run on obfuscated `Assembly-CSharp.dll`.

## Usage

1. Install BepInEx installed in EFT's folder
2. Put `Fuyu.Plugin.EFT.dll` and ``Fuyu.Plugin.Core.dll` into `BepInEx/plugins`
3. Start the game through `Fuyu.Launcher.exe`

## Modifications

### BattlEyePatch

Since BattlEye would prevent our assembly from loading, we disable it here.

### ConsistencyGeneralPatch

Technically not required if you don't modify `Assembly-CSharp.dll` or don't
delete unused files (like `EscapeFromTarkov-BE.exe`) but I do this often enough
that it warrants inclusion.

Disables file integrity checking for general files (excludes unity bundles).

### ProtocolUtil

The game splits the scheme from the url and reconstructs the url later, but it
doesn't seem to do much. I just made it blank. Might cause issues in the
future and needs a proper replacement.