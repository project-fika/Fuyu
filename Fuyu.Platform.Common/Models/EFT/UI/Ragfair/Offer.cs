using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Items;
using Fuyu.Platform.Common.Models.EFT.Profiles;

namespace Fuyu.Platform.Common.Models.EFT.UI.Ragfair
{
    [DataContract]
    public struct Offer
    {
        [DataMember]
        public string _id;
        
        [DataMember]
        public long intId;
        
        [DataMember]
        public RagfairInfo user;
        
        [DataMember]
        public ItemInstance[] items;
        
        [DataMember]
        public string root;
        
        [DataMember]
        public int itemsCost;
        
        [DataMember]
        public int requirementsCost;
        
        [DataMember]
        public HandoverRequirements[] requirements;
        
        [DataMember]
        public double startTime;
        
        [DataMember]
        public double endTime;
        
        [DataMember]
        public bool wasEdit;
        
        [DataMember]
        public bool exchange;
        
        [DataMember]
        public int loyaltyLevel;
        
        [DataMember]
        public bool locked;
        
        [DataMember]
        public bool unlimitedCount;
        
        [DataMember]
        public int buyRestrictionMax;
        
        [DataMember]
        public int buyRestrictionCurrent;
        
        [DataMember]
        public bool sellInOnePiece;
        
        [DataMember]
        public int summaryCost;
    }
}