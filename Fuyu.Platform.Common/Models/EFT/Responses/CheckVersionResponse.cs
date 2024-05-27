using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct CheckVersionResponse
    {
        [DataMember]
        public bool isvalid;

        [DataMember]
        public string latestVersion;
    }
}