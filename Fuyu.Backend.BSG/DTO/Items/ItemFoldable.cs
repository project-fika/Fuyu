using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemFoldable
    {
        [DataMember]
        public bool Folded;
    }
}