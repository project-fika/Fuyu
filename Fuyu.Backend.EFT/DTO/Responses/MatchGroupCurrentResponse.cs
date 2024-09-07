using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Responses
{
    [DataContract]
    public class MatchGroupCurrentResponse
    {
        // TODO: proper type
        [DataMember]
        public object[] squad;

        // TODO: proper type
        [DataMember]
        public object raidSettings;
    }
}