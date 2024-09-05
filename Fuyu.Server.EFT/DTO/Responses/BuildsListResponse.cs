using System.Runtime.Serialization;
using Fuyu.Server.EFT.DTO.Templates;

namespace Fuyu.Server.EFT.DTO.Responses
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