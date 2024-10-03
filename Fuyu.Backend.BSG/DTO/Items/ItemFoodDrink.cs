using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemFoodDrink
    {
        [DataMember]
        public float HpPercent;
    }
}