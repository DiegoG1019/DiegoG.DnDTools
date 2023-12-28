using DiegoG.DnDTools.InventoryManager.Measures;

namespace DiegoG.DnDTools.InventoryManager.ReadOnly;

public record ReadOnlyArmorItemDescription(
    string? Name, 
    string? Description, 
    string? Notes, 
    string? Category, 
    Money? BasePrice, 
    Quantity? Amount, 
    Mass? WeightPerItem, 
    Area? Size, 
    IEnumerable<string>? Tags, 
    string? ArmorCategory, 
    string? ArmorClass, 
    string? Requirement, 
    string? Detriments
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
    public ReadOnlyArmorItemDescription(ArmorItemDescription description) : this(
        description.Name,
        description.Description,
        description.Notes,
        description.Category,
        description.BasePrice,
        description.Amount,
        description.WeightPerItem,
        description.Size,
        description.Tags,
        description.ArmorCategory,
        description.ArmorClass,
        description.Requirement,
        description.Detriments
    )
    { }

    public ReadOnlyArmorItemDescription() : this(null, null, null, null, null, null, null, null, null, null, null, null, null) { }

    public override ItemDescription FillItemDescription(ItemDescription? description = null)
        => description is ArmorItemDescription wdesc ? FillItemDescription(wdesc) : base.FillItemDescription(description);

    public ArmorItemDescription FillItemDescription(ArmorItemDescription? description = null)
    {
        description = (ArmorItemDescription)base.FillItemDescription(description);
        description.ArmorCategory = ArmorCategory;
        description.ArmorClass = ArmorClass;
        description.Requirement = Requirement;
        description.Detriments = Detriments;
        return description;
    }
}
