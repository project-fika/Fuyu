using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Common
{
    public enum ERepairBuffType
    {
        [DataMember(Name = "WeaponSpread")]
        WeaponSpread,
        [DataMember(Name = "DamageReduction")]
        DamageReduction,
        [DataMember(Name = "MalfunctionProtections")]
        MalfunctionProtections,
        [DataMember(Name = "WeaponDamage")]
        WeaponDamage,
        [DataMember(Name = "ArmorEfficiency")]
        ArmorEfficiency,
        [DataMember(Name = "DurabilityImprovement")]
        DurabilityImprovement
    }
}