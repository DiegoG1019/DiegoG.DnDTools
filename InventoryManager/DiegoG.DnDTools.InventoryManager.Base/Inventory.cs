using System.Collections;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using DiegoG.DnDTools.InventoryManager.Measures;
using MessagePack;
using MessagePack.Formatters;
namespace DiegoG.DnDTools.InventoryManager;

public class Inventory : IDnDEntityContainer<ItemDescription>
{
    public Inventory() : this(new HashSet<ItemDescription>()) { }

    protected Inventory(ISet<ItemDescription> set) 
    {
        Items = set ?? throw new ArgumentNullException(nameof(set));
    }

    public virtual ISet<ItemDescription> Items { get; set; }

    public virtual ContainerItemDescription? Container { get; set; }

    public virtual int? MaximumItems { get; set; }

    public virtual Mass StoredItemsTotalMass { get; }

    public double StoredItemsTotalStandardWeight => StoredItemsTotalMass.ToStandard();

    public virtual Money StoredItemsTotalValue { get; }

    public virtual bool? IsOverburdened
    {
        get
        {
            var con = Container;
            return con is null
                ? null
                : StoredItemsTotalStandardWeight > con.WeightCapacity?.ToStandard() || MaximumItems > Items.Count;
        }
    }

    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public string? Notes { get; set; }

    public virtual ICollection<string>? Tags { get; set; }
}
