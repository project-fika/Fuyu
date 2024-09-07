using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemFireMode
    {
        [DataMember]
        public string FireMode;
    }
}