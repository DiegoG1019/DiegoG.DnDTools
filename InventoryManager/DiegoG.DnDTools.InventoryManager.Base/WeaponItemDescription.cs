using DiegoG.DnDTools.InventoryManager.ReadOnly;

namespace DiegoG.DnDTools.InventoryManager;

public class WeaponItemDescription : ItemDescription
{
    public virtual string? WeaponCategory { get; set; }
    public virtual string? DamageType { get; set; }
    public virtual string? DamageThrow { get; set; }
    public virtual string? Range { get; set; }
    public virtual string? ThrownRange { get; set; }
    public virtual string? MunitionType { get; set; }
    public virtual string? GraspType { get; set; }
    public virtual string? VersatileDamage { get; set; }

    public override ReadOnlyWeaponItemDescription ToReadOnly() => new(this);
}
