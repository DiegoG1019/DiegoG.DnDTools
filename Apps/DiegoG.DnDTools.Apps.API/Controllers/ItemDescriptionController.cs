using DiegoG.DnDTools.Services.Data.Repositories;
using DiegoG.DnDTools.Services.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DiegoG.DnDTools.Services.Common.Requests;

namespace DiegoG.DnDTools.Apps.API.Controllers;

[ApiController]
[Route("/api/inventory/items")]
public class ItemDescriptionController
    (IItemDescriptionRepository repository, UserManager<DnDToolsUser> userManager, ILogger<ItemDescriptionController> logger)
    : CRUDController<IBaseItemDescriptionModel, ItemDescriptionCreationModel, ItemDescriptionUpdateModel>(repository, userManager, logger)
{

}
