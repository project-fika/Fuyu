using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Locations
{
    [DataContract]
    public struct BotLocationModifier
    {
        [DataMember]
        public float AccuracySpeed;
        
        [DataMember]
        public float Scattering;

        [DataMember]
        public float GainSight;

        [DataMember]
        public float MarksmanAccuratyCoef;

        [DataMember]
        public float VisibleDistance;

        [DataMember]
        public float DistToPersueAxemanCoef;

        [DataMember]
        public float DistToSleep;

        [DataMember]
        public float DistToActivate;

        [DataMember]
        public float MagnetPower;        

        [DataMember]
        public float KhorovodChance;
    }
}