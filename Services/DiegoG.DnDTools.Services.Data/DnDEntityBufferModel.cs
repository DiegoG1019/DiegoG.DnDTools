namespace DiegoG.DnDTools.Services.Data;

public class DnDEntityBufferModel(Guid id, Guid containerId, string name, IEnumerable<string>? tags, string type, string format, byte[] data)
    : DnDEntityBuffer(name, tags, type, format, data)
{
    public Guid Id { get; set; } = id;

    public Guid ContainerId { get; set; } = containerId;
    public InventoryBufferModel? Container { get; set; }
}
