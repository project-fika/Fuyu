using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Locations
{
    [DataContract]
    public struct Transit
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