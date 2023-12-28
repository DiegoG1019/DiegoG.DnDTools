namespace DiegoG.DnDTools.Services.Data;

public class DnDToolsCharacterAccess
{
    public Guid UserId { get; set; }
    public DnDToolsUser? User { get; set; }

    public Guid CharacterId { get; set; }
    public DnDToolsCharacter? Character { get; set; }

    public bool CanEdit { get; set; }
}
