using System.Runtime.Serialization;
using Fuyu.Server.Core.DTO.Accounts;

namespace Fuyu.Server.Core.DTO.Responses
{
    [DataContract]
    public class AccountRegisterResponse
    {
        [DataMember]
        public ERegisterStatus Status;
    }
}