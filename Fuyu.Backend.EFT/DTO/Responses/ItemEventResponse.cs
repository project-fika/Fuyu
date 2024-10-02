using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Responses
{
    [DataContract]
    public class ItemEventResponse
    {
        [DataMember(Name = "profileChanges")]
        public Dictionary<string, ProfileChange> ProfileChanges { get; set; } = [];

        [DataMember(Name = "warnings")]
        public InventoryWarning[] InventoryWarnings = [];

        [DataContract]
        public class InventoryWarning
        {
            [DataMember(Name = "index")]
            public int RequestIndex { get; set; }

            [DataMember(Name = "errmsg")]
            public string ErrorMessage { get; set; }

            [DataMember(Name = "code")]
            public string ErrorCode { get; set; }

            [DataMember(Name = "msg")]
            public string String_0
            {
                set
                {
                    this.ErrorMessage = value;
                }
            }
        }

        public class ProfileChange
        {
            [DataMember(Name = "experience")]
            public int Experience;

            [DataMember(Name = "recipeUnlocked")]
            public Dictionary<string, bool> UnlockedRecipes = [];
        }
    }
}
