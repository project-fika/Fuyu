using System;
using System.Reflection;

namespace Fuyu.Plugin.EFT.Reflection
{
    public static class PatchHelper
    {
        public static readonly Type[] Types;
        public const BindingFlags AnyInstanceFlags  = BindingFlags.Instance
                                                    | BindingFlags.Public
                                                    | BindingFlags.NonPublic
                                                    | BindingFlags.DeclaredOnly;

        static PatchHelper()
        {
            Types = typeof(ETransportProtocolType).Assembly.GetTypes();
        }
    }
}