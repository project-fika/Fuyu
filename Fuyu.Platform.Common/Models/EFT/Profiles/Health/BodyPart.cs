using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Common;

namespace Fuyu.Platform.Common.Models.EFT.Profiles.Health
{
    [DataContract]
    public struct BodyPart
    {
        [DataMember]
        public CurrentMaximum<float> Health;
    }
}