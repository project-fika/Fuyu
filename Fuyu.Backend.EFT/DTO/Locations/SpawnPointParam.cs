using System.Runtime.Serialization;
using Fuyu.Backend.EFT.DTO.Common;

namespace Fuyu.Backend.EFT.DTO.Locations
{
    [DataContract]
    public class SpawnPointParam
    {
        [DataMember]
        public string Id;

        [DataMember]
        public Vector3 Position;

        [DataMember]
        public float Rotation;

        [DataMember]
        public string[] Sides;

        [DataMember]
        public string[] Categories;

        [DataMember]
        public string Infiltration;

        [DataMember]
        public float DelayToCanSpawnSec;

        [DataMember]
        public ColliderParam ColliderParams;

        [DataMember]
        public string BotZoneName;

        [DataMember]
        public int CorePointId;
    }
}