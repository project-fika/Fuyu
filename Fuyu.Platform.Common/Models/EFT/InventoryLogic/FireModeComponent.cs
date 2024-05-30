using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.InventoryLogic
{
    [DataContract]
    public struct FireModeComponent
    {
        [DataMember]
        public string FireMode;
    }
}