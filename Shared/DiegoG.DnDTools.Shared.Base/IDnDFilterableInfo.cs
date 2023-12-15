namespace DiegoG.DnDTools;

public interface IDnDFilterableInfo
{
    public string? Name { get; }
    public IEnumerable<string>? Tags { get; }
}
