
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TimeTracker.Model;

public class Project
{
    public int Id { get; set; }

    public virtual Client Client { get; set; } = null!;
    public string? Source { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool IsProductive { get; set; } = false;

    public bool IsBillable { get; set; } = false;

    public bool IsEnabled { get; set; } = true;

    public bool IsDeleted { get; set; } = false;

    public int Hours { get; set; } = 0;

    public DateTime WhenCreated { get; set; } = DateTime.UtcNow;

    public DateTime WhenModified { get; set; } = DateTime.UtcNow;
}
