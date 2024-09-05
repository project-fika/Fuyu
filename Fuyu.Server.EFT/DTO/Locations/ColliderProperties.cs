using System.Runtime.Serialization;
using Fuyu.Server.EFT.DTO.Common;

namespace Fuyu.Server.EFT.DTO.Locations
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