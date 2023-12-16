using MediatrDemo.Domain.Entities;
using MediatrDemo.Infrastructure.Persistence.Contexts;
using Meziantou.Extensions.Logging.Xunit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace MediatrDemo.IntegrationTests;

internal class WebApiTestFixture : WebApplicationFactory<Program>
{
    private readonly ITestOutputHelper _testOutputHelper;

    public WebApiTestFixture(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    public ICollection<Person> Persons { get; private set; }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddProvider(new XUnitLoggerProvider(_testOutputHelper));
        });

        builder.ConfigureAppConfiguration((_, configBuilder) =>
        {
        });

        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll<DbContextOptions<PersonDbContext>>();
            services.RemoveAll<PersonDbContext>();
            services.AddDbContext<PersonDbContext>(options =>
            {
                options.UseSqlite("Data Source=PersonsDatabaseForTests.db");
            });

            var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
            var scopedServiceProvider = scope.ServiceProvider;
            var context = scopedServiceProvider.GetRequiredService<PersonDbContext>();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            Persons = context.Set<Person>().ToList();
        });
    }
}
