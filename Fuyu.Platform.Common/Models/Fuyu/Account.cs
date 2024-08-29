using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.Fuyu.Savegame;

namespace Fuyu.Platform.Common.Models.Fuyu
{
    [DataContract]
    public struct Account
    {
        [DataMember]
        public string Username;

        [DataMember]
        public string Password;

        [DataMember]
        public EftSave EftSave;
    }
}