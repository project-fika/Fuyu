using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Common
{
    [DataContract]
    public struct BundleAddress
    {
        [DataMember]
        public string path;

        [DataMember]
        public string rcid;
    }
}