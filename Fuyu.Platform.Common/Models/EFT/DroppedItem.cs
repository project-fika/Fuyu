using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT
{
    [DataContract]
    public struct DroppedItem
    {
        [DataMember]
        public string QuestId;

        [DataMember]
        public string ItemId;

        [DataMember]
        public string ZoneId;
    }
}