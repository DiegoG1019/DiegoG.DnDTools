using System.Buffers.Text;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using DiegoG.DnDTools.InventoryManager;
using DiegoG.DnDTools.Services.Common;
using DiegoG.DnDTools.Shared.Utilities;
using Microsoft.AspNetCore.Identity;

namespace DiegoG.DnDTools.Services.Data;

public class DnDToolsUser : IdentityUser<Guid>, IKeyed<DnDToolsUser, Guid>
{
    public const int EmailMaxLength = 100;
    public const int UserNameMaxLength = 20;

    public ISet<DnDToolsCharacter>? AccesibleCharacters { get; set; }
    public ISet<DnDToolsCharacter>? OwnedCharacters { get; set; }

    public override string? NormalizedEmail
    { 
        get => base.NormalizedEmail; 
        set
        {
            if (string.Equals(base.NormalizedEmail, value, StringComparison.OrdinalIgnoreCase))
            {
                _emd5h = null;
                base.NormalizedEmail = value;
            }
        }
    }

    private string? _emd5h;
    public string? EmailMD5Hash
    {
        get => GetEmailMD5();
        set => _emd5h = value;
    }

    private string? GetEmailMD5()
    {
        if (string.IsNullOrWhiteSpace(_emd5h) && string.IsNullOrWhiteSpace(NormalizedEmail) is false) 
            _emd5h = NormalizedEmail.ToMd5();
        return _emd5h;
    }

    public override int GetHashCode()
        => Id.GetHashCode();
}
