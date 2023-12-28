namespace DiegoG.DnDTools.Services.Common.Responses;

public interface IResponseModel<TObjectCode>
    where TObjectCode : struct, IEquatable<TObjectCode>
{
    public TObjectCode APIResponseCode { get; }
}
