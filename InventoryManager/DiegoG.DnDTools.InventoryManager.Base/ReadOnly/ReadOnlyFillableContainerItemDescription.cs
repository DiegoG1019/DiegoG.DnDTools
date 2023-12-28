using DiegoG.DnDTools.InventoryManager.Measures;

namespace DiegoG.DnDTools.InventoryManager.ReadOnly;

public record ReadOnlyFillableContainerItemDescription(
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
    Quantity? QuantityCapacity,
    Mass? WeightWhenFull
) : ReadOnlyContainerItemDescription(
    Name,
    Description,
    Notes,
    Category,
    BasePrice,
    Amount,
    WeightPerItem,
    Size,
    Tags,
    WeightCapacity,
    AreaCapacity,
    QuantityCapacity
)
{
    public ReadOnlyFillableContainerItemDescription(FillableContainerItemDescription description) : this(
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
        description.QuantityCapacity,
        description.WeightWhenFull
    )
    { }

    public ReadOnlyFillableContainerItemDescription() : this(null, null, null, null, null, null, null, null, null, null, null, null, null) { }

    public override ItemDescription FillItemDescription(ItemDescription? description = null)
        => description is FillableContainerItemDescription wdesc
            ? FillItemDescription(wdesc)
            : description is ContainerItemDescription cdesc
                ? base.FillItemDescription(cdesc)
                : base.FillItemDescription(description);

    public FillableContainerItemDescription FillItemDescription(FillableContainerItemDescription? description = null)
    {
        description = (FillableContainerItemDescription)base.FillItemDescription(description);
        description.WeightWhenFull = WeightWhenFull;
        return description;
    }
}
