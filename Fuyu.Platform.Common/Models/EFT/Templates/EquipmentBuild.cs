using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Items;

namespace Fuyu.Platform.Common.Models.EFT.Templates
{
    [DataContract]
    public struct EquipmentBuild
    {
        [DataMember]
        public string Id;

        [DataMember]
        public string Name;

        [DataMember]
        public ItemInstance[] Items;

        [DataMember]
        public string Root;

        [DataMember]
        public string BuildType;

        [DataMember]
        public EEquipmentBuildType type;
    }
}