using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Locations
{
    [DataContract]
    public class BotLocationModifier
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