using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Common
{
    [DataContract]
    public class CurrentMaximum<T>
    {
        [DataMember]
        public T Current;

        [DataMember]
        public T Maximum;
    }
}