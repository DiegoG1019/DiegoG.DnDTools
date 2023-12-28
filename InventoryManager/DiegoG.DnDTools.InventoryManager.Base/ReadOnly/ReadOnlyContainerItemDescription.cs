using DiegoG.DnDTools.InventoryManager.Measures;

namespace DiegoG.DnDTools.InventoryManager.ReadOnly;

public record ReadOnlyContainerItemDescription(
    string? Name, 
    string? Description, 
    string? Notes, 
    string? Category, 
    Money? BasePrice, 
    Quantity? Amount, 
    Mass? WeightPerItem, 
    Area? Size, 
    IEnumerable<string>? Tags, 
    Mass? WeightCapacity, 
    Area? AreaCapacity, 
    Quantity? QuantityCapacity
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
    public ReadOnlyContainerItemDescription(ContainerItemDescription description) : this(
        description.Name,
        description.Description,
        description.Notes,
        description.Category,
        description.BasePrice,
        description.Amount,
        description.WeightPerItem,
        description.Size,
        description.Tags,
        description.WeightCapacity,
        description.AreaCapacity,
        description.QuantityCapacity
    )
    { }

    public ReadOnlyContainerItemDescription() : this(null, null, null, null, null, null, null, null, null, null, null, null) { }

    public override ItemDescription FillItemDescription(ItemDescription? description = null)
        => description is ContainerItemDescription wdesc ? FillItemDescription(wdesc) : base.FillItemDescription(description);

    public ContainerItemDescription FillItemDescription(ContainerItemDescription? description = null)
    {
        description = (ContainerItemDescription)base.FillItemDescription(description);
        description.WeightCapacity = WeightCapacity;
        description.AreaCapacity = AreaCapacity;
        description.QuantityCapacity = QuantityCapacity;
        return description;
    }
}
