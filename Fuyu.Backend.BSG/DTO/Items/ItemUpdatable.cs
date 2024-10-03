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
        public ItemCultistAmulet CultistAmulet;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemBuff Buff;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemDogtag Dogtag;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemFaceShield FaceShield;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemFoodDrink FoodDrink;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemKey Key;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemLockable Lockable;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemMap Map;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemRecodable Recodable;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemRepairKit RepairKit;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemSideEffect SideEffect;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemTag Tag;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public bool? SpawnedInSession;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public int? StackObjectsCount;
    }
}