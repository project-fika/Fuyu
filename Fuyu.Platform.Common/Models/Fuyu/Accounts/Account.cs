using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.Fuyu.Accounts
{
    [DataContract]
    public struct Account
    {
        [DataMember]
        public int Id;

        [DataMember]
        public string Username;

        [DataMember]
        public string Password;

        [DataMember]
        public EftSave EftSave;
    }
}