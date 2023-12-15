using DiegoG.DnDTools.InventoryManager;
using DiegoG.DnDTools.InventoryManager.Measures;

namespace DiegoG.DnDTools.Services.Data;

public class InventoryBufferModel
    (Guid id, string name, IEnumerable<string>? tags, string format, ISet<DnDEntityBufferModel> data, int? maximumItems, Mass storedItemsTotalMass, Money storedItemsTotalValue, bool? isOverburdened, string? description, string? notes, int count)
    : InventoryManager.InventoryBuffer(name, tags, format, null!, maximumItems, storedItemsTotalMass, storedItemsTotalValue, isOverburdened, description, notes, count)
{
    public Guid Id { get; set; } = id;

    public override ISet<DnDEntityBufferModel> Data { get; } = data;
}
