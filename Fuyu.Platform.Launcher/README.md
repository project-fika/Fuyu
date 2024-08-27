# Fuyu.Platform.Launcher

Contains the Launcher functionality. Can be used as a starting point if you
want to make your own launcher.

## Fuyu.Platform.Launcher.Services

### ProcessService

`ProcessService` is a quick way to get a new EFT instance up and running. There
are a couple of things you need to provide:

- `cwd`: Current working directory. This is also where `EscapeFromTarkov.exe`
  must be located.
- `accountId`: The user to login.
- `address`: Main server address.

```cs
using System;
using Fuyu.Platform.Launcher;

public class Program
{
    static void Main()
    {
        var cwd = Environment.CurrentDirectory;
        var accountId = 480892;
        var address = "http://localhost:8000";

        using (var process = ProcessService.StartEft(cwd, accountId, address))
        {
            process.Start();
        }
    }
}
```
