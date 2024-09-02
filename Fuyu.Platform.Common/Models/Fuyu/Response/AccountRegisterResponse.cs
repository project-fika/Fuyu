using System.Runtime.Serialization;
using Fuyu.Platform.Common.Networking;

namespace Fuyu.Platform.Common.Models.Fuyu.Responses
{
    [DataContract]
    public struct AccountRegisterResponse
    {
        [DataMember]
        public ERegisterStatus Status;
    }
}