using DiegoG.DnDTools.InventoryManager.ReadOnly;

namespace DiegoG.DnDTools.InventoryManager.Defaults;

public readonly record struct DefaultItemDescription(
    ReadOnlyItemDescription ItemDescription,
    string? Source
);
