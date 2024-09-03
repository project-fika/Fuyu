using BepInEx;
using Fuyu.Platform.Plugin.Reflection;
using Fuyu.Plugin.EFT.Patches;
using Fuyu.Plugin.EFT.Utils;

namespace Fuyu.Plugin.EFT
{
    [BepInPlugin("com.fuyu.plugin.eft", "Fuyu.Plugin.EFT", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private readonly APatch[] _patches;

        public Plugin()
        {
            _patches = new APatch[]
            {
                new BattlEyePatch(),
                new ConsistencyGeneralPatch()
            };
        }

        protected void Awake()
        {
            Logger.LogInfo("[Fuyu.Plugin] Patching...");

            // NOTE: disable this for packet dumping
            ProtocolUtil.RemoveTransportPrefixes();

            foreach (var patch in _patches)
            {
                patch.Enable();
            }
        }

        protected void OnApplicationQuit()
        {
            Logger.LogInfo("[Fuyu.Plugin] Unpatching...");

            foreach (var patch in _patches)
            {
                patch.Disable();
            }
        }
    }
}