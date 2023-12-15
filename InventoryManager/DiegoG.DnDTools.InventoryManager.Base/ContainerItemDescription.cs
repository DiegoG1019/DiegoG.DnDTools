using DiegoG.DnDTools.InventoryManager.Measures;

namespace DiegoG.DnDTools.InventoryManager;

public class ContainerItemDescription : ItemDescription
{
    public Mass? WeightCapacity { get; set; }
    public Area? AreaCapacity { get; set; }
    public Quantity? QuantityCapacity { get; set; }

    public override ContainerItemDescription DeepClone() 
        => (ContainerItemDescription)base.DeepClone();
}
