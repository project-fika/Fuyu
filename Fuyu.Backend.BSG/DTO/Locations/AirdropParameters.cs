using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Locations
{
    [DataContract]
    public class AirdropParameters
    {
        [DataMember]
        public string id;

        [DataMember]
        public int PlaneAirdropStartMin;

        [DataMember]
        public int PlaneAirdropStartMax;

        [DataMember]
        public int PlaneAirdropEnd;

        [DataMember]
        public float PlaneAirdropChance;

        [DataMember]
        public int PlaneAirdropMax;

        [DataMember]
        public int PlaneAirdropCooldownMin;

        [DataMember]
        public int PlaneAirdropCooldownMax;

        [DataMember]
        public int AirdropPointDeactivateDistance;

        [DataMember]
        public int MinPlayersCountToSpawnAirdrop;

        [DataMember]
        public int UnsuccessfulTryPenalty;
    }
}