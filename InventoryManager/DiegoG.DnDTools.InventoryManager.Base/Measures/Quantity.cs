using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace DiegoG.DnDTools.InventoryManager.Measures;

public enum QuantityUnit
{
    [UnitDescription("count", 1)] ItemCount,

    [UnitDescription("mts", 1)] Meter,
    [UnitDescription("ft", 1)] Foot,

    [UnitDescription("oz", 1)] LiquidOunce,
    [UnitDescription("lt", 1)] Liter,
    [UnitDescription("gal", 1)] Gallon,
    [UnitDescription("pt", 1)] Pint
}

public readonly partial struct Quantity(double value, QuantityUnit unit) 
    : IMeasurementUnit<Quantity, QuantityUnit>, IParsable<Quantity>, ISpanParsable<Quantity>
{
    public Quantity((double value, QuantityUnit unit) tuple) : this(tuple.value, tuple.unit) { }

    static Quantity()
    {
        MeasurementUnitHelpers<Quantity, QuantityUnit>.Regexes[QuantityUnit.Foot].ExtraRegexes.Add(FootRegex());
        MeasurementUnitHelpers<Quantity, QuantityUnit>.Regexes[QuantityUnit.Meter].ExtraRegexes.Add(MeterRegex());
    }

    public double Value { get; init; } = value;
    public QuantityUnit Unit { get; init; } = unit;

    public double ToStandard()
        => MeasurementUnitHelpers<Quantity, QuantityUnit>.Internal_GetStandardValue(this);

    public static Quantity Convert(Quantity mass, QuantityUnit toUnit)
        => new(MeasurementUnitHelpers<Quantity, QuantityUnit>.Internal_Convert(mass, toUnit));

    public static Quantity FromStandard(double value, QuantityUnit toUnit)
        => new(MeasurementUnitHelpers<Quantity, QuantityUnit>.Internal_FromStandard(value, toUnit));

    public static Quantity Parse(string s, IFormatProvider? provider)
        => Parse(s.AsSpan(), provider);

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Quantity result)
        => TryParse(s.AsSpan(), provider, out result);

    public static Quantity Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
        => TryParse(s, provider, out var quant) ? quant : throw new FormatException("The passed string is not in a correct format.");

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Quantity result)
    {
        if (MeasurementUnitHelpers<Quantity, QuantityUnit>.Internal_TryParse(s, out var r))
        {
            result = new(r.Value, r.Symbol);
            return true;
        }

        result = default;
        return false;
    }

    [GeneratedRegex(@"(?<value>\d+)\s*(?<symbol>foots?)", RegexOptions.IgnoreCase)]
    internal static partial Regex FootRegex();

    [GeneratedRegex(@"(?<value>\d+)\s*(?<symbol>mt?)", RegexOptions.IgnoreCase)]
    internal static partial Regex MeterRegex();
}
