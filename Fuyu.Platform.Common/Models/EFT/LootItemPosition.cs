using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Common;
using Fuyu.Platform.Common.Models.EFT.Items;

namespace Fuyu.Platform.Common.Models.EFT
{
    [DataContract]
    public struct LootItemPosition
    {
        [DataMember]
        public string Id;

        [DataMember]
        public Vector3 Position;

        [DataMember]
        public Vector3 Rotation;

        [DataMember]
        public ItemInstance Item;

        [DataMember]
        public string[] ValidProfiles;

        [DataMember]
        public bool IsContainer;

        [DataMember]
        public bool useGravity;

        [DataMember]
        public bool randomRotation;

        [DataMember]
        public Vector3 Shift;

        [DataMember]
        public short PlatformId; 
    }
}