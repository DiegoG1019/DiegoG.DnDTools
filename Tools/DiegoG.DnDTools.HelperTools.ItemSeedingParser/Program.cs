using System.Text.RegularExpressions;

namespace DiegoG.DnDTools.HelperTools.ItemSeedingParser;

public static partial class Program
{
    static void Main(string[] args)
    {
        var str = File.ReadAllText(@"C:\e\equipo.txt");

        using var of = File.Open(@"C:\e\output.txt", FileMode.Create, FileAccess.Write);
        using var output = new StreamWriter(of);
        
        //BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0),
        //WeightPerItem = new(2, MassUnit.Pound)
        foreach (var match in (IEnumerable<Match>)StandardFormatRegex().Matches(str))
        {
            output.WriteLine("new ItemDescription\n{");

            output.Write("\tName = \"");
            output.Write(match.Groups["name"].ValueSpan);
            output.WriteLine("\",");

            output.Write("\tBasePrice = ");
            output.Write(match.Groups["cointype"].ValueSpan switch
            {
                "c" => $"new(copper: {match.Groups["price"].ValueSpan}, silver: 0, electron: 0, gold: 0, platinum: 0)",
                "p" => $"new(copper: 0, silver: {match.Groups["price"].ValueSpan}, electron: 0, gold: 0, platinum: 0)",
                "e" => $"new(copper: 0, silver: 0, electron: {match.Groups["price"].ValueSpan}, gold: 0, platinum: 0)",
                "o" => $"new(copper: 0, silver: 0, electron: 0, gold: {match.Groups["price"].ValueSpan}, platinum: 0)",
                "pt" => $"new(copper: 0, silver: 0, electron: 0, gold: 0, platinum: {match.Groups["price"].ValueSpan})",
                _ => throw new NotImplementedException()
            });

            if (match.Groups.TryGetValue("weight", out var wgr) && string.IsNullOrWhiteSpace(wgr.Value) is false) 
            {
                output.Write(",\n\tWeightPerItem = new(");
                output.Write(wgr.Value);
                output.Write(", MassUnit.Pound)");
            }

            output.Write("\n},\n");
        }

        output.Flush();
    }

    [GeneratedRegex(
        @"^(?<name>[\w()\d\s,]*) (?<price>[-+]?[0-9]*\.?[0-9]*) p(?<cointype>[cpoe]|pt) (?:(?:(?<weight>[-+]?[0-9]*\.?[0-9]*)\s*lb.)|—)\s*$",
        RegexOptions.Multiline
    )]
    private static partial Regex StandardFormatRegex();
}
