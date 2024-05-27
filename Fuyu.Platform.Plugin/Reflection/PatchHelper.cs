using System;
using System.Collections.Generic;
using System.Reflection;
using EFT;
using HarmonyLib;

namespace Fuyu.Platform.Plugin.Reflection
{
    public static class PatchHelper
    {
        public static readonly Type[] Types;
        public const BindingFlags PrivateFlags = BindingFlags.Instance
                                               | BindingFlags.NonPublic
                                               | BindingFlags.DeclaredOnly;

        static PatchHelper()
        {
            Types = typeof(TarkovApplication).Assembly.GetTypes();
        }
    }
}