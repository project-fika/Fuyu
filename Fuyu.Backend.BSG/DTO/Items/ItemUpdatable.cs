using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Items
{
    [DataContract]
    public class ItemUpdatable
    {
        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemFireModeComponent FireMode;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemRepairableComponent Repairable;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemFoldableComponent Foldable;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemSightComponent Sight;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemLightComponent Light;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemMedKitComponent MedKit;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemCultistAmuletComponent CultistAmulet;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemBuffComponent Buff;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemDogtagComponent Dogtag;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemFaceShieldComponent FaceShield;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemFoodDrinkComponent FoodDrink;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemKeyComponent Key;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemLockableComponent Lockable;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemMapComponent Map;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemRecodableComponent Recodable;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemRepairKitComponent RepairKit;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemSideEffectComponent SideEffect;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public ItemTagComponent Tag;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public bool? SpawnedInSession;

        // does not emit when 'null'
        [DataMember(EmitDefaultValue = false)]
        public int? StackObjectsCount;
    }
}