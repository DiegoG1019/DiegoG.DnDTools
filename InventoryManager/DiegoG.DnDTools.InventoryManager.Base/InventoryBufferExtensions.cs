using System.Text.Json;
namespace DiegoG.DnDTools.InventoryManager;

public static class InventoryBufferExtensions
{
    public static InventoryBuffer CreateJsonInventoryBuffer(
        this Inventory inventory, 
        DnDEntityBufferContext? context = null, 
        JsonSerializerOptions? options = null
    )
    {
        var buffer = DnDEntityBufferExtensions.SerializeCollectionAsJsonBuffers(inventory, context, options);
        return new InventoryBuffer(
            inventory.Name!,
            inventory.Tags,
            DnDEntityBufferExtensions.FormatJsonUTF8,
            buffer,
            inventory.MaximumItems,
            inventory.StoredItemsTotalMass,
            inventory.StoredItemsTotalValue,
            inventory.IsOverburdened,
            inventory.Description,
            inventory.Notes,
            inventory.Count
        );
    }
}
