using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT
{
    [DataContract]
    public struct UnlockedInfo
    {
        [DataMember]
        public string[] unlockedProductionRecipe;
    }
}