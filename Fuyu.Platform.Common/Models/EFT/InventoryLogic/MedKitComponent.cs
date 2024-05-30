using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Items
{
    [DataContract]
    public struct MedKitComponent
    {
        [DataMember]
        public int HpResource;
    }
}