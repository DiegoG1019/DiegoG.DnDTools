using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using DiegoG.DnDTools.InventoryManager;
using DiegoG.DnDTools.InventoryManager.Measures;

namespace DiegoG.DnDTools.Services.Common.Responses.Views;

public class EmbeddedItemDescriptionView
{
    public Guid ContainerId { get; set; }
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? EntityType { get; set; }
    public Money? BasePrice { get; set; }
    public Area? Size { get; set; }
    public Quantity? Amount { get; set; }
    public Mass? WeightPerItem { get; set; }
}

public class ItemDescriptionView : EmbeddedItemDescriptionView, IResponseModel<APIResponseCode>
{
    public DnDToolsEmbeddedInventoryView? Container { get; set; }
    public IEnumerable<string>? Tags { get; set; }

    public string? Notes { get; set; }
    public string? Description { get; set; }

    #region Weapon

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public string? WeaponCategory { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public string? DamageType { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public string? Range { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public string? ThrownRange { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public string? DamageThrow { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public string? GraspType { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public string? VersatileDamage { get; set; }

    #endregion

    #region Armor

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public string? ArmorCategory { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public string? ArmorClass { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public string? Requirement { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public string? Detriments { get; set; }

    #endregion

    #region ContainerItem

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public Mass? WeightCapacity { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public Area? AreaCapacity { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public Quantity? QuantityCapacity { get; set; }

    #region FillableContainerItem

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public double? Fill { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public Mass? WeightWhenFull { get; set; }

    #endregion

    #endregion

    public APIResponseCode APIResponseCode => APIResponseCodeEnum.ItemDescriptionView;
}
