using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.Fuyu.Accounts
{
    [DataContract]
    public struct ArenaSave
    {
        [DataMember]
        public string Edition;

        [DataMember]
        public ArenaProfile PvP;
    }
}