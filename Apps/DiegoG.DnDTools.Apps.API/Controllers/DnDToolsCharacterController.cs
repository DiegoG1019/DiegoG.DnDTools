using DiegoG.DnDTools.Services.Data.Repositories;
using DiegoG.DnDTools.Services.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DiegoG.DnDTools.Services.Common.Requests;

namespace DiegoG.DnDTools.Apps.API.Controllers;

[ApiController]
[Route("/api/character")]
public class DnDToolsCharacterController
    (IDnDToolsCharacterRepository repository, UserManager<DnDToolsUser> userManager, ILogger<DnDToolsCharacterController> logger) 
    : CRUDController<DnDToolsCharacter, DnDToolsCharacterCreationModel, DnDToolsCharacterUpdateModel>(repository, userManager, logger)
{
    
}
