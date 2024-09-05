using System.Runtime.Serialization;

namespace Fuyu.Server.Arena.DTO.Responses
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