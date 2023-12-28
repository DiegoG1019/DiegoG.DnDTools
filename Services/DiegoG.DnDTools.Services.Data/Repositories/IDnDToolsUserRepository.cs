using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiegoG.DnDTools.InventoryManager;
using DiegoG.DnDTools.Services.Common;
using DiegoG.DnDTools.Services.Common.Requests;
using DiegoG.DnDTools.Services.Data.Internal;

namespace DiegoG.DnDTools.Services.Data.Repositories;

public interface IDnDToolsUserRepository : ICreateReadDeleteRepository<DnDToolsUser, DnDToolsUserCreationModel>;