using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTracker.Models
{
    public class TimeEntry
    {
        public int Id { get; set; }
        
        public DateTime StartTime { get; set; }
        
        public DateTime EndTime { get; set; }
        
        public virtual Project Project { get; set; }
        
        public string EntryType { get; set; } 
        
        public string Task { get; set; }
        
        public string Comment { get; set; }
        
        public bool isDeleted { get; set; }

        public bool isCaptured { get; set; }
        
        [NotMapped]
        public double Duration
        {
            get
            {
                return EndTime.Subtract(StartTime).TotalHours;
            }
        }

    }
}
