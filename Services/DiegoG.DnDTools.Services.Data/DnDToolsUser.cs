using DiegoG.DnDTools.InventoryManager;
using Microsoft.AspNetCore.Identity;

namespace DiegoG.DnDTools.Services.Data;

public class DnDToolsUser : IdentityUser<Guid>
{
    public const int EmailMaxLength = 100;
    public const int RealNameMaxLength = 100;
    public const int UserNameMaxLength = 20;

    public ISet<DnDToolsCharacterAccess>? AccesibleCharacters { get; set; }
}
