using System;
using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Items;
using Fuyu.Platform.Common.Models.MongoDB;

namespace Fuyu.Platform.Common.Models.EFT.Templates
{
    [DataContract]
    public struct WeaponBuildTemplate
    {
        [DataMember]
        public MongoID MongoID;
        
        [DataMember]
        public string ItemIconName;
        
        [DataMember]
        public string HandbookName;
        
        [DataMember]
        public bool FromPreset;
        
        [DataMember]
        public ItemInstance item;
    }
}