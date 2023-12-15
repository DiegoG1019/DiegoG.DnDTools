using System.Collections;
using System.Collections.Frozen;
using System.Reflection;
using System.Text.RegularExpressions;
using DiegoG.DnDTools.InventoryManager.Utilities;
using DiegoG.DnDTools.Utilities;

namespace DiegoG.DnDTools.InventoryManager.Measures;

internal static class MeasurementUnitHelpers<TStruct, TUnit>
    where TStruct : struct, IMeasurementUnit<TStruct, TUnit>
    where TUnit : unmanaged, Enum, IConvertible
{
    public class MeasurementRegexCollection(Regex symbol, Regex name) : IEnumerable<Regex>
    {
        public Regex Symbol { get; } = symbol ?? throw new ArgumentNullException(nameof(symbol));
        public Regex Name { get; } = name ?? throw new ArgumentNullException(nameof(name));
        public HashSet<Regex> ExtraRegexes { get; } = [];

        public Match? GetFirstMatch(ReadOnlySpan<char> s)
        {
            foreach (var reg in this)
                if (reg.IsMatch(s))
                    return reg.Match(s.ToString());
            return null;
        }

        public IEnumerator<Regex> GetEnumerator()
        {
            yield return Symbol;
            yield return Name;
            foreach (var r in ExtraRegexes)
                yield return r;
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }

    public static FrozenDictionary<TUnit, string> UnitSymbols { get; }
    public static FrozenDictionary<string, TUnit> UnitsBySymbol { get; }
    public static FrozenDictionary<TUnit, double> Conversions { get; }
    public static FrozenDictionary<TUnit, MeasurementRegexCollection> Regexes { get; }

    static MeasurementUnitHelpers()
    {
        var us = new Dictionary<TUnit, string>();
        var ubs = new Dictionary<string, TUnit>();
        var convs = new Dictionary<TUnit, double>();
        var reg = new Dictionary<TUnit, MeasurementRegexCollection>();

        foreach (var (val, sym, conv, name) in
            typeof(TUnit)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Select(x => (Field: x, Desc: x.GetCustomAttribute<UnitDescriptionAttribute>()!))
            .Where(x => x.Desc is not null && x.Desc.ConversionToStandard is double)
            .Select(x => ((TUnit)x.Field.GetValue(null)!, x.Desc.Symbol, x.Desc.ConversionToStandard!.Value, x.Field.Name))
        )
        {
            us.Add(val, sym);
            ubs.Add(sym, val);
            convs.Add(val, conv);
            reg.Add(val, new MeasurementRegexCollection(
                new Regex(@$"(?<value>\d+)\s*(?<symbol>{sym}s?)", RegexOptions.IgnoreCase | RegexOptions.Compiled),
                new Regex(@$"(?<value>\d+)\s*(?<symbol>{name}s?)", RegexOptions.IgnoreCase | RegexOptions.Compiled)
            ));
        }

        UnitSymbols = us.ToFrozenDictionary();
        UnitsBySymbol = ubs.ToFrozenDictionary(CaseInsensitiveStringComparer.Instance);
        Conversions = convs.ToFrozenDictionary();
        Regexes = reg.ToFrozenDictionary();
    }

    public static (double Value, TUnit Unit) Internal_Convert(TStruct obj, TUnit toUnit)
        => obj.Unit.ToInt64(null) != toUnit.ToInt64(null) ? Internal_FromStandard(Internal_GetStandardValue(obj), toUnit) : (obj.Value, obj.Unit);

    public static (double Value, TUnit Unit) Internal_FromStandard(double value, TUnit toUnit) 
        => Conversions.TryGetValue(toUnit, out var conv) is false
            ? throw new ArgumentException($"Unknown unit: '{toUnit}'", nameof(toUnit))
            : new(value / conv, toUnit);

    public static double Internal_GetStandardValue(TStruct obj)
        => obj.Value * Conversions[obj.Unit];

    public static bool Internal_TryParse(ReadOnlySpan<char> s, out (double Value, TUnit Symbol) result)
    {
        foreach (var (unit, regcol) in Regexes)
        {
            var m = regcol.GetFirstMatch(s);
            if (m is null)
                continue;

            if (EvaluateMatch(m, s, out var r))
            {
                result = (r.Value, UnitsBySymbol[r.Symbol]);
                return true;
            }
        }

        result = default;
        return false;
    }

    private static bool EvaluateMatch(Match m, ReadOnlySpan<char> s, out (double Value, string Symbol) result)
    {
        if (m.Success && m.Length == s.Length)
        {
            result = (double.Parse(m.Groups["value"].ValueSpan), m.Groups["symbol"].Value);
            return true;
        }

        result = default;
        return false;
    }
}