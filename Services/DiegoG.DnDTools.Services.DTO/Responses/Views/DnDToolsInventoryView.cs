using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.DnDTools.Services.Common.Responses.Views;

public class DnDToolsEmbeddedInventoryView
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int ItemCount { get; set; }
}

public class DnDToolsInventoryView : DnDToolsEmbeddedInventoryView, IResponseModel<APIResponseCode>
{
    public string? Notes { get; set; }
    public DnDToolsEmbeddedCharacterView? Owner { get; set; }
    public IEnumerable<string>? Tags { get; set; }
    public IEnumerable<EmbeddedItemDescriptionView>? Items { get; set; }

    public APIResponseCode APIResponseCode => APIResponseCodeEnum.DnDToolsInventoryView;
}
