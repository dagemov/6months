using Dagemov.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dagemov.Infrastructure;

public static class ServiceAppExtension
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("Docker");
        services.AddDbContext<DagemovDbContext>(options => options.UseSqlServer(connectionString));
        
        return services;
    }
}
