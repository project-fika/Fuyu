using System.Runtime.Serialization;
using Fuyu.Server.Core.DTO.Accounts;

namespace Fuyu.Server.Core.DTO.Requests
{
    [DataContract]
    public class AccountRegisterGameRequest
    {
        [DataMember]
        public EGame Game;

        [DataMember]
        public string Edition;
    }
}