namespace DiegoG.DnDTools.Services.Data;

public sealed record class ItemDescriptionSchema(string EntityType, IEnumerable<ItemDescriptionSchema.ItemDescriptionProperty> Properties)
{
    public readonly record struct ItemDescriptionProperty(string Name, string Type);

    public override int GetHashCode()
        => string.GetHashCode(EntityType, StringComparison.OrdinalIgnoreCase);
}
