using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Templates;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct BuildsListResponse
    {
        [DataMember]
        public EquipmentBuild[] equipmentBuild;

        [DataMember]
        public WeaponBuildTemplate[] weaponBuilds;

        [DataMember]
        public MagazineBuildTemplate[] magazineBuilds;
    }
}