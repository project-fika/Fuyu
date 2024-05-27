using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Profiles
{
    [DataContract]
    public struct UnlockedInfo
    {
        // TODO: proper type
        [DataMember]
        public object[] unlockedProductionRecipe;
    }
}