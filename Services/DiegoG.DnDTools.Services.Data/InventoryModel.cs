using System.ComponentModel;
using DiegoG.DnDTools.InventoryManager;
using DiegoG.DnDTools.InventoryManager.Measures;

namespace DiegoG.DnDTools.Services.Data;

public class InventoryModel
  : IDnDEntityContainer<IBaseItemDescriptionModel>, IKeyed<InventoryModel, Guid>
{
    public Guid Id { get; set; }

    public Guid? ContainerItemId { get; set; }

    public virtual ContainerItemDescriptionModel? Container { get; set; }

    public Guid CharacterId { get; set; }
    public DnDToolsCharacter? Character { get; set; }

    public override int GetHashCode()
        => Id.GetHashCode();

    public ISet<IBaseItemDescriptionModel> Items { get; set; } = new HashSet<IBaseItemDescriptionModel>();

    public ISet<string>? Tags { get; set; }

    public virtual int? MaximumItems { get; set; }

    public Money StoredItemsTotalValue => new(
        StoredItemsTotalValueCopper,
        StoredItemsTotalValueSilver,
        StoredItemsTotalValueElectron,
        StoredItemsTotalValueGold,
        StoredItemsTotalValuePlatinum
    );

    public virtual double StoredItemsTotalStandardWeight { get; set; }

    public ushort StoredItemsTotalValueCopper { get; set; }
    public ushort StoredItemsTotalValueSilver { get; set; }
    public ushort StoredItemsTotalValueElectron { get; set; }
    public ushort StoredItemsTotalValueGold { get; set; }
    public ushort StoredItemsTotalValuePlatinum { get; set; }

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

    ICollection<string>? IDnDInfoObject.Tags
    {
        get => Tags;
        set => Tags = value is null ? null : value is ISet<string> set ? set : throw new ArgumentException("value must be an ISet<string>", nameof(value));
    }

    ContainerItemDescription? IDnDEntityContainer<IBaseItemDescriptionModel>.Container
    {
        get => Container;
        set => Container = value is null ? null : value is ContainerItemDescriptionModel set ? set : throw new ArgumentException("value must be an ContainerItemDescriptionModel", nameof(value));
    }
}
