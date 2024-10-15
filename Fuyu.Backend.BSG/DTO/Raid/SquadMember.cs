using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Raid
{
    [DataContract]
    public class SquadMember
    {
        [DataMember]
        public string _id;

        [DataMember]
        public int aid;

        [DataMember]
        public SquadInfo Info;

        [DataMember]
        public bool isLeader;

        [DataMember]
        public bool isReady;

        // TODO: proper type
        [DataMember]
        public object PlayerVisualRepresentation;
    }
}