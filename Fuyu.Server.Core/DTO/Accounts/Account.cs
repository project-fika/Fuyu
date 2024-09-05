using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fuyu.Server.Core.DTO.Accounts
{
    [DataContract]
    public class Account
    {
        [DataMember]
        public int Id;

        [DataMember]
        public string Username;

        [DataMember]
        public string Password;

        [DataMember]
        public Dictionary<EGame, int> Games;
    }
}