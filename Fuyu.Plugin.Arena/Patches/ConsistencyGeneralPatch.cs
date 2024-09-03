// Disable EFT's general file validation
// NOTE: does NOT disable client bundles validation

// TODO:
// * use arena types
// -- seionmoya, 2024/09/03

using System.Reflection;
using System.Threading.Tasks;
using EFT;
using Fuyu.Platform.Plugin.Reflection;
using Fuyu.Plugin.Arena.Reflection;

namespace Fuyu.Plugin.Arena.Patches
{
    public class ConsistencyGeneralPatch : APatch
    {
        public ConsistencyGeneralPatch() : base("com.fuyu.plugin.arena.consistencygeneral", EPatchType.Prefix)
        {
        }

        protected override MethodBase GetOriginalMethod()
        {
            var flags = PatchHelper.PrivateFlags;
            return typeof(TarkovApplication).BaseType.GetMethod("RunFilesChecking", flags);
        }

        protected static bool Patch(ref Task __result)
        {
            __result = Task.CompletedTask;

            // Don't run original code
            return false;
        }
    }
}