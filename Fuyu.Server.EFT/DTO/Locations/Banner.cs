using System.Runtime.Serialization;
using Fuyu.Server.EFT.DTO.Common;

namespace Fuyu.Server.EFT.DTO.Locations
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