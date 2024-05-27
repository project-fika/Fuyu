using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Locations
{
    [DataContract]
    public struct BossSupport
    {
        [DataMember]
        public string BossEscortType;

        [DataMember]
        public string[] BossEscortDifficult;

        [DataMember]
        public string BossEscortAmount;
    }
}