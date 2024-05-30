using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.InventoryLogic;
using Fuyu.Platform.Common.Models.EFT.Items;
using Fuyu.Platform.Common.Models.EFT.Profiles;

namespace Fuyu.Platform.Common.Models.EFT.UI.Ragfair
{
    [DataContract]
    public class HandoverRequirements : IExchangeRequirement
    {
        [DataMember]
        public Offer Offer { get; set; }
        
        [DataMember]
        public ItemInstance Item { get; }
        
        [DataMember]
        public string TemplateId { get; }
        
        [DataMember]
        public string ItemName { get; }
        
        [DataMember]
        public int IntCount { get; }
        
        [DataMember]
        public double PreciseCount { get; }
        
        [DataMember]
        public bool OnlyFunctional { get; }
        
        [DataMember]
        public bool IsEncoded { get; }

        [DataMember] 
        public int Level;

        [DataMember]
        public EDogtagExchangeSide Side;
    }
}