using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Windows.Input;
using TimeTracker.Model;

namespace TimeTracker.ViewModel;

public class ProjectsViewModel : PropertyObservable
{
    private readonly TimeTrackerDbContext _dbContext;
    private RelayCommand _saveCommand;
    private string _txt = "111";
    
    
    private bool CanSave()
    {
        return (this.MyTextBox == "OK");
    }
    public string MyTextBox
    {
        get { return _txt; }
        set
        {
            _txt = value;
            _saveCommand.NotifyCanExecuteChanged();
            OnPropertyChanged("MyTextBox");

        }
    }

    public ProjectsViewModel(TimeTrackerDbContext dbContext)
    {
        this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        this._saveCommand = new RelayCommand(Save, CanExecuteSaveCommand);
        
    }

    /// <summary>
    ///  Command that is bound to the button of the Form.
    ///  When the button is clicked, the command is executed.
    /// </summary>
    public RelayCommand SaveCommand
    {
        get => _saveCommand;
        set
        {
            if (_saveCommand == value)
            {
                return;
            }

            _saveCommand = value;
            //OnPropertyChanged("SaveCommand");
        }
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

    private ProjectVM _currentItem;
    public ProjectVM CurrentItem
    {
        get
        {
            return _currentItem;
        }
        set
        {
            _currentItem = value;
        }
    }


    public bool CanExecuteSaveCommand()
    {
        return this._txt == "OK";
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




