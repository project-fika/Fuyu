using System.Runtime.Serialization;

namespace Fuyu.Backend.Core.DTO.Responses
{
    [DataContract]
    public class AccountLoginResponse
    {
        [DataMember]
        public string SessionId;
    }
}