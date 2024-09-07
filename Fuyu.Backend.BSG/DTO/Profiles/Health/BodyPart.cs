using System.Runtime.Serialization;
using Fuyu.Backend.BSG.DTO.Common;

namespace Fuyu.Backend.BSG.DTO.Profiles.Health
{
    [DataContract]
    public class BodyPart
    {
        [DataMember]
        public CurrentMaximum<float> Health;
    }
}