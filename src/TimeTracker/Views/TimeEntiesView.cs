using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TimeTracker.DbContext;
using System.Linq;
using System.Collections.ObjectModel;

namespace TimeTracker.Views
{
    public class TimeEntiesView
    {
        private readonly TimeTrackerDbContext _context;
        private IEnumerable<Models.TimeEntry> _entries;
        
        public TimeEntiesView(TimeTrackerDbContext DbContext)
        {
            this._context = DbContext ?? throw new ArgumentNullException(nameof(DbContext));
            Initialize();
        }

        public IEnumerable<Models.TimeEntry> TimeEntries
        {
            get { return _entries; }
        }

        private async void Initialize()
        {
            await _context.TimeEntries.LoadAsync();
            //_entries = _context.TimeEntries.Local.ToObservableCollection();
        }
    }
}
