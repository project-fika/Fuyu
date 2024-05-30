using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.InventoryLogic
{
    [DataContract]
    public struct Slot
    {
        [DataMember]
        public String Id;
        
        [DataMember]
        public Boolean Required;
        
        [DataMember]
        public Dictionary<String, Slot> ConflictingSlots;
        
        [DataMember] 
        public List<Slot> BlockerSlots;
    }
}