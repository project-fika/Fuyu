using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Common;

namespace Fuyu.Platform.Common.Models.EFT.Locations
{
    [DataContract]
    public struct Location
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

        // TODO: proper type
        [DataMember]
        public object[] doors;

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
        public int users_gather_seconds;
        
        [DataMember]
        public int users_spawn_seconds_n;
        
        [DataMember]
        public int users_spawn_seconds_n2;
        
        [DataMember]
        public int users_summon_seconds;
        
        [DataMember]
        public int sav_summon_seconds;
        
        [DataMember]
        public int matching_min_seconds;

        [DataMember]
        public bool GenerateLocalLootCache;

        [DataMember]
        public int PlayersRequestCount;

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

        [DataMember]
        public BotLocationModifier BotLocationModifier;

        [DataMember]
        public Exit[] exits;

        [DataMember]
        public bool DisabledForScav;

        [DataMember]
        public SpawnPointParam[] spawnPointParams;

        // TODO: proper type
        [DataMember]
        public object[] AirdropParameters;

        [DataMember]
        public MaxItemCount[] maxItemCountInLocation;

        [DataMember]
        public BossSpawn[] BossLocationSpawn;

        [DataMember(EmitDefaultValue = false)]
        public MatchMakerWaitTime[] MatchMakerMinPlayersByWaitTime;

        // TODO: proper type
        [DataMember]
        public object[] transits;

        [DataMember]
        public string Id;

        [DataMember]
        public string _Id;

        // TODO: proper type
        [DataMember]
        public object[] Loot;

        [DataMember]
        public BundleAddress[] Banners;
    }
}