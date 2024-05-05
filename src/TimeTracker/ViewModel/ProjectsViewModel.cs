using Microsoft.EntityFrameworkCore;
using System.Windows.Input;
using TimeTracker.Model;

namespace TimeTracker.ViewModel;

public class ProjectsViewModel : PropertyObservable
{
    private readonly TimeTrackerDbContext _dbContext;
    public ICommand SaveIt { get; private set; }

    public ProjectsViewModel(TimeTrackerDbContext dbContext)
    {
        this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        SaveIt = new SaveCommand(this);
    }
       

    public BindingList<Model.Client> Clients
    {
        get
        {
            return new BindingList<Model.Client>(_dbContext.Clients.OrderBy(c => c.Name).ToList());
        }
    }

    public BindingList<ViewModel.ProjectVM> Projects
    {
        get
        {
            /*
            //return new BindingList<ProjectVM>(_dbContext.Projects.Select(p => new ProjectVM(p)));
            var test = new BindingList<ProjectVM>();
            foreach (var item in _dbContext.Projects)
            {
                test.Add(new ProjectVM(item));
            }
            return test;
            */
            return new BindingList<ViewModel.ProjectVM>(_dbContext.Projects.Select(p => new ViewModel.ProjectVM(p)).ToList());
                
        }
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    public void Add(ViewModel.ProjectVM project)
    {
        if (project.Model.Client.Id == 0)
        {
            _dbContext.Clients.Add(project.Model.Client);
        }
        _dbContext.Projects.Add(project.Model);
    }
   
    

    
}

class SaveCommand : ICommand
{
    ProjectsViewModel parent;

    public SaveCommand(ProjectsViewModel parent)
    {
        this.parent = parent ?? throw new ArgumentNullException(nameof(parent));
        parent.PropertyChanged += delegate { CanExecuteChanged?.Invoke(this, EventArgs.Empty); };
    }

    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        parent.Save();
    }


}
