# WebSocketSharp

A more recent version of websocket-sharp with tweaks.

- Based on commit [master:52ba479](https://github.com/sta/websocket-sharp/commit/52ba479)
- Converted to `netstandard2.0`
- Uses EFT assembly info

## Notes

Since `websocket-sharp` exists in EFT but targets .NET Framework, I made this
library uses the exact same versioning as EFT and targets .NET Standard 2.0.

This way you don't need to distribute this library when using `Fuyu` lib inside
the client.