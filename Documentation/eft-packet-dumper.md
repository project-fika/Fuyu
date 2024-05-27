# EFT: Packet dumper

This guide is useful for you if you need to inspect the client's comminucation
with the server over HTTP and WS.

## Requirements

- dnspy ([link](https://github.com/spt-haru/dnspy))
- `Assembly-CSharp-cleaned.dll` (produced by deobfuscation)

## Patches

These patches required to obtain server data from the client without using external tools like Fiddler.
These are done in dnspy on `Assembly-CSharp-cleaned.dll`.
See `eft-deobfuscation` for how you can produce `Assembly-CSharp-cleaned.dll`.

### Save requests / responses

This saves all the HTTP requests and responses to disk.

1. search for `SendAndHandleRetries`
2. modify `method_5`; insert this at the bottom, just before `return text2;`

```cs
var uri = new Uri(backRequest.MainURLFull);
var file = uri.LocalPath.Replace('/', '.').Remove(0, 1);
var time = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

if (backRequest.Params != null)
{
    var reqpath = (System.IO.Directory.GetCurrentDirectory() + "\\HTTP_DATA\\requests\\").Replace("\\\\", "\\");
    var reqdir = System.IO.Directory.CreateDirectory(reqpath);
    System.IO.File.WriteAllText($@"{reqpath}{file}_{time}.json", backRequest.Params.ToJson());
}

var respath = (System.IO.Directory.GetCurrentDirectory() + "\\HTTP_DATA\\responses\\").Replace("\\\\", "\\");
var resdir = System.IO.Directory.CreateDirectory(respath);
System.IO.File.WriteAllText($@"{respath}{file}_{time}.json", text2);
```

## Save notifications

This saves EFT's websocket commns to disk.

1. search for `DisplayMessageNotification`
2. modify `method_7`: insert this after `gclass2 = message.ParseJsonTo(Array.Empty<JsonConverter>());`

```cs
var notifpath = (System.IO.Directory.GetCurrentDirectory() + "\\HTTP_DATA\\notifications\\").Replace("\\\\", "\\");
var notifdir = System.IO.Directory.CreateDirectory(notifpath);
var file = $"{gclass.Type}-{gclass.EventId}";
var time = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
System.IO.File.WriteAllText($@"{notifpath}{file}_{time}.json", message);
```

## BattlEye

This enables us to load the custom assembly without battleye knowing.

1. search for `RunValidation`
2. replace `RunValidation`'s method body with this:

```cs
{
    this.Succeed = true;
}
```

## File integrity

This enables us to load the custom assembly with an invalid hash.

1. search for `RunFilesChecking`
2. replace `RunFilesChecking`'s method body with this:

```cs
{
    // empty
}
```

## Injection

1. Rename `Assembly-CSharp-cleaned.dll` to `Assembly-CSharp.dll`.
2. Copy-paste `Assembly-CSharp.dll` into `EscapeFromTarkov_Data`, do not interact with the prompt yet
3. Start the game from Battlestate Games Launcher
4. As soon as the launcher closes, click "replace" in the prompt