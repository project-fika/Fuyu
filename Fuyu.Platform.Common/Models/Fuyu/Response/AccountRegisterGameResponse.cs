using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.Fuyu.Accounts;

namespace Fuyu.Platform.Common.Models.Fuyu.Responses
{
    [DataContract]
    public struct AccountRegisterGameResponse
    {
        [DataMember]
        public ERegisterStatus Status;
    }
}