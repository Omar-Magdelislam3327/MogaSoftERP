using Microsoft.Extensions.DependencyInjection;
using mogaERP.Domain.Interfaces.Common;
using mogaERP.Infrastructure.Reposatories;
using mogaERP.Infrastructure.Services;

namespace mogaERP.Infrastructure;
public static class InfrastructureModuleDependencies
{
    public static IServiceCollection AddInfrastructureModuleDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        return services;
    }
}
