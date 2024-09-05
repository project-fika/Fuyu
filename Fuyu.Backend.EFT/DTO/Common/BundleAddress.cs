using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Common
{
    [DataContract]
    public class BundleAddress
    {
        [DataMember]
        public string path;

        [DataMember]
        public string rcid;
    }
}