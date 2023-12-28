namespace DiegoG.DnDTools.Services.Common.Requests.Filtering;

public class StringComparisonPropertyFilter(string propertyName, StringComparison comparisonType, StringComparisonTarget comparisonTarget, string value) 
    : PropertyFilter(propertyName, "StringComparison")
{
    public StringComparison ComparisonType { get; } = comparisonType;
    public StringComparisonTarget ComparisonTarget { get; } = comparisonTarget;
    public string Value { get; } = value;
}
