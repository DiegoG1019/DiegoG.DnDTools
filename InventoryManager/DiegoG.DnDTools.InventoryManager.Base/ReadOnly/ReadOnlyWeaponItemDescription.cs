using DiegoG.DnDTools.InventoryManager.Measures;

namespace DiegoG.DnDTools.InventoryManager.ReadOnly;

public record ReadOnlyWeaponItemDescription(
    string? Name,
    string? Description,
    string? Notes,
    string? Category,
    Money? BasePrice,
    Quantity? Amount,
    Mass? WeightPerItem,
    Area? Size,
    IEnumerable<string>? Tags,
    string? WeaponCategory,
    string? DamageType,
    string? DamageThrow,
    string? MunitionType,
    string? Range,
    string? GraspType,
    string? ThrownRange,
    string? VersatileDamage
) : ReadOnlyItemDescription(
    Name,
    Description,
    Notes,
    Category,
    BasePrice,
    Amount,
    WeightPerItem,
    Size,
    Tags
)
{
    public ReadOnlyWeaponItemDescription(WeaponItemDescription description) : this(
        description.Name,
        description.Description,
        description.Notes,
        description.Category,
        description.BasePrice,
        description.Amount,
        description.WeightPerItem,
        description.Size,
        description.Tags,
        description.WeaponCategory,
        description.DamageType,
        description.DamageThrow,
        description.MunitionType,
        description.Range,
        description.GraspType,
        description.ThrownRange,
        description.VersatileDamage
    )
    { }

    public ReadOnlyWeaponItemDescription() 
        : this(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null) { }

    public override ItemDescription FillItemDescription(ItemDescription? description = null) 
        => description is WeaponItemDescription wdesc ? FillItemDescription(wdesc) : base.FillItemDescription(description);

    public WeaponItemDescription FillItemDescription(WeaponItemDescription? description = null)
    {
        description = (WeaponItemDescription)base.FillItemDescription(description);
        description.WeaponCategory = WeaponCategory;
        description.DamageType = DamageType;
        description.DamageThrow = DamageThrow;
        description.MunitionType = MunitionType;
        description.Range = Range;
        description.GraspType = GraspType;
        description.ThrownRange = ThrownRange;
        description.VersatileDamage = VersatileDamage;
        return description;
    }
}
