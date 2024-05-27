using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Common
{
    [DataContract]
    public struct Vector3
    {
        [DataMember]
        public float x;

        [DataMember]
        public float y;

        [DataMember]
        public float z;
    }
}