namespace DiegoG.DnDTools.Apps.API.Data;

public interface IResponseModel<TObjectCode>
    where TObjectCode : struct, IEquatable<TObjectCode>
{
    public TObjectCode APIResponseCode { get; }
}
