using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Responses
{
    [DataContract]
    public class RepeatableQuestsResponse
    {
        // TODO: proper type
        [DataMember]
        public object[] squad;
    }
}