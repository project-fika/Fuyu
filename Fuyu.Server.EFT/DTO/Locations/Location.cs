using System.Runtime.Serialization;
using Fuyu.Server.EFT.DTO.Common;

namespace Fuyu.Server.EFT.DTO.Locations
{
    [DataContract]
    public class Location
    {
        [DataMember]
        public bool Enabled;

        [DataMember]
        public bool EnableCoop;

        [DataMember]
        public bool ForceOnlineRaidInPVE;

        [DataMember]
        public bool Locked;

        [DataMember]
        public string Name;

        [DataMember]
        public BundleAddress Scene;

        [DataMember]
        public float Area;

        [DataMember]
        public int RequiredPlayerLevelMin;

        [DataMember]
        public int RequiredPlayerLevelMax;

        [DataMember]
        public int PmcMaxPlayersInGroup;

        [DataMember]
        public int ScavMaxPlayersInGroup;

        [DataMember]
        public int MinPlayers;

        [DataMember]
        public int MaxPlayers;

        [DataMember]
        public int MaxCoopGroup;

        [DataMember]
        public int IconX;

        [DataMember]
        public int IconY;

        [DataMember]
        public Wave[] waves;

        [DataMember]
        public ItemLimit[] limits;

        [DataMember]
        public int AveragePlayTime;

        [DataMember]
        public int AveragePlayerLevel;

        [DataMember]
        public int EscapeTimeLimit;

        [DataMember]
        public int EscapeTimeLimitPVE;

        [DataMember]
        public int EscapeTimeLimitCoop;

        [DataMember]
        public string Rules;

        [DataMember]
        public bool IsSecret;

        [DataMember]
        public int MaxDistToFreePoint;

        [DataMember]
        public int MinDistToFreePoint;

        [DataMember]
        public int MaxBotPerZone;

        [DataMember]
        public string OpenZones;

        [DataMember]
        public bool OcculsionCullingEnabled;

        [DataMember]
        public bool OldSpawn;

        [DataMember]
        public bool OfflineOldSpawn;

        [DataMember]
        public bool NewSpawn;

        [DataMember]
        public bool OfflineNewSpawn;

        [DataMember]
        public int BotMax;

        [DataMember]
        public int BotMaxPvE;

        [DataMember]
        public int BotStart;

        [DataMember]
        public int BotStartPlayer;

        [DataMember]
        public int BotStop;

        [DataMember]
        public int BotSpawnTimeOnMin;

        [DataMember]
        public int BotSpawnTimeOnMax;

        [DataMember]
        public int BotSpawnTimeOffMin;

        [DataMember]
        public int BotSpawnTimeOffMax;

        [DataMember]
        public int BotEasy;

        [DataMember]
        public int BotNormal;

        [DataMember]
        public int BotHard;

        [DataMember]
        public int BotImpossible;

        [DataMember]
        public int BotAssault;

        [DataMember]
        public int BotMarksman;

        [DataMember]
        public string DisabledScavExits;

        [DataMember]
        public int MinPlayerLvlAccessKeys;

        [DataMember]
        public string[] AccessKeys;

        [DataMember]
        public long UnixDateTime;

        [DataMember]
        public GroupScenario NonWaveGroupScenario;

        [DataMember]
        public int BotSpawnCountStep;

        [DataMember]
        public int BotSpawnPeriodCheck;

        [DataMember]
        public int GlobalContainerChanceModifier;

        [DataMember]
        public MinMaxBot[] MinMaxBots;

        // TODO: update BotLocationModifier type
        [DataMember]
        public object BotLocationModifier;

        [DataMember]
        public Exit[] exits;

        [DataMember]
        public bool DisabledForScav;

        [DataMember]
        public MaxItemCount[] maxItemCountInLocation;

        [DataMember]
        public BossSpawn[] BossLocationSpawn;

        [DataMember]
        public SpawnPointParam[] spawnPointParams;

        [DataMember(EmitDefaultValue = false)]
        public AirdropParameters[] AirdropParameters;

        [DataMember(EmitDefaultValue = false)]
        public MatchMakerWaitTime[] MatchMakerMinPlayersByWaitTime;

        [DataMember]
        public Transit[] transits;

        [DataMember]
        public string Id;

        [DataMember]
        public string _Id;

        // TODO: proper type
        [DataMember]
        public object[] Loot;

        [DataMember]
        public Banner[] Banners;
    }
}