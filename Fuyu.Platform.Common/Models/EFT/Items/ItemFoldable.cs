using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Items
{
    [DataContract]
    public struct ItemFoldable
    {
        [DataMember]
        public bool Folded;
    }
}