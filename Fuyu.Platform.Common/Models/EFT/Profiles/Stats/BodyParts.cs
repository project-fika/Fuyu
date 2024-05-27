using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Profiles.Stats
{
    [DataContract]
    public struct BodyParts
    {
        // TODO: proper type
        [DataMember]
        public object[] Head;

        // TODO: proper type
        [DataMember]
        public object[] Chest;

        // TODO: proper type
        [DataMember]
        public object[] Stomach;

        // TODO: proper type
        [DataMember]
        public object[] LeftArm;

        // TODO: proper type
        [DataMember]
        public object[] RightArm;

        // TODO: proper type
        [DataMember]
        public object[] LeftLeg;

        // TODO: proper type
        [DataMember]
        public object[] RightLeg;
    }
}