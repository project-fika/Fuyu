using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Items
{
    [DataContract]
    public class ItemFoldable
    {
        [DataMember]
        public bool Folded;
    }
}