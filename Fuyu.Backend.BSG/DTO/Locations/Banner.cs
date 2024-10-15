using System.Runtime.Serialization;
using Fuyu.Backend.BSG.DTO.Common;

namespace Fuyu.Backend.BSG.DTO.Locations
{
    [DataContract]
    public class Banner
    {
        [DataMember]
        public string id;

        [DataMember]
        public BundleAddress pic;
    }
}