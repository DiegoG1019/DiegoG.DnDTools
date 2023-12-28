using DiegoG.DnDTools.InventoryManager;
using DiegoG.DnDTools.InventoryManager.Measures;

namespace DiegoG.DnDTools.Services.Data;

public class FillableContainerItemDescriptionModel : FillableContainerItemDescription, IBaseItemDescriptionModel
{
    public FillableContainerItemDescriptionModel(
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
        double? amountValue,

        AreaUnit? areaCapacityUnit,
        double? areaCapacityValue,
        MassUnit? weightCapacityUnit,
        double? weightCapacityValue,
        QuantityUnit? quantityCapacityUnit,
        double? quantityCapacityValue,

        MassUnit? weightWhenFullUnit,
        double? weightWhenFullValue
    )
    {
        Id = id;
        ContainerInventoryId = containerInventoryId;
        BasePrice = IBaseItemDescriptionModel.GetMoney(
            basePriceCopper,
            basePriceSilver,
            basePriceElectron,
            basePriceGold,
            basePricePlatinum
        );

        Amount = IBaseItemDescriptionModel.GetQuantityOrNull(amountValue, amountUnit);
        WeightPerItem = IBaseItemDescriptionModel.GetMassFromStandardOrNull(standardWeightPerItemValue, weightPerItemUnit);
        Size = IBaseItemDescriptionModel.GetAreaOrNull(sizeValue, sizeUnit);

        QuantityCapacity = IBaseItemDescriptionModel.GetQuantityOrNull(quantityCapacityValue, quantityCapacityUnit);
        WeightCapacity = IBaseItemDescriptionModel.GetMassOrNull(weightCapacityValue, weightCapacityUnit);
        AreaCapacity = IBaseItemDescriptionModel.GetAreaOrNull(areaCapacityValue, areaCapacityUnit);

        WeightWhenFull = IBaseItemDescriptionModel.GetMassOrNull(weightWhenFullValue, weightWhenFullUnit);

        Name = name;
        Description = description;
        Notes = notes;
        Tags = tags;
        EntityType = entityType ?? throw new ArgumentNullException(nameof(entityType));
    }

    public Guid Id { get; set; }

    public Guid ContainerInventoryId { get; set; }
    public InventoryModel? ContainerInventory { get; set; }

    public override int GetHashCode()
        => Id.GetHashCode();

    public override ISet<string>? Tags => (ISet<string>?)base.Tags;

    public override double Fill
    {
        get => base.Fill;
        set
        {
            if (WeightWhenFull is not Mass m)
                return;
            WeightPerItem = new(m.Value * double.Clamp(value, 0, 1), m.Unit);
        }
    }

    public ushort? BasePriceCopper => BasePrice?.Copper;
    public ushort? BasePriceSilver => BasePrice?.Silver;
    public ushort? BasePriceElectron => BasePrice?.Electron;
    public ushort? BasePriceGold => BasePrice?.Gold;
    public ushort? BasePricePlatinum => BasePrice?.Platinum;

    public AreaUnit? AreaCapacityUnit => AreaCapacity?.Unit;
    public double? AreaCapacityValue => AreaCapacity?.Value;

    public QuantityUnit? QuantityCapacityUnit => QuantityCapacity?.Unit;
    public double? QuantityCapacityValue => QuantityCapacity?.Value;

    public MassUnit? WeightCapacityUnit => WeightCapacity?.Unit;
    public double? StandardWeightCapacityValue => WeightCapacity?.ToStandard();

    public MassUnit? WeightPerItemUnit => WeightPerItem?.Unit;
    public double? StandardWeightPerItemValue => WeightPerItem?.ToStandard();

    public AreaUnit? SizeUnit => Size?.Unit;
    public double? SizeValue => Size?.Value;

    public QuantityUnit? AmountUnit => Amount?.Unit;
    public double? AmountValue => Amount?.Value;
}
