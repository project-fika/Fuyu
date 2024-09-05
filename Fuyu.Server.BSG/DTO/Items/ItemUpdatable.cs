using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Items
{
    [DataContract]
    public class ItemUpdatable
    {
        // emits when 'null'
        [DataMember(EmitDefaultValue = true)]
        public ItemFireMode FireMode;

        // emits when 'null'
        [DataMember(EmitDefaultValue = true)]
        public ItemRepairable Repairable;

        // emits when 'null'
        [DataMember(EmitDefaultValue = true)]
        public ItemFoldable Foldable;

        // emits when 'null'
        [DataMember(EmitDefaultValue = true)]
        public ItemSight Sight;

        // emits when 'null'
        [DataMember(EmitDefaultValue = true)]
        public ItemLight Light;

        // emits when 'null'
        [DataMember(EmitDefaultValue = true)]
        public ItemMedKit MedKit;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public bool? SpawnedInSession;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public int? StackObjectsCount;
    }
}