using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT
{
    [DataContract]
    public struct FoundInRaidItem
    {
        [DataMember]
        public string QuestId;

        [DataMember]
        public string ItemId;
    }
}