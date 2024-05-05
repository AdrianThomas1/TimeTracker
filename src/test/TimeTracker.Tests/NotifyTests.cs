

using TimeTracker.ViewModel;

namespace TimeTracker.Tests;


public class NotifyTests : IClassFixture<ServiceProviderFixture>
{
    private ServiceProvider _serviceProvider;
    private readonly TimeTrackerDbContext _dbContext;

    public NotifyTests(ServiceProviderFixture spFixture)
    {
        _serviceProvider = spFixture.ServiceProvider;
        _dbContext = _serviceProvider.GetRequiredService<TimeTrackerDbContext>();
        Seed();
        
    }

    private void Seed()
    {
        if (_dbContext.Clients.Count() > 0)
            return;

        _dbContext.Clients.Add(new Model.Client
        {
            Id = 1,
            Name = "Client1",
            IsDeleted = false
        });

        _dbContext.Clients.Add(new Model.Client
        {
            Id = 2,
            Name = "Client2",
            IsDeleted = false
        });

        var client = _dbContext.Clients.Local.Where(c => c.Id == 1).SingleOrDefault();

        _dbContext.Projects.Add(new Model.Project
        {
            Id = 1,
            Name = "Client1Project1",
            Client = client,
            IsProductive = true,
            IsBillable = true,
            IsDeleted = false
        });

        _dbContext.SaveChanges();
    }

    [Fact]
    public async Task DatabaseUpdateMustSucceed()
    {
        var projects = await _dbContext.Projects.ToListAsync();
        var projectId = projects.First().Id;
        var project = projects.Where(p => p.Id == projectId).FirstOrDefault();
        var currentHours = project.Hours;
        project.Hours = project.Hours + 10;
        _dbContext.SaveChanges();
        project = await _dbContext.Projects.Where(p => p.Id == projectId).FirstAsync();
        project.Hours.Should().Be(currentHours + 10);
    }

    
    [Fact]
    public async Task ChangesToProjectModelMustNotifyViewModel()
    {
        /*
        var projectModel = await _dbContext.Projects.Where(p => p.Id == 1).FirstAsync();
        var projectViewModel = new ProjectVM(projectModel);

        projectViewModel.Project.Should().Be(projectModel.Name);

        // Update the model
        projectModel.Name = "1234";

        projectViewModel.Project.Should().Be(projectModel.Name);
        */

        var projectsViewModel = _serviceProvider.GetRequiredService<ProjectsViewModel>();
        var projects = projectsViewModel.Projects;

    }
    
}
