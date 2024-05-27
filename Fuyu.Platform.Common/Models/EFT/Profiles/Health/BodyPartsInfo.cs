using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Profiles.Health
{
    [DataContract]
    public struct BodyPartInfo
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