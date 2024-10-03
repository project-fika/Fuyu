using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemCultistAmuletComponent
    {
        [DataMember(Name = "NumberOfUsages")]
        public int NumberOfUsages { get; set; }
    }
}