using System.Runtime.Serialization;

namespace Fuyu.Server.BSG.DTO.Common
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