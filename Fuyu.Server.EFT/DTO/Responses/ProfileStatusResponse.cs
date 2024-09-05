using System.Runtime.Serialization;
using Fuyu.Server.EFT.DTO.Multiplayer;

namespace Fuyu.Server.EFT.DTO.Responses
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