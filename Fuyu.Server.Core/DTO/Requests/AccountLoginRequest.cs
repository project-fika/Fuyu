using System.Runtime.Serialization;

namespace Fuyu.Server.Core.DTO.Requests
{
    [DataContract]
    public class AccountLoginRequest
    {
        [DataMember]
        public string Username;

        [DataMember]
        public string Password;
    }
}