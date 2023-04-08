using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Proxies;




namespace TimeTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        
        private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
            UpdateDatabase(serviceProvider);
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<TimeTrackerDbContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlite($"Data Source = {Configuration.GetSection("database").Value}");
            });
            services.AddSingleton<TimeEntryWindow>();
            services.AddSingleton<MainWindow>();
            services.AddTransient<ProjectsWindow>();
            services.AddScoped<Views.ProjectsView>();
            services.AddScoped<Views.TimeEntiesView>();
            //services.AddScoped<DbContext.TimeTrackerDbContext>();
        }

        private void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<TimeTrackerDbContext>();
            context.Database.Migrate();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var timeEntry = serviceProvider.GetRequiredService<TimeEntryWindow>();
            timeEntry.Show();
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

    }
}
