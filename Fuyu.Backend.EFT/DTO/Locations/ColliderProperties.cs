using System.Runtime.Serialization;
using Fuyu.Backend.EFT.DTO.Common;

namespace Fuyu.Backend.EFT.DTO.Locations
{
    [DataContract]
    public class ColliderProperties
    {
        [DataMember]
        public Vector3 Center;

        [DataMember]
        public float Radius;
    }
}