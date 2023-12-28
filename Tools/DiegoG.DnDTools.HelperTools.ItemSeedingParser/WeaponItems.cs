using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using CsvHelper;

namespace DiegoG.DnDTools.HelperTools.ItemSeedingParser;

public static partial class WeaponItems
{
    public readonly record struct WeaponInputLine(string nombre, string descripcion, string coste, string? tiro, string? dmg, string peso, string categoria, string? lanzamiento, string? rango, string agarre, string? versatil, string? municion, string? tags);

    public static async Task Run()
    {
        using var input = new CsvReader(new StreamReader(File.Open(@"C:\e\weapons.csv", FileMode.Open, FileAccess.Read)), CultureInfo.InvariantCulture);

        using var output = new StreamWriter(File.Open(@"C:\e\weapons-output.txt", FileMode.Create, FileAccess.Write));

        HashSet<string> tags = [];

        await foreach (var line in input.GetRecordsAsync<WeaponInputLine>())
        {
            tags.Clear();

            output.WriteLine("new(new ReadOnlyWeaponItemDescription\n{");

            output.Write("\tName = \"");
            output.Write(PrepareItemString(line.nombre));
            output.WriteLine("\",");

            output.Write("\tDescription = \"");
            output.Write(line.descripcion);
            output.WriteLine("\",");

            if (string.IsNullOrWhiteSpace(line.tiro) is false)
            {
                output.Write("\tDamageThrow = \"");
                output.Write(PrepareItemString(line.tiro));
                output.WriteLine("\",");
            }

            if (string.IsNullOrWhiteSpace(line.dmg) is false)
            {
                output.Write("\tDamageType = \"");
                output.Write(PrepareItemString(line.dmg));
                output.WriteLine("\",");
            }

            output.Write("\tWeaponCategory = \"");
            output.Write(PrepareItemString(line.categoria));
            output.WriteLine("\",");

            if (string.IsNullOrWhiteSpace(line.lanzamiento) is false)
            {
                output.Write("\tThrownRange = \"");
                output.Write(PrepareItemString(line.lanzamiento));
                output.WriteLine("\",");

                if (string.IsNullOrWhiteSpace(line.rango))
                    tags.Add("Munición");
                else
                    tags.Add("Arrojadiza");
            }

            if (string.IsNullOrWhiteSpace(line.rango) is false)
            {
                output.Write("\tRange = \"");
                output.Write(PrepareItemString(line.rango));
                output.WriteLine("\",");
            }

            output.Write("\tGraspType = \"");
            output.Write(PrepareItemString(line.agarre));
            output.WriteLine("\",");

            if (string.IsNullOrWhiteSpace(line.versatil) is false)
            {
                output.Write("\tVersatileDamage = \"");
                output.Write(PrepareItemString(line.versatil));
                output.WriteLine("\",");
                tags.Add("Versátil");
            }

            if (string.IsNullOrWhiteSpace(line.municion) is false)
            {
                output.Write("\tMunitionType = \"");
                output.Write(PrepareItemString(line.municion));
                output.WriteLine("\",");
            }

            if (string.IsNullOrWhiteSpace(line.coste) is false)
            {
                var m = CoinRegex().Match(line.coste);
                if (m.Success)
                {
                    output.Write("\tBasePrice = ");
                    output.Write(m.Groups["cointype"].ValueSpan switch
                    {
                        "c" => $"new(copper: {m.Groups["price"].ValueSpan}, silver: 0, electron: 0, gold: 0, platinum: 0)",
                        "p" => $"new(copper: 0, silver: {m.Groups["price"].ValueSpan}, electron: 0, gold: 0, platinum: 0)",
                        "e" => $"new(copper: 0, silver: 0, electron: {m.Groups["price"].ValueSpan}, gold: 0, platinum: 0)",
                        "o" => $"new(copper: 0, silver: 0, electron: 0, gold: {m.Groups["price"].ValueSpan}, platinum: 0)",
                        "pt" => $"new(copper: 0, silver: 0, electron: 0, gold: 0, platinum: {m.Groups["price"].ValueSpan})",
                        _ => throw new NotImplementedException()
                    });
                } 
            }

            if (string.IsNullOrWhiteSpace(line.peso) is false)
            {
                var m = WeightRegex().Match(line.peso);
                if (m.Success)
                {
                    if (m.Groups.TryGetValue("weight", out var wgr) && string.IsNullOrWhiteSpace(wgr.Value) is false)
                    {
                        output.Write(",\n\tWeightPerItem = new(");
                        output.Write(wgr.Value);
                        output.Write(", MassUnit.Pound)");
                    }
                }
            }

            var taglist = line.tags?.Split(',');
            if (taglist is not null)
                foreach (var tag in taglist)
                    if (string.IsNullOrWhiteSpace(tag) is false)
                        tags.Add(PrepareItemString(tag));

            if (tags.Count > 0)
            {
                output.Write(",\n\tTags = [ ");
                output.Write(string.Join(", ", tags.Select(s => $"\"{s.Trim()}\"")));
                output.Write(" ]");
            }

            output.Write("\n}, SourceManualDelJugador),\n");
        }

        output.Flush();
    }

    private static string PrepareItemString(string str)
    {
        str = str.Trim();
        if (char.IsUpper(str[0]) is false)
        {
            Span<char> chars = stackalloc char[str.Length];
            str.CopyTo(chars);
            chars[0] = char.ToUpper(chars[0]);
            str = chars.ToString();
        }

        return str;
    }

    [GeneratedRegex(@"\s*(?<price>[-+]?[0-9]*\.?[0-9]*)\s*p(?<cointype>[cpoe]|pt)\s*")]
    private static partial Regex CoinRegex();

    [GeneratedRegex(@"\s*(?:(?:(?<weight>[-+]?[0-9]*\.?[0-9]*)\s*lb\.?)|—)\s*")]
    private static partial Regex WeightRegex();
}
