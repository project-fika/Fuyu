using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Items
{
    [DataContract]
    public class ItemMedKitComponent
    {
        [DataMember]
        public float HpResource;
    }
}