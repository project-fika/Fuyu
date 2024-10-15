using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Responses
{
    [DataContract]
    public class RepeatableQuestsResponse
    {
        // TODO: proper type
        [DataMember]
        public object[] squad;
    }
}