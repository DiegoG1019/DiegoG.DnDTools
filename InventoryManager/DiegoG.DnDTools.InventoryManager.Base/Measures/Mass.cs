using System.Diagnostics.CodeAnalysis;

namespace DiegoG.DnDTools.InventoryManager.Measures;

public enum MassUnit
{
    [UnitDescription("g", 1)]
    Gram,

    [UnitDescription("kg", 1000)]
    Kilogram,

    [UnitDescription("lb", 453.5924)]
    Pound
}

public readonly struct Mass(double value, MassUnit unit)
    : IMeasurementUnit<Mass, MassUnit>, IParsable<Mass>, ISpanParsable<Mass>
{
    public Mass((double value, MassUnit unit) tuple) : this(tuple.value, tuple.unit) { }

    public double Value { get; init; } = value;
    public MassUnit Unit { get; init; } = unit;

    public double ToStandard()
        => MeasurementUnitHelpers<Mass, MassUnit>.Internal_GetStandardValue(this);

    public static Mass Convert(Mass mass, MassUnit toUnit)
        => new(MeasurementUnitHelpers<Mass, MassUnit>.Internal_Convert(mass, toUnit));

    public static Mass FromStandard(double value, MassUnit toUnit)
        => new(MeasurementUnitHelpers<Mass, MassUnit>.Internal_FromStandard(value, toUnit));

    public static Mass Parse(string s, IFormatProvider? provider)
        => Parse(s.AsSpan(), provider);

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Mass result)
        => TryParse(s.AsSpan(), provider, out result);

    public static Mass Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
        => TryParse(s, provider, out var mass) ? mass : throw new FormatException("The passed string is not in a correct format.");

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Mass result)
    {
        if (MeasurementUnitHelpers<Mass, MassUnit>.Internal_TryParse(s, out var r))
        {
            result = new(r.Value, r.Symbol);
            return true;
        }

        result = default;
        return false;
    }
}
