using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct GameConfigResponse
    {
        [DataMember]
        public int aid;

        [DataMember]
        public string lang;

        [DataMember]
        public Dictionary<string, string> languages;

        [DataMember]
        public bool ndaFree;

        [DataMember]
        public int taxonomy;

        [DataMember]
        public string activeProfileId;

        [DataMember]
        public Backends backend;

        [DataMember]
        public bool useProtobuf;

        [DataMember]
        public double utc_time;

        [DataMember]
        public int totalInGame;

        [DataMember]
        public bool reportAvailable;

        [DataMember]
        public bool twitchEventMember;

        [DataMember]
        public string sessionMode;

        [DataMember]
        public PurchasedGames purchasedGames;

        [DataMember]
        public bool isGameSynced;
    }

    [DataContract]
    public struct PurchasedGames
    {
        [DataMember]
        public bool eft;

        [DataMember]
        public bool arena;
    }
}