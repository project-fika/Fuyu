using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Common
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