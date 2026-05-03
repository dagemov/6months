namespace Dagemov.Api.Extensions;

public static class ServiceAppExtension
{
    public static IServiceCollection ExtensionServices(this IServiceCollection services, IConfiguration config)
    {
        //var connectionString = config.GetConnectionString("Docker");
        //services.AddDbContext<DagemovDbContext>
        //(options => options.UseSqlServer(connectionString));

        return services;
    }
}
