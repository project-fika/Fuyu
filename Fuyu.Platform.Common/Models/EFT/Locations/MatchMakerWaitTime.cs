using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Locations
{
    [DataContract]
    public struct MatchMakerWaitTime
    {
        [DataMember]
        public int time;

        [DataMember]
        public int minPlayers;
    }
}