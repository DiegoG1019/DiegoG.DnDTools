using DiegoG.DnDTools.Services.Utilities;

namespace DiegoG.DnDTools.Services.Common.Requests;

public class InventoryUpdateModel
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public int? MaximumItems { get; set; }
    public UpdateNullableStruct<Guid>? ContainerItemId { get; set; }
    public IEnumerable<EditAction<string>>? Tags { get; set; }
}

public class InventoryCreationModel
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public int? MaximumItems { get; set; }
    public IEnumerable<string>? Tags { get; set; }
    public Guid? ContainerItemId { get; set; }
    public Guid OwnerCharacterId { get; set; }
}