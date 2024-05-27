using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Items
{
    [DataContract]
    public struct ItemMedKit
    {
        [DataMember]
        public int HpResource;
    }
}