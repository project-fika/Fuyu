using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Common;

namespace Fuyu.Platform.Common.Models.EFT
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