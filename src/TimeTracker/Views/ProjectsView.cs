using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TimeTracker.DbContext;
using System.Linq;
using System.Collections.ObjectModel;

namespace TimeTracker.Views
{
    public interface IProjectsView
    {
        
    }
    public class ProjectsView
    {
        private readonly TimeTrackerDbContext _context;
        private IEnumerable<Models.Project> _projects;
        public ProjectsView(TimeTrackerDbContext DbContext)
        {
            this._context = DbContext ?? throw new ArgumentNullException(nameof(DbContext));
            Initialize();
        }

        private async void Initialize()
        {
            await _context.Clients.LoadAsync();
            await _context.Projects.LoadAsync();
            //_context.Clients.Local.ToObservableCollection();
            _projects = _context.Projects.Local.ToObservableCollection();

        }

        public IEnumerable<Models.Client> Clients
        {
            get { return _context.Clients.Local.ToObservableCollection(); }
        }

        public IEnumerable<Models.Project> Projects
        {
            get
            {
                return _projects;
                
            }
        }

        public void RefreshProjects()
        {
            _projects = new ObservableCollection<Models.Project>(
                _context.Projects.Where(e => e.isDeleted == false)
                .ToList()
             );
            
        }

        public void ShowDeleted()
        {
            _projects = new ObservableCollection<Models.Project>(
                _context.Projects.IgnoreQueryFilters().Where(e => e.isDeleted == true)
                .ToList()
             );
        }

        public async void Save()
        {
            await _context.SaveChangesAsync();
            Initialize();
            
        }

    }
}
