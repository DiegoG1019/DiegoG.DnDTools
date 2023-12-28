//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DiegoG.DnDTools.InventoryManager;
//using DiegoG.DnDTools.InventoryManager.Measures;

//namespace DiegoG.DnDTools.Services.Data;
//public interface IBaseItemDescriptionModel
//    : IKeyed<IBaseItemDescriptionModel, Guid>, IDnDInfoObject, ICloneable
//{
//    public Guid ContainerInventoryId { get; set; }

//    public string? Category { get; set; }

//    public InventoryModel? ContainerInventory { get; set; }

//    public MassUnit? WeightPerItemUnit { get; }
//    public double? StandardWeightPerItemValue { get; }

//    public double? WeightPerItemValue => GetMassFromStandardOrNull(StandardWeightPerItemValue, WeightPerItemUnit)?.Value;

//    public ushort? BasePriceCopper { get; }
//    public ushort? BasePriceSilver { get; }
//    public ushort? BasePriceElectron { get; }
//    public ushort? BasePriceGold { get; }
//    public ushort? BasePricePlatinum { get; }

//    public AreaUnit? SizeUnit { get; }
//    public double? SizeValue { get; }

//    public QuantityUnit? AmountUnit { get; }
//    public double? AmountValue { get; }

//    public string EntityType { get; }
//}
