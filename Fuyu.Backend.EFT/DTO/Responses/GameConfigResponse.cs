using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Responses
{
    [DataContract]
    public class GameConfigResponse
    {
        // SKIPPED: aid
        // Reason: only used on BSG's internal server

        // SKIPPED: lang
        // Reason: only used on BSG's internal server

        // SKIPPED: languages
        // Reason: only used on BSG's internal server

        // SKIPPED: ndaFree
        // Reason: only used on BSG's internal server

        // SKIPPED: taxomony
        // Reason: only used on BSG's internal server

        // SKIPPED: activeProfileId
        // Reason: only used on BSG's internal server

        [DataMember]
        public Backends backend;

        // SKIPPED: useProtobuf
        // Reason: only used on BSG's internal server

        [DataMember]
        public double utc_time;

        // SKIPPED: totalInGame
        // Reason: only used on BSG's internal server

        [DataMember]
        public bool reportAvailable;

        [DataMember]
        public bool twitchEventMember;

        // SKIPPED: sessionMode
        // Reason: only used on BSG's internal server

        [DataMember]
        public PurchasedGames purchasedGames;

        // NOTE: in relation to trader "Ref" (is game synced with Arena)
        [DataMember]
        public bool isGameSynced;
    }

    [DataContract]
    public class PurchasedGames
    {
        [DataMember]
        public bool eft;

        [DataMember]
        public bool arena;
    }
}