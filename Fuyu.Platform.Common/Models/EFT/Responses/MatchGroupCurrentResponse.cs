using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct MatchGroupCurrentResponse
    {
        // TODO: proper type. Unable to find
        [DataMember]
        public object[] squad;
    }
}