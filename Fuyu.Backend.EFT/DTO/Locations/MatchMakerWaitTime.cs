using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Locations
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