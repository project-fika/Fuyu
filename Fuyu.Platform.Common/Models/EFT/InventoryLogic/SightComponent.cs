using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Items
{
    [DataContract]
    public struct SightComponent
    {
        [DataMember]
        public int[] ScopesCurrentCalibPointIndexes;

        [DataMember]
        public int[] ScopesSelectedModes;

        [DataMember]
        public int SelectedScope;
    }
}