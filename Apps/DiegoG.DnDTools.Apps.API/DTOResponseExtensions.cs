﻿using Azure;
using DiegoG.DnDTools.Services.Common;
using DiegoG.DnDTools.Services.Common.Responses;
using DiegoG.DnDTools.Services.Utilities;
using Microsoft.EntityFrameworkCore;

namespace DiegoG.DnDTools.Apps.API;

public static class DTOResponseExtensions
{
    public static async ValueTask<APIResponse<TObjectCode>> GetResponse<TObjectCode>(
        this IEnumerable<IResponseModel<TObjectCode>> data,
        string? traceId,
        Func<TObjectCode, APIResponse<TObjectCode>>? responseFactory
    )
        where TObjectCode : struct, IEquatable<TObjectCode>, IAPIResponseObjectCode<TObjectCode>
    {
        TObjectCode code =
            data is IQueryable<IResponseModel<TObjectCode>> queryable
            ? await queryable.AnyAsync() is false
            ? TObjectCode.NoData
            : (await queryable.FirstAsync()).APIResponseCode
            : data.Any() is false
            ? TObjectCode.NoData
            : data.First().APIResponseCode;

        var r = responseFactory?.Invoke(code) ?? new(code);
        r.Data = data;
        r.TraceId = traceId;
        return r;
    }

    public static APIResponse<TObjectCode> GetResponse<TObjectCode>(this ErrorList errorList, string? traceId, APIResponse<TObjectCode>? response)
        where TObjectCode : struct, IEquatable<TObjectCode>, IAPIResponseObjectCode<TObjectCode>
    {
        var r = response ?? new(TObjectCode.ErrorCollection);
        r.Errors = errorList.Errors;
        r.TraceId = traceId;
        return r;
    }

    public static APIResponse<TObjectCode> GetResponse<TObjectCode>(this IEnumerable<ErrorMessage> errorList, string? traceId, APIResponse<TObjectCode>? response)
        where TObjectCode : struct, IEquatable<TObjectCode>, IAPIResponseObjectCode<TObjectCode>
    {
        var r = response ?? new(TObjectCode.ErrorCollection);
        r.Errors = errorList;
        r.TraceId = traceId;
        return r;
    }

    public static APIResponse<TObjectCode> GetResponse<TObjectCode>(
        this IResponseModel<TObjectCode> data,
        string? traceId,
        Func<TObjectCode, APIResponse<TObjectCode>>? responseFactory
    )
        where TObjectCode : struct, IEquatable<TObjectCode>, IAPIResponseObjectCode<TObjectCode>
    {
        var r = responseFactory?.Invoke(data.APIResponseCode) ?? new(data.APIResponseCode);
        r.Data = new object[] { data };
        r.TraceId = traceId;
        return r;
    }
}
