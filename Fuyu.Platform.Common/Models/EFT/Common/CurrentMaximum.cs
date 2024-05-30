using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Common
{
    [DataContract]
    public struct CurrentMaximum<T>
    {
        [DataMember]
        public T Current;

        [DataMember]
        public T Maximum;

        [DataMember]
        public T Minimum;

        [DataMember]
        public T OverDamageReceivedMultiplier;

        [DataMember]
        public T EnvironmentDamageMultiplier;
    }
}