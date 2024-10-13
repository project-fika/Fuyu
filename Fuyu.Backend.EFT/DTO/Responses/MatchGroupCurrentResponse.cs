using System.Runtime.Serialization;
using Fuyu.Backend.EFT.DTO.Raid;

namespace Fuyu.Backend.EFT.DTO.Responses
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