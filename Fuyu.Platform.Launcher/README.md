# Fuyu.Platform.Launcher

The actual launcher pages and functionality.
Can be used as a starting point if you want to make your own launcher.

## Fuyu.Launcher.Services

### EftProcess

`EftProcess` is a quick way to get a new EFT instance up and running. There are
a couple of things you need to provide:

- `cwd`: Current working directory. This is also where `EscapeFromTarkov.exe`
  must be located.
- `accountId`: The user to login.
- `address`: Main server address.

```cs
using System;
using Fuyu.Platform.Launcher.Services;

public class Program
{
    static void Main()
    {
        var cwd = Environment.CurrentDirectory;
        var accountId = 480892;
        var address = "http://localhost:8000";

        using (var process = EftProcess.Get(cwd, accountId, address))
        {
            process.Start();
        }
    }
}
```
