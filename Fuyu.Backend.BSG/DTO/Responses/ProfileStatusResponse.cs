using System.Runtime.Serialization;
using Fuyu.Backend.BSG.DTO.Multiplayer;

namespace Fuyu.Backend.BSG.DTO.Responses
{
    [DataContract]
    public class ProfileStatusResponse
    {
        [DataMember]
        public bool maxPveCountExceeded;

        [DataMember]
        public ProfileStatusInfo[] profiles;
    }
}