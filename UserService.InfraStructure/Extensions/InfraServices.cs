using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.Core.Repositories;
using UserService.InfraStructure.Data;
using UserService.InfraStructure.Repositories;

namespace UserService.InfraStructure.Extensions;

public static class InfraServices 
{
    public static IServiceCollection AddInfraServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<UserContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("OrderingConnectionString"),
            sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));
        serviceCollection.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        return serviceCollection;
    }
}