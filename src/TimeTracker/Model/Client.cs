using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace TimeTracker.Model
{
    public class Client
    {
        public int Id { get; set; }
        
        public string? Name { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ObservableCollection<Project> Projects { get; } = new();   
    }

    
}
