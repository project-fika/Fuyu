using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Profiles
{
    [DataContract]
    public class UnlockedInfo
    {
        // TODO: proper type
        [DataMember]
        public object[] unlockedProductionRecipe;
    }
}