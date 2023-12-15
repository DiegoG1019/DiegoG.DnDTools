namespace DiegoG.DnDTools.InventoryManager.Measures;

[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
public sealed class UnitDescriptionAttribute(string symbol) : Attribute
{
    public UnitDescriptionAttribute(string symbol, double conversionToStandard) : this(symbol)
    {
        ConversionToStandard = conversionToStandard;
    }

    public string Symbol { get; } = symbol ?? throw new ArgumentNullException(nameof(symbol));
    public double? ConversionToStandard { get; }
}
