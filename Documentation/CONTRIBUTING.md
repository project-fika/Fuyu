# Contributing

## General

For code formatting:

- .NET Coding Convention
- I don't permit, labdas, `System.LINQ` unless it's for `Fuyu.Plugin` / `Fuyu.Plugin.Core` lookup patterns
- I don't permit primary constructors
- Only use structures that exist in a widespread of other languages (`if`, `else`, `for`, `while`, `break`, `continue`, `var`, `foreach`, `switch`, `case`, `return`, `struct`, `class`, `interface`)
- Use `using` as dispose pattern.
- Use `var` where possible (unless it reduces code quality)
- Control statement scope must be explicit
```
if (this)
{
   // code
}
```
- Shorthand notation for empty array initialization `[]` is permitted, shorthand notation for type initialization `new()` has to be discussed
- Data models must be `struct`, `class` only contains methods unless discussed
- Data models must use `DataContract` annotations and I don't permit library-specifc annotations (like `JsonProperty`)

Try to stick with to following from C#'s build-in namespaces:

- `System`
- `System.IO`
- `System.Collections.Generic`
- `System.Diagnostics`
- `System.Math`
- `System.Text`
- `System.Reflection`
- `System.Runtime.Serialization`

For external libraries:

- Only after discussing inclusion (might not permit it!)
- Make sure there is an abstraction for it inside `Fuyu.Common` and that it works for all three platforms

Architecture-wise:

- Prevent internal state wherever possible (simplifies multi-threading)
- Write tests for code wherever possible (see `Fuyu.Tests`, includes (de-)serializing data models)

## Fuyu.Server.EFT.DTO

Data should be translated to:

TS type          | C# type
---------------- | -----------------------------
`number`         | `int`/`long`/`float`/`double`
`string`         | `string`
`object`         | `struct`
`Record<T1, T2>` | `Dictionary<T1, T2>`

- If the entry might be missing, use `[DataMember(EmitDefaultValue = false)]`
  and make it a nullable type (example: `HideoutInfo? HideoutInfo`).
- If you do not know the correct type, use `object` and add the comment
  `// TODO: proper type`.

These rules ensure that data is easy to parse, easy to port over and remains
performant to operate on.

> Use the names from the json, **NOT** from `Assembly-CSharp.dll`

Why: makes it easier to update from just data dumps. The exception here is
     enum values. **ALWAYS** use enums in place of `string`/`number`.

> - `enum` parsed as `string` must **NOT** contain any value assignments.
> - `enum` parsed as `int` **MUST** have values assigned to all it's members.

Why: makes it visually distinct how the `enum` should be parsed.

## Updating to a newer version of EFT

1. Update the hollowed dlls inside `References/` using Seion.BatchHollower ([link](https://github.com/seionmoya/BatchHollower))
2. Update EFT dumps inside `Fuyu.Platform.Server`
3. Update data models inside `Fuyu.Common`
4. Add missing required route(s) in `Fuyu.Platform.Server`

## FAQ

> Why don't you deobfuscate `Assembly-CSharp.dll`?

It is an additional maintenance burden and means we have to distribute the
deobfuscation changes. The current setup makes it easier to update to newer
versions.

> Why no dependency injection?

It slows us down when prototyping, comes with a significant performance cost,
adds reliance on a third-party library and makes the source more difficult to
understand. If you want to change methods or swap types for your own, you can
also do this yourself using `System.Reflection` or `HarmonyX`.

> Why `Newtonsoft.Json` over `System.Text.Json`?

The latter requires additional dlls to run inside EFT, and it doesn't support
`DataContract` by default (requires additional plugins).