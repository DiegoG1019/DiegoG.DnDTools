using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiegoG.DnDTools.Services.Common.Requests;
using DiegoG.DnDTools.Services.Data.Internal;
using DiegoG.DnDTools.Utilities;

namespace DiegoG.DnDTools.Services.Data.Repositories;

public interface IItemDescriptionRepository : ICRUDRepository<IBaseItemDescriptionModel, ItemDescriptionCreationModel, ItemDescriptionUpdateModel>
{
    public readonly record struct ItemDescriptionSchemaInfo(ItemDescriptionSchema Schema, Type ClrType, Type DataModelClrType);

    public IEnumerable<ItemDescriptionSchemaInfo> GetItemSchemaInfo()
        => ReflectionDetectedSchemas.Values;

    public ItemDescriptionSchemaInfo GetItemSchemaInfo(string entityType)
        => ReflectionDetectedSchemas.TryGetValue(entityType, out var schema) ? schema : throw new KeyNotFoundException($"Could not find an item schema for {entityType}");

    public ItemDescriptionSchemaInfo GetItemSchemaInfo(Type clrType)
        => ReflectionDetectedSchemasByDataModelType.TryGetValue(clrType, out var schema)
         ? schema
         : ReflectionDetectedSchemasByBaseType.TryGetValue(clrType, out schema)
         ? schema
         : throw new KeyNotFoundException($"Could not find an item schema for {clrType}");

    public bool TryGetItemSchemaInfo(
        Type type,
        [NotNullWhen(true)] out ItemDescriptionSchema? schema,
        [NotNullWhen(true)] out Type? clrType,
        [NotNullWhen(true)] out Type? dataModelClrType
    )
    {
        if (ReflectionDetectedSchemasByDataModelType.TryGetValue(type, out var result) 
            || ReflectionDetectedSchemasByBaseType.TryGetValue(type, out result))
        {
            schema = result.Schema;
            clrType = result.ClrType;
            dataModelClrType = result.DataModelClrType;
            return true;
        }

        schema = null;
        clrType = null;
        dataModelClrType = null;
        return false;
    }

    public bool TryGetItemSchemaInfo(
        string entityType, 
        [NotNullWhen(true)] out ItemDescriptionSchema? schema, 
        [NotNullWhen(true)] out Type? clrType,
        [NotNullWhen(true)] out Type? dataModelClrType
    )
    {
        if (ReflectionDetectedSchemas.TryGetValue(entityType, out var result))
        {
            schema = result.Schema;
            clrType = result.ClrType;
            dataModelClrType = result.DataModelClrType;
            return true;
        }

        schema = null;
        clrType = null;
        dataModelClrType = null;
        return false;
    }

    public IQueryable<IBaseItemDescriptionModel>? GetEditableEntities(DnDToolsUser? requester);

    public IQueryable<IBaseItemDescriptionModel>? GetEditableEntitiesInInventory(DnDToolsUser? requester, Guid inventoryId);
    public IQueryable<IBaseItemDescriptionModel>? GetEditableEntitiesInInventory(DnDToolsUser? requester, InventoryModel inventory);

    public IQueryable<IBaseItemDescriptionModel>? GetEditableEntitiesFromCharacter(DnDToolsUser? requester, Guid characterId);
    public IQueryable<IBaseItemDescriptionModel>? GetEditableEntitiesFromCharacter(DnDToolsUser? requester, DnDToolsCharacter character);

    public IQueryable<IBaseItemDescriptionModel>? GetEntitiesInInventory(DnDToolsUser? requester, Guid inventoryId);
    public IQueryable<IBaseItemDescriptionModel>? GetEntitiesInInventory(DnDToolsUser? requester, InventoryModel inventory);

    public IQueryable<IBaseItemDescriptionModel>? GetEntitiesFromCharacter(DnDToolsUser? requester, Guid characterId);
    public IQueryable<IBaseItemDescriptionModel>? GetEntitiesFromCharacter(DnDToolsUser? requester, DnDToolsCharacter character);

    public static IReadOnlyDictionary<string, ItemDescriptionSchemaInfo> ReflectionDetectedSchemas { get; }
    public static IReadOnlyDictionary<Type, ItemDescriptionSchemaInfo> ReflectionDetectedSchemasByBaseType { get; }
    public static IReadOnlyDictionary<Type, ItemDescriptionSchemaInfo> ReflectionDetectedSchemasByDataModelType { get; }

    static IItemDescriptionRepository()
    {
        ReflectionDetectedSchemas = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => x.IsAssignableTo(typeof(IBaseItemDescriptionModel)))
            .Select(x => new ItemDescriptionSchemaInfo(GenerateFromType(x.BaseType!), x.BaseType!, x))
            .ToFrozenDictionary(
                k => k.Schema.EntityType,
                v => v,
                CaseInsensitiveStringComparer.Instance
            );

        ReflectionDetectedSchemasByBaseType = ReflectionDetectedSchemas.ToFrozenDictionary(
            k => k.Value.ClrType,
            v => v.Value
        );

        ReflectionDetectedSchemasByDataModelType = ReflectionDetectedSchemas.ToFrozenDictionary(
            k => k.Value.DataModelClrType,
            v => v.Value
        );

        static ItemDescriptionSchema GenerateFromType(Type type) 
            => new(type.Name, type.GetProperties()
                                  .Select(x => new ItemDescriptionSchema.ItemDescriptionProperty(
                                              x.Name,
                                              x.PropertyType.Name
                                          )));
    }
}
