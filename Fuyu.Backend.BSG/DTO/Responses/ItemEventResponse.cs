using System.Collections.Generic;
using System.Runtime.Serialization;
using Fuyu.Backend.BSG.ItemEvents.Models;

namespace Fuyu.Backend.BSG.DTO.Responses
{
    [DataContract]
    public class ItemEventResponse
    {
        [DataMember(Name = "profileChanges")]
        public Dictionary<string, ProfileChange> ProfileChanges { get; set; } = [];

        [DataMember(Name = "warnings")]
        public InventoryWarning[] InventoryWarnings = [];
    }
}
