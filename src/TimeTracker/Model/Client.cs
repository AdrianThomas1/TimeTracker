
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTracker.Model;

public class Client : PropertyObservable
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ObservableCollection<Project> Projects { get; } = new();

    public DateTime WhenCreated { get; set; } = DateTime.UtcNow;

    public DateTime WhenModified { get; set; } = DateTime.UtcNow;


    [NotMapped]
    public Client Self
    {
        get
        {
            return this;
        }
    }
}


