
//using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TimeTracker;
using TimeTracker.ViewModel;

namespace TimeTrackerUI
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
            .Build();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
            
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();

            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                serviceProvider.GetRequiredService<TimeTrackerDbContext>().Database.Migrate();
                var form1 = serviceProvider.GetRequiredService<ProjectsForm>();
                Application.Run(form1);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<TimeTrackerDbContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("Default"));
                options.UseLazyLoadingProxies();
            });
            services.AddLogging(configure => configure.AddConsole());
            services.AddScoped<MainForm>();
            services.AddScoped<ClientsForm>();
            services.AddScoped<ProjectsForm>();
            services.AddSingleton<ProjectsViewModel>();
            services.AddTransient<ProjectForm>();
        }
    }

    
}