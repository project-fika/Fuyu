using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.Fuyu.Accounts
{
    [DataContract]
    public struct EftSave
    {
        [DataMember]
        public string Edition;

        [DataMember]
        public EftProfile PvP;

        [DataMember]
        public EftProfile PvE;
    }
}