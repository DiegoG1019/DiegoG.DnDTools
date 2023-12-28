using DiegoG.DnDTools.Services.Common;
using DiegoG.DnDTools.Services.Utilities;

namespace DiegoG.DnDTools.Services.Common.Responses;

public enum APIResponseCodeEnum : int
{
    DnDEntityUserView = 40,

    DnDEntityCharacterView = 30,
    
    DnDToolsInventoryView = 20,

    ItemDescriptionView = 10,

    NoData = 2,
    Success = 1,
    Empty = 0,

    ErrorCollection = -1,
    Exception = -2,
    UnspecifiedError = -3,
}

public readonly record struct APIResponseCode(APIResponseCodeEnum ResponseId) : IAPIResponseObjectCode<APIResponseCode>
{
    public string Name { get; } = ResponseId.ToString();

    public static implicit operator APIResponseCode(APIResponseCodeEnum code)
        => new(code);

    public static APIResponseCode NoData => APIResponseCodeEnum.NoData;
    public static APIResponseCode ErrorCollection => APIResponseCodeEnum.ErrorCollection;
    public static APIResponseCode Success => APIResponseCodeEnum.Success;
    public static APIResponseCode UnspecifiedError => APIResponseCodeEnum.UnspecifiedError;
    public static APIResponseCode Exception => APIResponseCodeEnum.Exception;
}

public static class APIResponseCodeExtensions
{
    public static bool IsExpectedResponse(this APIResponseCode code, ref ErrorList errors, APIResponseCodeEnum expected)
    {
        if (code != expected)
        {
            errors.AddError(ErrorMessages.UnexpectedServerResponse((int)code.ResponseId, code.Name));
            return false;
        }

        return true;
    }
}