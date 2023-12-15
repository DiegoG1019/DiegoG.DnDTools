using Microsoft.Extensions.DependencyInjection;

namespace DiegoG.DnDTools.Services.EntityFramework;

public static class DnDToolsContextExtensions
{
    public static IServiceCollection AddDnDToolsEntityFrameworkServices(this IServiceCollection services)
    {
#error Create the repositories and add them here
        return services;
    }
}