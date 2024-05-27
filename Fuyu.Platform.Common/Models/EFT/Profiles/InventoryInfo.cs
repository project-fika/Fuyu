using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Items;

namespace Fuyu.Platform.Common.Models.EFT.Profiles
{
    [DataContract]
    public struct InventoryInfo
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

        // TODO: proper type
        [DataMember]
        public object hideoutAreaStashes;

        // TODO: proper type
        [DataMember]
        public object[] favoriteItems;
    }
}