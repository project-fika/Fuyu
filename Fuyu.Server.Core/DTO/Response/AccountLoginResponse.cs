using System.Runtime.Serialization;

namespace Fuyu.Server.Core.DTO.Responses
{
    [DataContract]
    public class AccountLoginResponse
    {
        [DataMember]
        public string SessionId;
    }
}