using System.Runtime.Serialization;

namespace Fuyu.Backend.Core.DTO.Accounts
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
        public int? EftAid;

        [DataMember]
        public int? ArenaAid;
    }
}