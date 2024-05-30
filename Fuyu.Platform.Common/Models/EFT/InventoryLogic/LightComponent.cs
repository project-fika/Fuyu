using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.InventoryLogic
{
    [DataContract]
    public struct LightComponent
    {
        [DataMember]
        public bool IsActive;

        [DataMember]
        public int SelectedMode;
    }
}