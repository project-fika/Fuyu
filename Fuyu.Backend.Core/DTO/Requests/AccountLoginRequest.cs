using System.Runtime.Serialization;

namespace Fuyu.Backend.Core.DTO.Requests
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