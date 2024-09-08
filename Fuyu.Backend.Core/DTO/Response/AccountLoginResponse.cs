using System.Runtime.Serialization;
using Fuyu.Backend.Core.DTO.Accounts;

namespace Fuyu.Backend.Core.DTO.Responses
{
    [DataContract]
    public class AccountLoginResponse
    {
        [DataMember]
        public ELoginStatus Status;

        [DataMember]
        public string SessionId;
    }
}