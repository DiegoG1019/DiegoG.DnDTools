namespace DiegoG.DnDTools.Services.Common.Requests.Filtering;

public sealed class OrderByProperty
{
    public OrderByProperty(string propertyName, bool ascending)
    {
        PropertyName = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
        Ascending = ascending;
    }

    public string PropertyName { get; set; }
    public bool Ascending { get; set; }
}
