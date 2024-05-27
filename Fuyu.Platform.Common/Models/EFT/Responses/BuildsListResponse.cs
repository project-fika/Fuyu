using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Templates;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct BuildsListResponse
    {
        [DataMember]
        public EquipmentBuild[] equipmentBuild;

        // TODO: proper type
        [DataMember]
        public object[] weaponBuilds;

        // TODO: proper type
        [DataMember]
        public object[] magazineBuilds;
    }
}