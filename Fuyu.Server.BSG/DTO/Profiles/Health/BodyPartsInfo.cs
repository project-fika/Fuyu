using System.Runtime.Serialization;

namespace Fuyu.Server.BSG.DTO.Profiles.Health
{
    [DataContract]
    public class BodyPartInfo
    {
        [DataMember]
        public BodyPart Head;

        [DataMember]
        public BodyPart Chest;

        [DataMember]
        public BodyPart Stomach;

        [DataMember]
        public BodyPart LeftArm;

        [DataMember]
        public BodyPart RightArm;

        [DataMember]
        public BodyPart LeftLeg;

        [DataMember]
        public BodyPart RightLeg;
    }
}