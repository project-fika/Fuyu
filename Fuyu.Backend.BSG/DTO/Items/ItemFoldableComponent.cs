using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Items
{
    [DataContract]
    public class ItemFoldableComponent
    {
        [DataMember]
        public bool Folded;
    }
}