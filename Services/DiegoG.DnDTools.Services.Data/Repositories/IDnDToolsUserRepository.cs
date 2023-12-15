using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiegoG.DnDTools.InventoryManager;
using DiegoG.DnDTools.Services.Common;
using DiegoG.DnDTools.Services.Data.Internal;
using DiegoG.DnDTools.Services.Data.Requests;

namespace DiegoG.DnDTools.Services.Data.Repositories;

public interface IDnDToolsUserRepository : ICRUDRepository<DnDToolsUser, DnDToolsUserCreationModel, DnDToolsUserUpdateModel>;