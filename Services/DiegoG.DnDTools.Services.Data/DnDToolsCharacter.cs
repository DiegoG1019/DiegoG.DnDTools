using System.Numerics;

namespace DiegoG.DnDTools.Services.Data;

public class DnDToolsCharacter : DnDEntity, IKeyed<DnDToolsCharacter, Guid>
{
    public const int CharacterNameMaxLength = 50;

    public Guid Id { get; set; }

    public string? ReferenceImageUrl { get; set; }

    public Guid OwnerId { get; set; }
    public DnDToolsUser? Owner { get; set; }

    public ISet<InventoryModel>? Inventories { get; set; }

    public override int GetHashCode()
        => Id.GetHashCode();
}
