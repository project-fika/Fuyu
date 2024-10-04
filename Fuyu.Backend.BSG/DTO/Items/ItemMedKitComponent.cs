using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemMedKitComponent
    {
        [DataMember]
        public float HpResource;
    }
}