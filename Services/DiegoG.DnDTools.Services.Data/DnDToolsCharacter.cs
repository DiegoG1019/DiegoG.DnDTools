namespace DiegoG.DnDTools.Services.Data;

public class DnDToolsCharacter : DnDEntity
{
    public string? ReferenceImageUrl { get; set; }

    public ISet<InventoryBufferModel>? Inventories { get; set; }

    public ISet<DnDToolsCharacterAccess>? Viewers { get; set; }
}
