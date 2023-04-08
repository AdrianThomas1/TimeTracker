using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Migrate
{
    class Program
    {
        

        private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            IServiceProvider serviceProvider = ConfigureServices(services);
            var migrator = serviceProvider.GetRequiredService<IMigrator>();
            migrator.Migrate();

        }

        private static IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.AddDbContext<TimeTracker.DbContext.TimeTrackerDbContext>(options =>
            {
                options.UseSqlite($"Data Source = {Configuration.GetSection("database").Value}");
            });


            services.AddMigratorService(options =>
            {
                options.SourceDb = $"Data Source = {Configuration.GetSection("sourceDb").Value}";
            });
            
            return services.BuildServiceProvider();
        }
    }
}
