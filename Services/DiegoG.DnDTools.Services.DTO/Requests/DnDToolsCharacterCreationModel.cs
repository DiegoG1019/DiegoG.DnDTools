namespace DiegoG.DnDTools.Services.Common.Requests;

public class DnDToolsCharacterCreationModel
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public string? ReferenceImageUrl { get; set; }
    public IEnumerable<string>? Tags { get; set; }
}
