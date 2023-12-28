using DiegoG.DnDTools.Services.Data.Repositories;
using DiegoG.DnDTools.Services.EntityFramework.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DiegoG.DnDTools.Services.EntityFramework;

public static class DnDToolsContextExtensions
{
    public static IServiceCollection AddDnDToolsEntityFrameworkServices(this IServiceCollection services)
    {
        services.AddScoped<IDnDToolsUserRepository, EntityFrameworkDnDToolsUserRepository>();
        services.AddScoped<IDnDToolsCharacterRepository, EntityFrameworkDnDToolsCharacterRepository>();
        services.AddScoped<IItemDescriptionRepository, EntityFrameworkItemDescriptionRepository>();
        services.AddScoped<IInventoryRepository, EntityFrameworkInventoryRepository>();
        return services;
    }
}