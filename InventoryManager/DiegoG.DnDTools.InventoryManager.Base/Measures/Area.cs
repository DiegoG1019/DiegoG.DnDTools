using System.Diagnostics.CodeAnalysis;

namespace DiegoG.DnDTools.InventoryManager.Measures;

public enum AreaUnit
{
    [UnitDescription("m", 1)]
    Meter,

    [UnitDescription("ft", 0.3048)]
    Foot
}

public readonly struct Area(double value, AreaUnit unit, byte dimensions = 3)
    : IMeasurementUnit<Area, AreaUnit>, IParsable<Area>, ISpanParsable<Area>
{
    public Area((double value, AreaUnit unit) tuple) : this(tuple.value, tuple.unit) { }

    static Area()
    {
        MeasurementUnitHelpers<Area, AreaUnit>.Regexes[AreaUnit.Foot].ExtraRegexes.Add(Quantity.FootRegex());
        MeasurementUnitHelpers<Area, AreaUnit>.Regexes[AreaUnit.Meter].ExtraRegexes.Add(Quantity.MeterRegex());
    }

    public double Value { get; init; } = value;
    public AreaUnit Unit { get; init; } = unit;

    public double ToStandard()
        => MeasurementUnitHelpers<Area, AreaUnit>.Internal_GetStandardValue(this);

    public static Area Convert(Area mass, AreaUnit toUnit)
        => new(MeasurementUnitHelpers<Area, AreaUnit>.Internal_Convert(mass, toUnit));

    public static Area FromStandard(double value, AreaUnit toUnit)
        => new(MeasurementUnitHelpers<Area, AreaUnit>.Internal_FromStandard(value, toUnit));

    /// <summary>
    /// Represents the amount of dimensions this space represents. For example, if '3', then <see cref="Value"/> represents a cubic measure, that is, three dimensions
    /// </summary>
    public byte Dimensions { get; } = dimensions;

    public static Area Parse(string s, IFormatProvider? provider)
        => Parse(s.AsSpan(), provider);

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Area result)
        => TryParse(s.AsSpan(), provider, out result);

    public static Area Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
        => TryParse(s, provider, out var area) ? area : throw new FormatException("The passed string is not in a correct format.");

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Area result)
    {
        if (MeasurementUnitHelpers<Area, AreaUnit>.Internal_TryParse(s, out var r))
        {
            result = new(r.Value, r.Symbol);
            return true;
        }

        result = default;
        return false;
    }
}
