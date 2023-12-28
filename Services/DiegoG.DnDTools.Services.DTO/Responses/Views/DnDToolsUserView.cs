namespace DiegoG.DnDTools.Services.Common.Responses.Views;

public class DnDToolsEmbeddedUserView
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? EmailHashMD5 { get; set; }
}

public class DnDToolsUserView : DnDToolsEmbeddedUserView, IResponseModel<APIResponseCode>
{
    public IEnumerable<DnDToolsEmbeddedCharacterView>? Characters { get; set; }

    public APIResponseCode APIResponseCode => APIResponseCodeEnum.DnDEntityUserView;
}
