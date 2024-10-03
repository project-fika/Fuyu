using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Common
{
    public enum EBuffRarity
    {
        [DataMember(Name = "common")]
        Common,
        [DataMember(Name = "rare")]
        Rare
    }
}
