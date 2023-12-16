using MediatrDemo.Application.Abstractions;
using MediatrDemo.Infrastructure.Persistence.Contexts;
using MediatrDemo.Infrastructure.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrDemo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IPersonRepository, PersonRepository>();
        services.AddDbContext<PersonDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("PersonsDBConnection"));
        });
        return services;
    }
}
