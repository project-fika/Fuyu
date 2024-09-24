# Zlib.Managed

A more recent version of `ComponentAce.Compression.Libs.Zlib` with tweaks

- Based on release [1.1.4.0](https://github.com/Elskom/zlib.managed/releases/tag/1.1.4.0)

## Notes

Since `ZOutputStream` exists in EFT's `bsg.componentace.compression.libs.zlib`,
I want to avoid loading two zlib libraries. That's why `ZOutputStream` only
exposes calls used by `Fuyu.Platform.Common.Compression`, the code inside the
`Elskom` folder is marked `internal` and the assembly matches EFT's assembly
info.

This way you don't need to distribute this library when using `Fuyu` lib inside
the client.

## Changes

- Made all classes inside `Elskom/` folder `internal`
- Uses EFT assembly info
- Uses `ReadOnlySpan<T>`, `Span<T>`
