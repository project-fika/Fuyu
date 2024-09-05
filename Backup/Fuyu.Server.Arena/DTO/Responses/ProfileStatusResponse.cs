using System.Runtime.Serialization;
using Fuyu.Backend.EFT.DTO.Multiplayer;

namespace Fuyu.Backend.Arena.DTO.Responses
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