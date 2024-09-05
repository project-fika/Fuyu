using System.Runtime.Serialization;
using Fuyu.Server.BSG.DTO.Common;
using Fuyu.Server.BSG.DTO.Profiles.Health;

namespace Fuyu.Server.BSG.DTO.Profiles
{
    [DataContract]
    public class HealthInfo
    {
        [DataMember]
        public CurrentMaximum<float> Hydration;

        [DataMember]
        public CurrentMaximum<float> Energy;

        [DataMember]
        public CurrentMaximum<float> Temperature;

        [DataMember]
        public BodyPartInfo BodyParts;

        [DataMember]
        public long UpdateTime;

        [DataMember]
        public bool Immortal;
    }
}