using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemSightComponent
    {
        [DataMember]
        public int[] ScopesCurrentCalibPointIndexes;

        [DataMember]
        public int[] ScopesSelectedModes;

        [DataMember]
        public float ScopeZoomValue;

        [DataMember]
        public int SelectedScope;
    }
}