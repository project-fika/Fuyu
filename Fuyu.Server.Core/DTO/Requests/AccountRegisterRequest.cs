using System.Runtime.Serialization;

namespace Fuyu.Server.Core.DTO.Requests
{
    [DataContract]
    public class AccountRegisterRequest
    {
        [DataMember]
        public string Username;

        [DataMember]
        public string Password;
    }
}