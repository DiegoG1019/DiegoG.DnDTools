using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiegoG.DnDTools.Services.Common.Requests;
using DiegoG.DnDTools.Services.Data.Internal;

namespace DiegoG.DnDTools.Services.Data.Repositories;

public interface IDnDToolsCharacterRepository : ICRUDRepository<DnDToolsCharacter, DnDToolsCharacterCreationModel, DnDToolsCharacterUpdateModel>
{
    public IQueryable<DnDToolsCharacter>? GetEditableEntities(DnDToolsUser? requester);
    public ValueTask<DnDToolsUser?> GetCharacterOwner(DnDToolsCharacter entity);
}
