using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Locations
{
    [DataContract]
    public struct ColliderParam
    {
        [DataMember]
        public string _parent;

        [DataMember]
        public ColliderProperties _props;
    }
}