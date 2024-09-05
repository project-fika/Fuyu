using System.Runtime.Serialization;
using Fuyu.Backend.EFT.DTO.Templates;

namespace Fuyu.Backend.EFT.DTO.Responses
{
    [DataContract]
    public class BuildsListResponse
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