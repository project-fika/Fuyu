using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.ItemEvents.Models
{
    [DataContract]
    public class ProfileChange
    {
        [DataMember(Name = "experience")]
        public int Experience;

        [DataMember(Name = "recipeUnlocked")]
        public Dictionary<string, bool> UnlockedRecipes = [];
    }
}
