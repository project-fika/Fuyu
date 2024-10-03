using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemSideEffect
    {
        [DataMember]
        public float Value;
    }
}