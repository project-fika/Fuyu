using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Items
{
    [DataContract]
    public class ItemFoodDrinkComponent
    {
        [DataMember]
        public float HpPercent;
    }
}