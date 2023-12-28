using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.DnDTools.Services.Common.Responses.Views;

public class DnDToolsEmbeddedCharacterView
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public string? Name { get; set; }
    public string? ReferenceImageUrl { get; set; }
}

public class DnDToolsCharacterView : DnDToolsEmbeddedCharacterView, IResponseModel<APIResponseCode>
{
    public DnDToolsEmbeddedUserView? Owner { get; set; }
    public IEnumerable<DnDToolsEmbeddedInventoryView>? Inventories { get; set; }
    public APIResponseCode APIResponseCode => APIResponseCodeEnum.DnDEntityCharacterView;
}
