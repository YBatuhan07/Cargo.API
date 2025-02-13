using Cargo.Repository.Abstract;
using Cargo.Repository.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cargo.Repository;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ICarrierRepository, CarrierRepository>();
        services.AddScoped<ICarrierConfigurationRepository, CarrierConfigurationRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
