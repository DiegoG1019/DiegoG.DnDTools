using System.Collections.Frozen;
using System.Reflection;

namespace DiegoG.DnDTools.InventoryManager.Defaults;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class DefaultItemContainerAttribute : Attribute 
{
    private static readonly object sync = new();
    private static FrozenSet<DefaultItemDescription>? domainDefaultItems;

    public static FrozenSet<DefaultItemDescription> GetAllDefaultItemsInAppDomain()
    {
        if (domainDefaultItems is null)
            lock (sync)
                domainDefaultItems ??= AppDomain.CurrentDomain
                                                .GetAssemblies()
                                                .SelectMany(x => x.GetTypes())
                                                .Where(x => x.GetCustomAttribute<DefaultItemContainerAttribute>() is not null)
                                                .SelectMany(GetProperties)
                                                .Select(x => (DefaultItemDescription)x.GetValue(null)!)
                                                .ToFrozenSet();
        return domainDefaultItems;
    }

    private static IEnumerable<PropertyInfo> GetProperties(Type type)
    {
        var all = type.GetProperty("All", BindingFlags.Static | BindingFlags.IgnoreCase | BindingFlags.Public);
        return all is null || all.PropertyType.IsAssignableTo(typeof(IEnumerable<DefaultItemDescription>)) is false
            ? type.GetProperties().Where(x => x.PropertyType.IsAssignableTo(typeof(IEnumerable<DefaultItemDescription>)))
            : [ all ];
    }
}
