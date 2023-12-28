using System.Collections;
using System.Collections.Frozen;
using System.Xml.Linq;
using DiegoG.DnDTools.InventoryManager.Measures;
using DiegoG.DnDTools.Utilities;

namespace DiegoG.DnDTools.InventoryManager.ReadOnly;

public record ReadOnlyItemDescription(
    string? Name,
    string? Description,
    string? Notes,
    string? Category,
    Money? BasePrice,
    Quantity? Amount,
    Mass? WeightPerItem,
    Area? Size,
    IEnumerable<string>? Tags
) : IDnDFilterableInfo
{
    public ReadOnlyItemDescription() : this(null, null, null, null, null, null, null, null, null) { }

    public ReadOnlyItemDescription(ItemDescription description) : this(
        description.Name,
        description.Description,
        description.Notes,
        description.Category,
        description.BasePrice,
        description.Amount,
        description.WeightPerItem,
        description.Size,
        description.Tags
    ) { }

    public virtual ItemDescription FillItemDescription(ItemDescription? description = null)
    {
        description ??= new();
        description.Name = Name;
        description.Description = Description;
        description.Notes = Notes;
        description.Category = Category;
        description.BasePrice = BasePrice;
        description.Amount = Amount;
        description.WeightPerItem = WeightPerItem;
        description.Size = Size;
        description.Tags = Tags?.ToFrozenSet(CaseInsensitiveStringComparer.Instance);
        return description;
    }

    public Mass? TotalWeight
        => Amount is Quantity q && WeightPerItem is Mass w
        ? new(q.Value * w.Value, w.Unit)
        : null;
}
