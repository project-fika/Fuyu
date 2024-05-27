using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Common;
using Fuyu.Platform.Common.Models.EFT.Profiles.Health;

namespace Fuyu.Platform.Common.Models.EFT.Profiles
{
    [DataContract]
    public struct HealthInfo
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
    }
}