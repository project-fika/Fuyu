using System.Runtime.Serialization;
using Fuyu.Backend.BSG.DTO.Raid;

namespace Fuyu.Backend.BSG.DTO.Responses
{
    [DataContract]
    public class MatchGroupCurrentResponse
    {
        [DataMember]
        public SquadMember[] squad;

        // TODO: proper type
        [DataMember]
        public object raidSettings;
    }
}