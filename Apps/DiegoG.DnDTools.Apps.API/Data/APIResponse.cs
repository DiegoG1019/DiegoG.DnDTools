using System.Text.Json.Serialization;
using DiegoG.DnDTools.Services.Common;
using DiegoG.REST;

namespace DiegoG.DnDTools.Apps.API.Data;

public class APIResponse<TObjectCode>(TObjectCode code) : RESTObject<TObjectCode>(code)
    where TObjectCode : struct, IEquatable<TObjectCode>, IAPIResponseObjectCode<TObjectCode>
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<object>? Data { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<ErrorMessage>? Errors { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TraceId { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Exception { get; set; }
}
