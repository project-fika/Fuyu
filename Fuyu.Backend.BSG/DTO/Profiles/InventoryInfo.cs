using System.Collections.Generic;
using System.Runtime.Serialization;
using Fuyu.Backend.EFT.DTO.Items;

namespace Fuyu.Backend.BSG.DTO.Profiles
{
    [DataContract]
    public class InventoryInfo
    {
        [DataMember]
        public ItemInstance[] items;

        [DataMember]
        public string equipment;

        [DataMember]
        public string stash;

        [DataMember]
        public string sortingTable;

        [DataMember]
        public string questRaidItems;

        [DataMember]
        public string questStashItems;

        // TODO: proper type
        [DataMember]
        public object fastPanel;

        [DataMember]
        public Dictionary<string, string> hideoutAreaStashes;

        // TODO: proper type
        [DataMember]
        public object[] favoriteItems;
    }
}