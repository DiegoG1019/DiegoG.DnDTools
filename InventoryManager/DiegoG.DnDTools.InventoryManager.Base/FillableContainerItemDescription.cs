using DiegoG.DnDTools.InventoryManager.Measures;

namespace DiegoG.DnDTools.InventoryManager;

public class FillableContainerItemDescription : ContainerItemDescription
{
    public virtual double Fill
    {
        get => WeightPerItem is Mass wi && WeightWhenFull is Mass wf ? wi.ToStandard() / wf.ToStandard() : 0;
        set
        {
            if (WeightWhenFull is not Mass m)
                throw new InvalidOperationException("Cannot set the fill of an item if its WeightWhenFull is not set");
            WeightPerItem = new(m.Value * double.Clamp(value, 0, 1), m.Unit);
        }
    }

    public virtual Mass? WeightWhenFull { get; set; }

    public override FillableContainerItemDescription DeepClone() 
        => (FillableContainerItemDescription)base.DeepClone();
}
