using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Locations
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