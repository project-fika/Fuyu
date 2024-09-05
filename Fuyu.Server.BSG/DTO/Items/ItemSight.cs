using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Items
{
    [DataContract]
    public class ItemSight
    {
        [DataMember]
        public int[] ScopesCurrentCalibPointIndexes;

        [DataMember]
        public int[] ScopesSelectedModes;

        [DataMember]
        public int SelectedScope;
    }
}