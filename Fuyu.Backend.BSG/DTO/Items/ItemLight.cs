using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemLight
    {
        [DataMember]
        public bool IsActive;

        [DataMember]
        public int SelectedMode;
    }
}