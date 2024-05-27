using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct ProfileSelectResponse
    {
        [DataMember]
        public string status;
    }
}