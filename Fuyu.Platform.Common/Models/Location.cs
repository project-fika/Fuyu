using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT;
using Fuyu.Platform.Common.Models.EFT.Common;
using Fuyu.Platform.Common.Models.EFT.Game.Spawning;
using Fuyu.Platform.Common.Models.EFT.Locations;

namespace Fuyu.Platform.Common.Models
{
    [DataContract]
    public struct Location
    {
        [DataMember]
        public bool Enabled;

        [DataMember]
        public bool EnableCoop;

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
        public WildSpawnWave[] waves;

        [DataMember]
        public ItemLimit[] limits;

        [DataMember]
        public int AveragePlayTime;

        [DataMember]
        public int AveragePlayerLevel;

        [DataMember]
        public int EscapeTimeLimit;

        [DataMember]
        public int EscapeTimeLimitCoop;

        [DataMember]
        public string Rules;

        [DataMember]
        public bool IsSecret;

        // TODO: proper type & find the value within the assembly
        //[DataMember]
        //public object[] doors; //this does not exist within the assembly or i was simply unable to find it. 

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

        //[DataMember]
        //public MaxItemCount[] maxItemCountInLocation; //Doesnt exist.

        [DataMember]
        public BossSpawn[] BossLocationSpawn;

        //[DataMember(EmitDefaultValue = false)]
        //public MatchMakerWaitTime[] MatchMakerMinPlayersByWaitTime; //Doesnt exist. 

        [DataMember]
        public string Id;

        [DataMember]
        public string _Id;

        [DataMember]
        public LootItemPosition[] Loot;

        [DataMember]
        public BundleAddress[] Banners;
    }
}