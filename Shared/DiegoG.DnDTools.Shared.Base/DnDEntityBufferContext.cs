using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using DiegoG.DnDTools.Utilities;

namespace DiegoG.DnDTools;

public class DnDEntityBufferContext
{
    public delegate DnDEntity DnDEntityDeserializerFunc(DnDEntityBuffer buffer, DnDEntityBufferContext deserializer, object? options);

    protected static FrozenDictionary<string, Type> ReflectionDetectedTypes { get; }
    protected static Dictionary<string, DnDEntityDeserializerFunc> Deserializers { get; } 

    protected DnDEntityBufferContext() { }

    static DnDEntityBufferContext()
    {
        ReflectionDetectedTypes = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(x => x.GetExportedTypes())
            .Where(x => x.IsAssignableTo(typeof(DnDEntity)) && x.IsAbstract is false && (x.IsGenericType is false || x.IsConstructedGenericType))
            .ToFrozenDictionary(
                k => k.Name,
                v => v,
                CaseInsensitiveStringComparer.Instance
            );

        Deserializers = new(CaseInsensitiveStringComparer.Instance)
        {
            { 
                DnDEntityBufferExtensions.FormatJsonUTF8,
                (b, d, o) =>
                {
                    if(o is not null && o is not JsonSerializerOptions options)
                        throw new InvalidCastException($"The options object is not appropriate for the selected format. Expected JsonSerializerOptions for format '{DnDEntityBufferExtensions.FormatJsonUTF8}'");
                    else
                        options = null!;

                    return (DnDEntity)JsonSerializer.Deserialize(b.Data, d.GetCLRType(b.Type), options)!; 
                }
            }
        };
    }

    public static DnDEntityBufferContext Default { get; } = new();

    public virtual Type GetCLRType(string type) 
        => TryGetCLRType(type, out var result) ? result : throw new KeyNotFoundException($"Could not match the type '{type}' to a CLR type");

    public virtual bool TryGetCLRType(string type, [NotNullWhen(true)] out Type? result) 
        => ReflectionDetectedTypes.TryGetValue(type, out result);

    public virtual DnDEntity Deserialize(DnDEntityBuffer buffer, object? options = null) 
        => Deserializers.TryGetValue(buffer.Format, out var func)
            ? func.Invoke(buffer, this, options)
            : throw new KeyNotFoundException($"Could not find an appropriate deserializer for format '{buffer.Format}'");

    public virtual bool SupportsFormat(string format) => Deserializers.ContainsKey(format);
}
