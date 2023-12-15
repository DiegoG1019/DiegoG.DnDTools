using DiegoG.DnDTools.InventoryManager.Measures;

namespace DiegoG.DnDTools.InventoryManager;

public class ItemDescription : DnDEntity
{
    public virtual Money? BasePrice { get; set; }
    public virtual Quantity? Amount { get; set; }
    public virtual Mass? WeightPerItem { get; set; }
    public virtual Area? Size { get; set; }
    public virtual Mass? TotalWeight
        => Amount is Quantity q && WeightPerItem is Mass w
        ? new(q.Value * w.Value, w.Unit)
        : null;

    public override ItemDescription DeepClone() 
        => (ItemDescription)base.DeepClone();
}
