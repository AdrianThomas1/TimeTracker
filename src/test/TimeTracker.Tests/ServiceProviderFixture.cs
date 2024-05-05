
using Microsoft.EntityFrameworkCore;
using TimeTracker.ViewModel;

namespace TimeTracker.Tests;

public class ServiceProviderFixture
{
    public ServiceProviderFixture()
    {
        var serviceCollection = new ServiceCollection();

        var options = new DbContextOptionsBuilder<TimeTrackerDbContext>()
            .UseInMemoryDatabase("Test")
        .Options;

        serviceCollection
        .AddDbContext<TimeTrackerDbContext>(options =>
        {
            options.UseInMemoryDatabase("Test");
        })
        .AddSingleton<ProjectsViewModel>();
        ServiceProvider = serviceCollection.BuildServiceProvider();

        ServiceProvider.GetRequiredService<TimeTrackerDbContext>().Database.EnsureCreated();
    }

    public ServiceProvider ServiceProvider { get; private set; }
}