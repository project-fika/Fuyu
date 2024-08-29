using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Multiplayer;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct ProfileStatusResponse
    {
        [DataMember]
        public bool maxPveCountExceeded;

        [DataMember]
        public ProfileStatusInfo[] profiles;
    }
}