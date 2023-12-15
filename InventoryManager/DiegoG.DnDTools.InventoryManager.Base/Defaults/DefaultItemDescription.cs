namespace DiegoG.DnDTools.InventoryManager.Defaults;

public class DefaultItemDescription
{
    public DefaultItemDescription(Func<ItemDescription> itemFactory, string? source = null)
    {
        ItemFactory = itemFactory ?? throw new ArgumentNullException(nameof(itemFactory));
        Source = source;

        var item = ItemFactory();
        Name = item.Name;
        Description = item.Description;
    }

    public Func<ItemDescription> ItemFactory { get; }
    public string? Name { get; }
    public string? Description { get; }
    public string? Source { get; }
}
