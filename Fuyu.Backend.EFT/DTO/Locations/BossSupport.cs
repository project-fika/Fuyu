using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Locations
{
    [DataContract]
    public class BossSupport
    {
        [DataMember]
        public string BossEscortType;

        [DataMember]
        public string[] BossEscortDifficult;

        [DataMember]
        public string BossEscortAmount;
    }
}