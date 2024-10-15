using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Responses
{
    [DataContract]
    public class GameLogoutResponse
    {
        [DataMember]
        public string status;
    }
}