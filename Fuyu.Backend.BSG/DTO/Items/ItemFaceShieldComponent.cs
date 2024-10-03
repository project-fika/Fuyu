using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemFaceShieldComponent
    {
        [DataMember]
        public byte Hits;

        [DataMember]
        public byte HitSeed;
    }
}