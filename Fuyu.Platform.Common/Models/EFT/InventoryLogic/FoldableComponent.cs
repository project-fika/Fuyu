using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.InventoryLogic;

namespace Fuyu.Platform.Common.Models.EFT.Items
{
    [DataContract]
    public struct FoldableComponent
    {
        [DataMember]
        public Slot FoldedSlot;
        
        [DataMember]
        public bool Folded;
    }
}