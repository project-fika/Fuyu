using System.Runtime.Serialization;

namespace Fuyu.Backend.Core.DTO.Requests
{
    [DataContract]
    public class AccountRegisterGameRequest
    {
        [DataMember]
        public string Game;

        [DataMember]
        public string Edition;
    }
}