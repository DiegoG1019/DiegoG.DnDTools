using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.DnDTools;

public class DnDEntityBuffer(string name, IEnumerable<string>? tags, string type, string format, byte[] data) : IDnDFilterableInfo
{
    public string Name { get; } = name ?? throw new ArgumentNullException(nameof(name));
    public string Type { get; } = type ?? throw new ArgumentNullException(nameof(type));
    public string Format { get; } = format ?? throw new ArgumentNullException(nameof(format));
    public byte[] Data { get; } = data ?? throw new ArgumentNullException(nameof(data));
    public IEnumerable<string>? Tags { get; } = tags;

    public DnDEntity Deserialize(DnDEntityBufferContext? deserializer = null, object? options = null)
        => (deserializer ?? DnDEntityBufferContext.Default).Deserialize(this, options);
}
