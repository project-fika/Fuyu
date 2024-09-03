using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.Fuyu.Accounts;

namespace Fuyu.Platform.Common.Models.Fuyu.Requests
{
    [DataContract]
    public struct AccountRegisterGameRequest
    {
        [DataMember]
        public EGame Game;

        [DataMember]
        public string Edition;
    }
}