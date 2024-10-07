# Fuyu.Compression

A shim of `bsg.componentace.compression.libs.zlib`.
Also includes MemoryZlib, but should be refactored back into Fuyu.Common.

## Notes

Since I wanted to make it directly compatible with EFT, I decided to include
EFT's `SimpleZlib`'s signatures. This assumes that only `SimpleZlib` needs to
be exposed to the client in order to function as intended. You can use this
library to link against instead of EFT's binary.

Please note it is impossible to run the libraries alongside eachother when
`SimpleZlib` is imported from the namespace. You must divide the codebase in
two projects; one targeting EFT's binary, the other targeting this project.
Alternatively use `MemoryZlib` instead.
