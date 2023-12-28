using DiegoG.DnDTools.InventoryManager.ReadOnly;

namespace DiegoG.DnDTools.InventoryManager;

public class ArmorItemDescription : ItemDescription
{
    public virtual string? ArmorCategory { get; set; }
    public virtual string? ArmorClass { get; set; }
    public virtual string? Requirement { get; set; }
    public virtual string? Detriments { get; set; }

    public override ReadOnlyArmorItemDescription ToReadOnly()
        => new(this);
}
