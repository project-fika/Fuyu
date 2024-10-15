using System.Runtime.Serialization;
using Fuyu.Backend.BSG.DTO.Common;

namespace Fuyu.Backend.BSG.DTO.Locations
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