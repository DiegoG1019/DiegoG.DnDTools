using DiegoG.DnDTools.InventoryManager;
using DiegoG.DnDTools.InventoryManager.Measures;

namespace DiegoG.DnDTools.Services.Data;

public class ArmorItemDescriptionModel : ArmorItemDescription, IBaseItemDescriptionModel
{
    public ArmorItemDescriptionModel(
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

        string? armorCategory,
        string? armorClass,
        string? requirement,
        string? detriments
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
        Name = name;
        Description = description;
        Notes = notes;
        Tags = tags;
        EntityType = entityType ?? throw new ArgumentNullException(nameof(entityType));

        ArmorCategory = armorCategory;
        ArmorClass = armorClass;
        Requirement = requirement;
        Detriments = detriments;
    }

    public Guid Id { get; set; }

    public Guid ContainerInventoryId { get; set; }
    public InventoryModel? ContainerInventory { get; set; }

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
}
