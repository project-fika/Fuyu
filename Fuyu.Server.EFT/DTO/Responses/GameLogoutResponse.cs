using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Responses
{
    [DataContract]
    public class GameLogoutResponse
    {
        [DataMember]
        public string status;
    }
}