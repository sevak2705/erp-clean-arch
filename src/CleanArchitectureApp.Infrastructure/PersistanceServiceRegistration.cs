using CleanArchitectureApp.Application.Interfaces;
using CleanArchitectureApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureApp.Infrastructure;

public static class PersistanceServiceRegistration
{

    public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<DatabaseContext.ErpDatabaseContext>(options =>
        //    options.UseSqlServer("Server=localhost;Database=ErpDb;User Id=sa;Password=yourStrong(!)Password;TrustServerCertificate=True;"));

        services.AddDbContext<DatabaseContext.ErpDatabaseContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("ErpDBConnectionString"),
               sqlServerOptionsAction: sqlOptions =>
               {
                   sqlOptions.EnableRetryOnFailure(
                       maxRetryCount: 5,
                       maxRetryDelay: TimeSpan.FromSeconds(30),
                       errorNumbersToAdd: null);
               }));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ICustomerContactRepository, CustomerContactRepository>();
        return services;

    }

}
