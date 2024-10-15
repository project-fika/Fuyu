using System.Runtime.Serialization;
using Fuyu.Backend.BSG.DTO.Templates;

namespace Fuyu.Backend.BSG.DTO.Responses
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