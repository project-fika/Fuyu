using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemKey
    {
        [DataMember]
        public int NumberOfUsages;
    }
}