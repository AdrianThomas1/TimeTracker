using FluentAssertions.Equivalency;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using TimeTracker.ViewModel;
using Xunit.Abstractions;

namespace TimeTracker.Tests
{
    public class BindingListViewTests : IClassFixture<ServiceProviderFixture>
    {
        private ServiceProvider _serviceProvider;
        private readonly TimeTrackerDbContext _dbContext;
        private readonly ITestOutputHelper output;

        public BindingListViewTests(ServiceProviderFixture spFixture, ITestOutputHelper output)
        {
            this.output = output;
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

            _dbContext.Projects.Add(new Model.Project
            {
                Id = 2,
                Name = "Client2Project1",
                Client = client,
                IsProductive = true,
                IsBillable = true,
                IsDeleted = false
            });


            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task FilteringDoesNotMessWithEFTracking()
        {
            var vm = _serviceProvider.GetRequiredService<ProjectsViewModel>();
            await vm.Load();
            vm.Projects.Refresh();
            vm.Projects.Count().Should().Be(2);

            
            vm.MyTextBox = "NotOK";
            vm.SaveCommand.CanExecute(CancellationToken.None).Should().BeFalse();
            vm.MyTextBox = "OK";
            vm.SaveCommand.CanExecute(CancellationToken.None).Should().BeTrue();

            await vm.SaveCommand.ExecuteAsync(CancellationToken.None);
            WriteStates();

            vm.Projects.Last().IsDeleted = true;

            output.WriteLine($"Item count: {vm.Projects.Count}");
            vm.ShowHideDeleted.Execute(null); // Show Deleted
            output.WriteLine($"Item count: {vm.Projects.Count}");
            vm.Projects.Last().IsDeleted = true;
            vm.ShowHideDeleted.Execute(null); // Show Active
            output.WriteLine($"Item count: {vm.Projects.Count}");
            vm.ShowHideDeleted.Execute(null); // Show Deleted
            vm.Projects.First().IsDeleted = false;
            vm.ShowHideDeleted.Execute(null); // Show Active
            output.WriteLine($"Item count: {vm.Projects.Count}");

            await vm.SaveCommand.ExecuteAsync(CancellationToken.None);
            WriteStates();

        }

        private void WriteStates()
        {
            var changes = _dbContext.ChangeTracker;
            output.WriteLine($"Unchanged: {changes.Entries().Where(c => c.State == EntityState.Unchanged).Count()}");
            output.WriteLine($"Modified: {changes.Entries().Where(c => c.State == EntityState.Modified).Count()}");
            output.WriteLine($"Added: {changes.Entries().Where(c => c.State == EntityState.Added).Count()}");
            output.WriteLine($"Deleted: {changes.Entries().Where(c => c.State == EntityState.Deleted).Count()}");
            output.WriteLine($"Detached: {changes.Entries().Where(c => c.State == EntityState.Detached).Count()}");

            /*
            foreach (var change in _dbContext.ChangeTracker.Entries())
            {
                output.WriteLine($"{change.Entity.GetType().ToString()}");
            }
            */
        }
    }
}
