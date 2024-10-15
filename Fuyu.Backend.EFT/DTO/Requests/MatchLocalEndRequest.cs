using System.Collections.Generic;
using System.Runtime.Serialization;
using Fuyu.Backend.EFT.DTO.Items;
using Fuyu.Backend.EFT.DTO.Raid;

namespace Fuyu.Backend.EFT.DTO.Requests
{
    [DataContract]
    public class MatchLocalEndRequest
    {
        [DataMember]
        public string serverId;

        [DataMember]
        public MatchLocalEndResult results;

        [DataMember]
        public ItemInstance[] lostInsuredItems;

        [DataMember]
        public Dictionary<string, ItemInstance[]> transferItems;

        // TODO: proper type
        [DataMember]
        public object locationTransit;
    }
}