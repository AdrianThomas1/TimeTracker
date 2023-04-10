using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace TimeTracker.Models
{
    public class Client
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
        
        //public bool IsDeleted { get; set; }
        /*
        public virtual ICollection<Project> Projects
        {
            get;
            private set;
        } = new ObservableCollection<Project>();
        */
    }

    
}
