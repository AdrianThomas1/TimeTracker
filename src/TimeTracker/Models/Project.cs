using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTracker.Models
{
    public class Project
    {
        public int Id { get; set; }
        
        public virtual Client Client {get; set;}
        public string Source { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsProductive { get; set; }
        
        public bool IsBillable { get; set; }

        public bool IsEnabled { get; set; }

        public bool IsDeleted { get; set; }

        public int Hours { get; set; }

    }
}
