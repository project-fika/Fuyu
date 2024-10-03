using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemSideEffectComponent
    {
        [DataMember]
        public float Value;
    }
}