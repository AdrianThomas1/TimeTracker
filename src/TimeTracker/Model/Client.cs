
namespace TimeTracker.Model;

public class Client : PropertyObservable
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ObservableCollection<Project> Projects { get; } = new();

    /*
    public override string ToString()
    {
        return this.Name;
    }
    */
    public Client Self
    {
        get
        {
            return this;
        }
    }
}


