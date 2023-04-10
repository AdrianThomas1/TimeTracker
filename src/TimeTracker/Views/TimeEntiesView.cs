using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TimeTracker.DbContext;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace TimeTracker.Views
{
    public class TimeEntiesView
    {
        private readonly TimeTrackerDbContext _context;
       // private IEnumerable<Models.TimeEntry> _entries;
        
        public TimeEntiesView(TimeTrackerDbContext DbContext)
        {
            this._context = DbContext ?? throw new ArgumentNullException(nameof(DbContext));
            Initialize();
        }

        public IEnumerable<Models.TimeEntry> TimeEntries()
        {
            _context.TimeEntries.LoadAsync();
            return _context.TimeEntries
                .Local.ToObservableCollection();
        }

        
        private void Initialize()
        {
            _context.TimeEntries.Load();
            _context.Clients.Load();
            //_entries = _context.TimeEntries.Local.ToObservableCollection();
        }
        

        public IEnumerable<Models.Client> Clients()
        {
            return _context.Projects
                .Select(p => p.Client)
                .OrderBy(p => p.Name)
                .ToList();
        }
    }
}
