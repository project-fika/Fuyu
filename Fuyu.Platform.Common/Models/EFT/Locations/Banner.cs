using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Common;

namespace Fuyu.Platform.Common.Models.EFT.Locations
{
    [DataContract]
    public struct Banner
    {
        [DataMember]
        public string id;

        [DataMember]
        public BundleAddress pic;
    }
}