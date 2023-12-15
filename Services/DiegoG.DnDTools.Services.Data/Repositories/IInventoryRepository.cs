using DiegoG.DnDTools.Services.Data.Internal;
using DiegoG.DnDTools.Services.Data.Requests;

namespace DiegoG.DnDTools.Services.Data.Repositories;

public interface IInventoryRepository : ICRUDRepository<InventoryBufferModel, InventoryCreationModel, InventoryUpdateModel>
{
    public IQueryable<InventoryBufferModel> GetEntities(DnDToolsUser? requester, Guid characterId);
}
