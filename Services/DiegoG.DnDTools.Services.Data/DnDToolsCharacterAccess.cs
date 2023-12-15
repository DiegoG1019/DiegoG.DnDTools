namespace DiegoG.DnDTools.Services.Data;

public class DnDToolsCharacterAccess
{
    public Guid AccesorId { get; set; }
    public DnDToolsUser? Accesor { get; set; }

    public Guid CharacterId { get; set; }
    public DnDToolsCharacter? Character { get; set; }

    public bool CanEdit { get; set; }
}
