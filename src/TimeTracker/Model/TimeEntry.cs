using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTracker.Model;

public class TimeEntry
{
    public int Id { get; set; }

    public DateTime StartTime { get; set; } = DateTime.Now.Date;
    
    public DateTime EndTime { get; set; }

    public virtual Project Project { get; set; } = null!;
    
    public string? Task { get; set; }
    
    public string? Comment { get; set; }
    
    public bool IsDeleted { get; set; }

    public bool IsCaptured { get; set; }

    public DateTime WhenCreated { get; set; } = DateTime.UtcNow;

    public DateTime WhenModified { get; set; } = DateTime.UtcNow;

    [NotMapped]
    public double Duration
    {
        get
        {
            return EndTime.Subtract(StartTime).TotalHours;
        }
    }

}
