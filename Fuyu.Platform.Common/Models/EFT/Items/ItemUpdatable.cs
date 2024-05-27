using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Items
{
    [DataContract]
    public struct ItemUpdatable
    {
        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemFireMode? FireMode;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemRepairable? Repairable;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemFoldable? Foldable;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemSight? Sight;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemLight? Light;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemMedKit? MedKit;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public bool? SpawnedInSession;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public int? StackObjectsCount;
    }
}