namespace DiegoG.DnDTools;

public interface IDnDInfoObject
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public ICollection<string>? Tags { get; set; }
}
