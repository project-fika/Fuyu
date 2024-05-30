using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.InventoryLogic;
using Fuyu.Platform.Common.Models.EFT.Items;

namespace Fuyu.Platform.Common.Models
{
    [DataContract]
    public struct ItemUpdatable
    {
        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public FireModeComponent? FireMode;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public RepairableComponent? Repairable;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public FoldableComponent? Foldable;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public SightComponent? Sight;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public LightComponent? Light;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public MedKitComponent? MedKit;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public bool? SpawnedInSession;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public int? StackObjectsCount;
    }
}