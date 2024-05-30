using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT
{
    [DataContract]
    public class EffectTimer
    {
            [DataMember]
            public float Time = -1f;

            [DataMember]
            public object ExtraData;
    }
}