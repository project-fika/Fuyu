using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Items
{
    [DataContract]
    public class ItemKeyComponent
    {
        [DataMember]
        public int NumberOfUsages;
    }
}