using DiegoG.DnDTools.InventoryManager.Measures;
namespace DiegoG.DnDTools.InventoryManager;

public class InventoryBuffer(
    string name, 
    IEnumerable<string>? tags, 
    string format, 
    IEnumerable<DnDEntityBuffer> data,
    int? maximumItems, 
    Mass storedItemsTotalMass, 
    Money storedItemsTotalValue, 
    bool? isOverburdened, 
    string? description, 
    string? notes, 
    int count
) : DnDEntityCollectionBuffer(name, tags, format, data)
{
    public int? MaximumItems { get; } = maximumItems;
    public Mass StoredItemsTotalMass { get; } = storedItemsTotalMass;
    public Money StoredItemsTotalValue { get; } = storedItemsTotalValue;
    public bool? IsOverburdened { get; } = isOverburdened;
    public string? Description { get; } = description;
    public string? Notes { get; } = notes;
    public int Count { get; } = count;
}
