using System.Diagnostics.CodeAnalysis;
using DiegoG.DnDTools.InventoryManager.Defaults;

namespace DiegoG.DnDTools.InventoryManager.Utilities;

/*
 * Basically, in the database simply store the necessary data; maybe you'll need two: a NoSQL for item data, and an SQL to relate them to user data
 * Additionally, create buffer objects that you can then polymorphically serialize/convert into their real, respective forms. 
 * This might be expensive server-side, but this'll need a dedicated app anyways.
 * Validations? Prolly better to skip 'em; let the API purely manage data
 * But maybe not, we'll see
 */

public class DefaultItemDescriptionEqualityComparer : IEqualityComparer<DefaultItemDescription>
{
    private DefaultItemDescriptionEqualityComparer() { }

    public static DefaultItemDescriptionEqualityComparer Instance { get; } = new();

    public bool Equals(DefaultItemDescription? x, DefaultItemDescription? y)
        => x?.Name == y?.Name && x?.Source == y?.Source;

    public int GetHashCode([DisallowNull] DefaultItemDescription obj)
        => HashCode.Combine(obj.Name, obj.Source);
}
