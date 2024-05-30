using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT
{
    [DataContract]
    public struct WildSpawnSupports
    {
        [DataMember]
        public string BossEscortType;

        [DataMember]
        public string[] BossEscortDifficult;

        [DataMember]
        public string BossEscortAmount;
    }
}