using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct MatchGroupCurrentResponse
    {
        // TODO: proper type
        [DataMember]
        public object[] squad;
    }
}