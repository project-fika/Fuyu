using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT;
using Newtonsoft.Json.Converters;

namespace Fuyu.Platform.Common.Models
{
    [DataContract]
    public struct ProfileInfo
    {
        [DataMember]
        public string Nickname;

        [DataMember]
        public string LowerNickname;

        [DataMember]
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
        public EPlayerSide Side;

        [DataMember]
        public string Voice;

        [DataMember]
        public int Level;

        [DataMember]
        public long Experience;

        [DataMember]
        public long RegistrationDate;

        // SKIPPED: GameVersion
        // Reason: only used on BSG's internal server

        // SKIPPED: AccountType
        // Reason: only used on BSG's internal server

        [DataMember]
        public EMemberCategory MemberCategory;

        // SKIPPED: LockedMoveCommands
        // Reason: only used on BSG's internal server

        [DataMember]
        public long SavageLockTime;

        [DataMember]
        public long LastTimePlayedAsSavage;

        [DataMember]
        public BotSettings Settings;

        [DataMember]
        public long NicknameChangeDate;

        // SKIPPED: NeedWipeOptions
        // Reason: only used on BSG's internal server

        // SKIPPED: LastCompletedWipe
        // Reason: only used on BSG's internal server

        // SKIPPED: LastCompletedEvent
        // Reason: only used on BSG's internal server

        [DataMember]
        public bool BannedState;

        [DataMember]
        public long BannedUntil;

        [DataMember]
        public bool IsStreamerModeAvailable;

        [DataMember]
        public bool SquadInviteRestriction;

        [DataMember]
        public bool HasCoopExtension;

        [DataMember]
        public Ban[] Bans;
    }
}