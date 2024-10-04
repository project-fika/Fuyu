using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemFoldableComponent
    {
        [DataMember]
        public bool Folded;
    }
}