using System.Text.Json;

namespace DiegoG.DnDTools;

public static class DnDEntityBufferExtensions
{
    public const string FormatJsonUTF8 = "json;utf8";

    public static IEnumerable<DnDEntityBuffer> SerializeCollectionAsJsonBuffers(
        IEnumerable<DnDEntity> entities, 
        DnDEntityBufferContext? context = null, 
        JsonSerializerOptions? options = null
    )
    {
        IEnumerable<DnDEntityBuffer> buffer;

        if (entities.TryGetNonEnumeratedCount(out var count))
        {
            var items = new DnDEntityBuffer[count];
            int i = -1;
            foreach (var ent in entities)
            {
                if (++i > items.Length)
                    throw new IndexOutOfRangeException($"The entities has more elements than expected after obtaining a non-enumerated count. Expected: {items.Length}, Current: {i}");
                items[i] = CreateJsonDnDEntityBuffer(ent, context, options);
            }
            buffer = items;
        }
        else
        {
            var l = new List<DnDEntityBuffer>();
            foreach (var dat in entities)
                l.Add(CreateJsonDnDEntityBuffer(dat, context, options));
            buffer = l;
        }

        return buffer;
    }

    public static DnDEntityCollectionBuffer CreateJsonDnDEntityCollectionBuffer<T>(
        T collection,
        DnDEntityBufferContext? context = null,
        JsonSerializerOptions? options = null
    )
        where T : IDnDFilterableInfo, IEnumerable<DnDEntity>
    {
        ArgumentNullException.ThrowIfNull(collection);
        IEnumerable<DnDEntityBuffer> buffer = SerializeCollectionAsJsonBuffers(collection, context, options);

        return new DnDEntityCollectionBuffer(collection.Name!, collection.Tags, FormatJsonUTF8, buffer);
    }

    public static DnDEntityBuffer CreateJsonDnDEntityBuffer(
        this DnDEntity description,
        DnDEntityBufferContext? context = null,
        JsonSerializerOptions? options = null
    )
    {
        ArgumentNullException.ThrowIfNull(description);

        context ??= DnDEntityBufferContext.Default;

        using var ms = new MemoryStream(5000);
        JsonSerializer.Serialize(ms, description, context.GetCLRType(description.EntityType), options);
        return new(description.Name!, description.Tags, description.EntityType, FormatJsonUTF8, ms.ToArray());
    }
}
