using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Items;

namespace Fuyu.Platform.Common.Models.EFT.InventoryLogic
{
    [DataContract]
    public struct InventoryInfo
    {
        [DataMember]
        public ItemInstance[] Items;

        [DataMember]
        public String Equipment;

        [DataMember]
        public String Stash;

        [DataMember]
        public String SortingTable;

        [DataMember]
        public String QuestRaidItems;

        [DataMember]
        public String QuestStashItems;

        [DataMember]
        public Dictionary<EBoundItem, String> FastPanel; 

        [DataMember]
        public Dictionary<EAreaType, String> HideoutAreaStashes;

        [DataMember]
        public List<String> FavoriteItems;
    }
}