// Dump HTTP packets
// TODO: make it work without deobfuscation

/*
#if DEBUG

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Fuyu.Platform.Plugin.Reflection;
using BackRequest = GClass562;          // NOTE: update this when using

namespace Fuyu.Plugin.Patches
{
    public class HttpDumperPatch : APatch
    {
        public HttpDumperPatch() : base("com.fuyu.plugin.httpdumper", EPatchType.Postfix)
        {
        }

        protected override MethodBase GetOriginalMethod()
        {
            var type = PatchHelper.Types.Single(t => t.GetMethod("SendAndHandleRetries") != null);
            return type.GetMethod("method_5", PatchHelper.PrivateFlags);
        }

        protected static void Patch(string __result, BackRequest backRequest)
        {
            var uri = new Uri(backRequest.MainURLFull);
            var file = uri.LocalPath.Replace('/', '.').Remove(0, 1);
            var time = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

            if (backRequest.Params != null)
            {
                var reqpath = (Directory.GetCurrentDirectory() + "\\HTTP_DATA\\requests\\")
                    .Replace("\\\\", "\\");

                Directory.CreateDirectory(reqpath);
                File.WriteAllText($@"{reqpath}{file}_{time}.json", backRequest.Params.ToJson());
            }

            var respath = (Directory.GetCurrentDirectory() + "\\HTTP_DATA\\responses\\")
                .Replace("\\\\", "\\");

            Directory.CreateDirectory(respath);
            File.WriteAllText($@"{respath}{file}_{time}.json", __result);
        }
    }
}

#endif
*/