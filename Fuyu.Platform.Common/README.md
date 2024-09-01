# Fuyu.Platform.Common

Code shared between projects.

## Networking

### Server

It's a simple wrapper around `WebSocketSharp.ServerHttpServer` that's good
enough for most cases. It only supports HTTP without secure connection.

- `HttpServer` receives incoming HTTP requests and has an internal router that
maps `HttpBehaviour` to a path.
- `HttpBehaviour` is what handles the path and sends back a response.
- `HttpContext` is metadata from a request

```cs
using System;
using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.IO;

// handles a request
public class HelloWorld : HttpBehaviour
{
    // run this code when the path it's bound to is requested
    public override void Run(HttpContext context)
    {
        // respond to the request
        SendText(context, "Hello, world!");
    }
}

public class Program
{
    static void Main()
    {
        // creates a server instance
        var server = new HttpServer("main", "http://localhost:8000");

        // register HelloWorld behaviour to the path /helloworld
        server.AddHttpBehaviour<HelloWorld>("/helloworld");

        // start the server
        server.Start();

        // keep the server running
        Terminal.WaitForInput();
    }
}
```

### HttpClient

It's simple wrapper around `HttpClient` that's good enough for most cases. You
can make HTTP requests with it to a HTTP server. It only supports HTTP without
secure connection.

It supports both sync and async operations.

```cs
using System;
using System.Text;
using System.Threading.Tasks;
using Fuyu.Platform.Common.Networking;

public class Program
{
    static async Task Main()
    {
        // make a client instance
        var client = new HttpClient("http://localhost:8000");

        // make request
        var data = await client.GetAsync("/helloworld");

        // show the result
        var result = Encoding.UTF8.GetString(data);
        Console.WriteLine(result);
    }
}
```

## IO

### Resx

A simple wrapper around loading embedded files from assemblies.

It assumes the file is located in the `embedded/` folder of your csproj.

```xml
  <ItemGroup>
    <EmbeddedResource Include="embedded/path/to/file.txt" />
  </ItemGroup>
```

Loading the file is quite simple:

```cs
using System;
using Fuyu.Platform.Common.IO;

public class Program
{
    static void Main()
    {
        // set assembly to load from
        Resx.SetSource("mysource", typeof(Program).Assembly);

        // load the file
        var text = Resx.GetText("mysource", "path.to.file.txt");

        // show the result
        Console.WriteLine(text);
    }
}
```

### Termial

A simple wrapper around C#'s `Console` functions.

```cs
using System;
using Fuyu.Platform.Common.IO;

public class Program
{
    static void Main()
    {
        // print some text
        Terminal.WriteLine("Hello, world!");

        // print a number
        var number = 1;
        Terminal.WriteLine(number);

        // wait for input
        Terminal.WaitForInput();
    }
}
```