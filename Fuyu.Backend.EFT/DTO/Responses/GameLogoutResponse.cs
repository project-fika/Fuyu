using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Responses
{
    [DataContract]
    public class GameLogoutResponse
    {
        [DataMember]
        public string status;
    }
}