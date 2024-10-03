using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemUpdatable
    {
        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemFireMode FireMode;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemRepairable Repairable;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemFoldable Foldable;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemSight Sight;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemLight Light;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemMedKit MedKit;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public bool? SpawnedInSession;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public int? StackObjectsCount;
    }
}