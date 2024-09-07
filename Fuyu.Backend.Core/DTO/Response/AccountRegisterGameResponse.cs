using System.Runtime.Serialization;
using Fuyu.Backend.Core.DTO.Accounts;

namespace Fuyu.Backend.Core.DTO.Responses
{
    [DataContract]
    public class AccountRegisterGameResponse
    {
        [DataMember]
        public ERegisterStatus Status;
    }
}