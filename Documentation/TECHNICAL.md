# Technical

## Notes

Some observations I made while working on the project.

### Http server

- EFT uses the cookie `$PHPSESSID` to send the current sessionid to the server.
- EFT's packets are `zlib` (RFC1950) compressed.
- EFT's response handler doesn't care for `Content` header.
- Decompressed packets must be `application/json; charset=utf8` format.
- Images send to EFT are **NEVER** compressed.
- Do **NOT** set `Content-Encoding` to a custom value (`zlib`), it will prevent
  the game from loading.
- Do **NOT** set `Content-Encoding` to any encoder known to Unity, Unity will
  decompress the packet _before_ EFT is able to decompress it.
- EFT does **NOT** use `deflate` (RFC1951), but `zlib` (RFC1950). They are not
  compatible.

### /client/game/profile/list

- An empty `TraderInfo` object send by EFT's servers is send as `JArray`, but
  populated it's `JObject`. This is remenants of when `TraderInfo` used to be
  a `JArray`.