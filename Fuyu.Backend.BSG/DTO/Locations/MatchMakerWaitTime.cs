using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Locations
{
    [DataContract]
    public class MatchMakerWaitTime
    {
        [DataMember]
        public int time;

        [DataMember]
        public int minPlayers;
    }
}