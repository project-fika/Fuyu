using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Requests
{
    [DataContract]
    public struct LocationGetLocalLootRequest
    {
        [DataMember]
        public string locationId;

        [DataMember]
        public int variantId;
    }
}