using System.Xml.Linq;
using DiegoG.DnDTools.InventoryManager.Measures;
using DiegoG.DnDTools.InventoryManager.ReadOnly;

namespace DiegoG.DnDTools.InventoryManager;

public class ItemDescription : DnDEntity
{
    public virtual string? Category { get; set; }
    public virtual Money? BasePrice { get; set; }
    public virtual Quantity? Amount { get; set; }
    public virtual Mass? WeightPerItem { get; set; }
    public virtual Area? Size { get; set; }
    public virtual Mass? TotalWeight
        => Amount is Quantity q && WeightPerItem is Mass w
        ? new(q.Value * w.Value, w.Unit)
        : null;

    public ItemDescription(
        Guid id,
        string? name,
        string? description,
        string? notes,
        ISet<string>? tags,
        string entityType,
        Guid containerInventoryId,
        ushort? basePriceCopper,
        ushort? basePriceSilver,
        ushort? basePriceElectron,
        ushort? basePriceGold,
        ushort? basePricePlatinum,
        AreaUnit? sizeUnit,
        double? sizeValue,
        MassUnit? weightPerItemUnit,
        double? weightPerItemValue,
        double? standardWeightPerItemValue,
        QuantityUnit? amountUnit,
        double? amountValue
    )
    {
        Id = id;
        ContainerInventoryId = containerInventoryId;
        BasePrice = GetMoney(
            basePriceCopper,
            basePriceSilver,
            basePriceElectron,
            basePriceGold,
            basePricePlatinum
        );
        Amount = GetQuantityOrNull(amountValue, amountUnit);
        WeightPerItem = GetMassFromStandardOrNull(standardWeightPerItemValue, weightPerItemUnit);
        Size = GetAreaOrNull(sizeValue, sizeUnit);
        Name = name;
        Description = description;
        Notes = notes;
        Tags = tags;
        EntityType = entityType ?? throw new ArgumentNullException(nameof(entityType));
    }

    public Guid Id { get; set; }

    public Guid ContainerInventoryId { get; set; }
    public Inventory? ContainerInventory { get; set; }

    public override int GetHashCode()
        => Id.GetHashCode();

    public override ISet<string>? Tags => (ISet<string>?)base.Tags;

    public MassUnit? WeightPerItemUnit => WeightPerItem?.Unit;
    public double? StandardWeightPerItemValue => WeightPerItem?.ToStandard();

    public ushort? BasePriceCopper => BasePrice?.Copper;
    public ushort? BasePriceSilver => BasePrice?.Silver;
    public ushort? BasePriceElectron => BasePrice?.Electron;
    public ushort? BasePriceGold => BasePrice?.Gold;
    public ushort? BasePricePlatinum => BasePrice?.Platinum;

    public AreaUnit? SizeUnit => Size?.Unit;
    public double? SizeValue => Size?.Value;

    public QuantityUnit? AmountUnit => Amount?.Unit;
    public double? AmountValue => Amount?.Value;

    public override ItemDescription DeepClone() 
        => (ItemDescription)base.DeepClone();

    public virtual ReadOnlyItemDescription ToReadOnly()
        => new(this);

    internal static Money? GetMoney(ushort? cp, ushort? sp, ushort? ep, ushort? gp, ushort? pp)
        => cp.HasValue && sp.HasValue && ep.HasValue && gp.HasValue && pp.HasValue
            ? new(cp.Value, sp.Value, ep.Value, gp.Value, pp.Value)
            : null;

    internal static Mass? GetMassOrNull(double? value, MassUnit? unit)
        => value.HasValue && unit.HasValue ? new(value.Value, unit.Value) : null;

    internal static Mass? GetMassFromStandardOrNull(double? value, MassUnit? unit)
        => value.HasValue && unit.HasValue ? Mass.FromStandard(value.Value, unit.Value) : null;

    internal static Area? GetAreaOrNull(double? value, AreaUnit? unit)
        => value.HasValue && unit.HasValue ? new(value.Value, unit.Value) : null;

    internal static Quantity? GetQuantityOrNull(double? value, QuantityUnit? unit)
        => value.HasValue && unit.HasValue ? new(value.Value, unit.Value) : null;
}
