using DiegoG.DnDTools.InventoryManager.Measures;
using DiegoG.DnDTools.InventoryManager;
using DiegoG.DnDTools.Services.Utilities;

namespace DiegoG.DnDTools.Services.Common.Requests;

public class ItemDescriptionCreationModel
{
    public Guid Inventory { get; set; }
    public string? EntityType { get; set; }

    public Money? BasePrice { get; set; }
    public Area? Size { get; set; }
    public Mass? Weight { get; set; }
    public Quantity? Amount { get; set; }
    public IEnumerable<string>? Tags { get; set; }
    public string? Notes { get; set; }
    public string? Description { get; set; }
    public string? Name { get; set; }

    #region Weapon

    public string? WeaponCategory { get; set; }
    public string? DamageType { get; set; }
    public string? Range { get; set; }
    public string? ThrownRange { get; set; }
    public string? DamageThrow { get; set; }
    public string? GraspType { get; set; }
    public string? VersatileDamage { get; set; }

    #endregion

    #region Armor

    public string? ArmorCategory { get; set; }
    public string? ArmorClass { get; set; }
    public string? Requirement { get; set; }
    public string? Detriments { get; set; }

    #endregion

    #region ContainerItem

    public Mass? WeightCapacity { get; set; }
    public Area? AreaCapacity { get; set; }
    public Quantity? QuantityCapacity { get; set; }

    #region FillableContainerItem

    public double? Fill { get; set; }

    public Mass? WeightWhenFull { get; set; }

    #endregion

    #endregion
}
