using System.Diagnostics.CodeAnalysis;

namespace DiegoG.DnDTools.Utilities;

public class CaseInsensitiveStringComparer : IEqualityComparer<string>
{
    public bool Equals(string? x, string? y)
        => string.Equals(x, y, StringComparison.InvariantCultureIgnoreCase);

    public int GetHashCode([DisallowNull] string obj)
        => string.GetHashCode(obj, StringComparison.InvariantCultureIgnoreCase);

    private CaseInsensitiveStringComparer() { }

    public static CaseInsensitiveStringComparer Instance { get; } = new();
}
