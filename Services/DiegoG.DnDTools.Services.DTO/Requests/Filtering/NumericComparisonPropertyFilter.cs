namespace DiegoG.DnDTools.Services.Common.Requests.Filtering;

public class NumericComparisonPropertyFilter(string propertyName, NumericComparisonType comparisonType, int value) 
    : PropertyFilter(propertyName, "NumericComparison")
{
    public NumericComparisonType ComparisonType { get; } = comparisonType;
    public int Value { get; } = value;
}
