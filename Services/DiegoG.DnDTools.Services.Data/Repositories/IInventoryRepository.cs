using DiegoG.DnDTools.Services.Common.Requests;
using DiegoG.DnDTools.Services.Data.Internal;

namespace DiegoG.DnDTools.Services.Data.Repositories;

public interface IInventoryRepository : ICRUDRepository<InventoryModel, InventoryCreationModel, InventoryUpdateModel>
{
    public IQueryable<InventoryModel>? GetEditableEntities(DnDToolsUser? requester);
    public IQueryable<InventoryModel>? GetEditableEntities(DnDToolsUser? requester, Guid characterId);
    public IQueryable<InventoryModel>? GetEditableEntities(DnDToolsUser? requester, DnDToolsCharacter character);
    public IQueryable<InventoryModel>? GetEntities(DnDToolsUser? requester, Guid characterId);
    public IQueryable<InventoryModel>? GetEntities(DnDToolsUser? requester, DnDToolsCharacter character);
}
