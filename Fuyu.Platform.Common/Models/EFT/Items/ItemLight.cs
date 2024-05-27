using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Items
{
    [DataContract]
    public struct ItemLight
    {
        [DataMember]
        public bool IsActive;

        [DataMember]
        public int SelectedMode;
    }
}