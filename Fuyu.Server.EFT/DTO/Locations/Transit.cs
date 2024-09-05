using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Locations
{
    [DataContract]
    public class Transit
    {
        [DataMember]
        public int id;

        [DataMember]
        public bool active;

        [DataMember]
        public string name;

        [DataMember]
        public string location;

        [DataMember]
        public string description;

        [DataMember]
        public int activateAfterSec;

        [DataMember]
        public string target;

        [DataMember]
        public int time;

        [DataMember]
        public string conditions;
    }
}