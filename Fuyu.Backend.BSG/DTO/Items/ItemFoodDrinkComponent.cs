using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemFoodDrinkComponent
    {
        [DataMember]
        public float HpPercent;
    }
}