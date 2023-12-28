namespace DiegoG.DnDTools.Services.Common.Requests.Filtering;

public abstract class PropertyFilter
{
    internal PropertyFilter(string propertyName, string filterType)
    {
        FilterType = filterType;
        PropertyName = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
    }

    public string FilterType { get; }
    public string PropertyName { get; set; }
}
