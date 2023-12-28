namespace DiegoG.DnDTools.Services.Common.Requests;

public class DnDToolsCharacterUpdateModel
{
    public string? ReferenceImageUrl { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public IEnumerable<EditAction<string>>? Tags { get; set; }
    public IEnumerable<EditAction<Guid>>? CharacterAccesses { get; set; }
}
