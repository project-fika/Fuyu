using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Items
{
    [DataContract]
    public class ItemFireMode
    {
        [DataMember]
        public string FireMode;
    }
}