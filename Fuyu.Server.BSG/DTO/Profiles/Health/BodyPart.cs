using System.Runtime.Serialization;
using Fuyu.Server.BSG.DTO.Common;

namespace Fuyu.Server.BSG.DTO.Profiles.Health
{
    [DataContract]
    public class BodyPart
    {
        [DataMember]
        public CurrentMaximum<float> Health;
    }
}