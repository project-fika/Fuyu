using System.Runtime.Serialization;
using Fuyu.Backend.EFT.DTO.Common;

namespace Fuyu.Backend.EFT.DTO.Locations
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