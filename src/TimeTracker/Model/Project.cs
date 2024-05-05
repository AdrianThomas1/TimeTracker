
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

    public bool IsProductive { get; set; }
    
    public bool IsBillable { get; set; }

    public bool IsEnabled { get; set; }

    public bool IsDeleted { get; set; }

    public int Hours { get; set; }
}
