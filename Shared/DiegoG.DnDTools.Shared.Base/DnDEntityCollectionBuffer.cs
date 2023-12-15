using System.Text.Json;
namespace DiegoG.DnDTools;

public class DnDEntityCollectionBuffer(string name, IEnumerable<string>? tags, string format, IEnumerable<DnDEntityBuffer> data) : IDnDFilterableInfo
{
    public string Name { get; } = name ?? throw new ArgumentNullException(nameof(name));
    public string Format { get; } = format ?? throw new ArgumentNullException(nameof(format));
    public IEnumerable<string>? Tags { get; } = tags;

    public virtual IEnumerable<DnDEntityBuffer> Data { get; } = data ?? throw new ArgumentNullException(nameof(data));

    public IEnumerable<DnDEntity> Deserialize(DnDEntityBufferContext? deserializer = null, object? options = null)
    {
        foreach (var dat in Data)
            yield return dat.Deserialize(deserializer, options);
    }
}
