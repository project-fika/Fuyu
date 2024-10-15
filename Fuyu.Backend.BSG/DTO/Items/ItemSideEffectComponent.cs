using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Items
{
    [DataContract]
    public class ItemSideEffectComponent
    {
        [DataMember]
        public float Value;
    }
}