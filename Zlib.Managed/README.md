# Zlib.Managed

Reimplementing `bsg.componentace.compression.libs.zlib` on top of `Elskom/Zlib.Managed` with additional tweaks.

- Based on release [1.1.4.0](https://github.com/Elskom/zlib.managed/releases/tag/1.1.4.0)
- Cherrypicked changes from [`main`](https://github.com/Elskom/zlib.managed)

## Notes

Since I wanted to make it directly compatible with EFT, I decided to include EFT's `SimpleZlib`'s signatures with
bindings to `MemoeryZlib`. This assumes that only `SimpleZlib` needs to be exposed to the client in order to function
as intended. yYu can use this library to link against instead of EFT's binary.

Please note it is impossible to run the libraries alongside eachother when `SimpleZlib` is imported from the namespace.
You must divide the codebase in two projects; one targeting EFT's binary, the other targeting this project.

## Changes

- Uses EFT assembly info
- Made all classes inside `Elskom/` folder `internal` except `ZStream`
- Uses `ReadOnlySpan<T>`, `Span<T>`

## Todo

- Implement `System.Buffer` (`ArrayPool`)
- Implement `Microsoft.ObjectPool` (pooling streams)
- Clean up codebase
  - Change most of `ZlibConst` to enums
  - Remove duplicate constant definitions
  - Rename methods to use .NET style conformance