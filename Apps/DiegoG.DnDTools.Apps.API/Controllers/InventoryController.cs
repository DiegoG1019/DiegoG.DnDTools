using DiegoG.DnDTools.Services.Data.Repositories;
using DiegoG.DnDTools.Services.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DiegoG.DnDTools.Services.Common.Requests;

namespace DiegoG.DnDTools.Apps.API.Controllers;

[ApiController]
[Route("/api/inventory/inventories")]
public class InventoryController
    (IInventoryRepository repository, UserManager<DnDToolsUser> userManager, ILogger<InventoryController> logger)
    : CRUDController<InventoryModel, InventoryCreationModel, InventoryUpdateModel>(repository, userManager, logger)
{

}
