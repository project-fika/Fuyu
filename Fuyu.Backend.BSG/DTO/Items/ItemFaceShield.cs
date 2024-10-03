using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemFaceShield
    {
        [DataMember]
        public byte Hits;

        [DataMember]
        public byte HitSeed;
    }
}