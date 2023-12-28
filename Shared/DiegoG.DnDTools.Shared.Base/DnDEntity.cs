namespace DiegoG.DnDTools;

public class DnDEntity : IDnDInfoObject, ICloneable, IDnDFilterableInfo
{
    public DnDEntity()
    {
        EntityType = GetType().Name;
    }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public virtual ICollection<string>? Tags { get; set; }

    public string EntityType { get; protected init; }

    public virtual DnDEntity DeepClone()
    {
        var x = (DnDEntity)MemberwiseClone();
        x.Tags = Tags?.ToList();
        return x;
    }

    object ICloneable.Clone() => DeepClone();

    IEnumerable<string>? IDnDFilterableInfo.Tags => Tags;
}
