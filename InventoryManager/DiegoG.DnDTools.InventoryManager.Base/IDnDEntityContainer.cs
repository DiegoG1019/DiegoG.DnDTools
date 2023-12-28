using DiegoG.DnDTools.InventoryManager.Measures;
namespace DiegoG.DnDTools.InventoryManager;

public interface IDnDEntityContainer<T> : IDnDInfoObject
    where T : IDnDInfoObject
{
    public ISet<T> Items { get; }

    public ContainerItemDescription? Container { get; set; }

    public int? MaximumItems { get; set; }

    public double StoredItemsTotalStandardWeight { get; }

    public Money StoredItemsTotalValue { get; }

    public bool? IsOverburdened
    {
        get
        {
            var con = Container;
            return con is null
                ? null
                : StoredItemsTotalStandardWeight > con.WeightCapacity?.ToStandard() || MaximumItems > Items.Count;
        }
    }
}
