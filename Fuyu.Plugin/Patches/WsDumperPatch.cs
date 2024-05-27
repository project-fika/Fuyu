// Dump websocket event packets
// TODO: make it work without deobfuscation

/*
#if DEBUG

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Fuyu.Platform.Plugin.Reflection;
using EventInfo = GClass2230;           // NOTE: update this when using

namespace Fuyu.Plugin.Patches
{
    public class WsDumperPatch : APatch
    {
        public WsDumperPatch() : base("com.fuyu.plugin.wsdumper", EPatchType.Postfix)
        {
        }

        protected override MethodBase GetOriginalMethod()
        {
            var type = PatchHelper.Types.Single(t => t.GetMethod("DisplayMessageNotification") != null);
            return type.GetMethod("method_7", PatchHelper.PrivateFlags);
        }

        protected static void Patch(string message)
        {
            var gclass = message.ParseJsonTo<EventInfo>(Array.Empty<JsonConverter>());
            var notifpath = (Directory.GetCurrentDirectory() + "\\HTTP_DATA\\notifications\\").Replace("\\\\", "\\");
            var file = $"{gclass.Type}-{gclass.EventId}";

            Directory.CreateDirectory(notifpath);
            File.WriteAllText($@"{notifpath}{file}.json", message);
        }
    }
}

#endif
*/