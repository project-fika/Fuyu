using System.Runtime.Serialization;
using Fuyu.Backend.Core.DTO.Accounts;

namespace Fuyu.Backend.Core.DTO.Requests
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