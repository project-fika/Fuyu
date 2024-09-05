using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Common
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