namespace DiegoG.DnDTools.InventoryManager.Measures;

public static class UnitExtensions
{
    public static string GetSymbol(this MassUnit unit)
        => MeasurementUnitHelpers<Mass, MassUnit>.UnitSymbols.TryGetValue(unit, out var symbol)
            ? symbol
            : throw new ArgumentException($"Unknown MassUnit: '{unit}'", nameof(unit));

    public static string GetSymbol(this QuantityUnit unit)
        => MeasurementUnitHelpers<Quantity, QuantityUnit>.UnitSymbols.TryGetValue(unit, out var symbol)
            ? symbol
            : throw new ArgumentException($"Unknown QuantityUnit: '{unit}'", nameof(unit));

    public static string GetSymbol(this AreaUnit unit)
        => MeasurementUnitHelpers<Area, AreaUnit>.UnitSymbols.TryGetValue(unit, out var symbol)
            ? symbol
            : throw new ArgumentException($"Unknown AreaUnit: '{unit}'", nameof(unit));
}
