using System.Collections;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using DiegoG.DnDTools.InventoryManager.Measures;
using MessagePack;
using MessagePack.Formatters;
namespace DiegoG.DnDTools.InventoryManager;

public sealed class Inventory : IDnDInfoObject, IReadOnlyCollection<ItemDescription>, ICollection<ItemDescription>
{
    private readonly HashSet<ItemDescription> items = [];

    public ContainerItemDescription? Container { get; set; }

    public int? MaximumItems { get; set; }

    public Mass StoredItemsTotalMass { get; }

    public Money StoredItemsTotalValue { get; }

    public bool? IsOverburdened
    {
        get
        {
            var con = Container;
            return con is null
                ? null
                : StoredItemsTotalMass.ToStandard() > con.WeightCapacity?.ToStandard() || MaximumItems > Count;
        }
    }

    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public string? Notes { get; set; }

    public ICollection<string>? Tags { get; set; }

    public void Add(ItemDescription item) => items.Add(item);

    public void Clear() => items.Clear();

    public bool Contains(ItemDescription item) => items.Contains(item);

    public void CopyTo(ItemDescription[] array, int arrayIndex) => items.CopyTo(array, arrayIndex);

    public bool Remove(ItemDescription item) => items.Remove(item);

    public int Count => items.Count;

    public bool IsReadOnly => false;

    public IEnumerator<ItemDescription> GetEnumerator() => items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();
}
