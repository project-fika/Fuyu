# EFT: Deobfuscation

This guide is useful for you if you need to inspect the client's source or need
to make modifications to it. If your goal is the latter, make sure to also read
the `eft-packet-dumper.md` guide to prevent suprises.

## Requirements

- de4dot ([link](https://github.com/spt-haru/de4dot))
- dnspy ([link](https://github.com/spt-haru/dnspy))
- `Assembly-CSharp.dll` (from live EFT)

### 1. Deobfuscating the client

(Make sure in dnsy search that "Search in framework assemblies" is enabled.)

1. dnspy > file > open > `Assembly-CSharp.dll`
2. dnspy > search > `CurrentDomain` > select `AppDomain.CurrentDomain { get; }`
4. scroll up until you find:

```cs
public extern object GetData(string name);
```

5. right-click on `GetData` > `Analyze` > Used by > The second one with the unicode hash

You should now see this:

```cmd
internal sealed class \uEFB1
{
	// Token: 0x06012F31 RID: 77617 RVA: 0x00588C3C File Offset: 0x00586E3C
	public static string \uE000(int \uE001\uEE35)
	{
		return (string)((Hashtable)AppDomain.CurrentDomain.GetData(\uEFB1.\uE002))[\uE001\uEE35];
	}
}
```

5. Run the following (change `0x06012F31` to the token from `\uE000`)

```cmd
de4dot.exe --un-name "!^<>[a-z0-9]$&!^<>[a-z0-9]__.*$&![A-Z][A-Z]\$<>.*$&^[a-zA-Z_<{$][a-zA-Z_0-9<>{}$.`-]*$" "Assembly-CSharp.dll" --strtyp delegate --strtok 0x06012F31
pause
```

### 2. Fix ResolutionScope error

1. copy-paste `Assembly-CSharp-cleaned.dll` into `<gamedir>/EscapeFromTarkov_Data/Managed/`
2. dnspy > file > open > `Assembly-CSharp-cleaned.dll`
3. dnspy > file > save module > ok