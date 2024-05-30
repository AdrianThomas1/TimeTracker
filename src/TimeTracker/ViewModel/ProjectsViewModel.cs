using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TimeTracker.Model;

namespace TimeTracker.ViewModel;

public class ProjectsViewModel : PropertyObservable
{
    private readonly TimeTrackerDbContext _dbContext;
    //private readonly RelayCommand _saveCommand;
    private readonly AsyncRelayCommand _saveCommand;
    private readonly RelayCommand _showHideDeleted;
    //private readonly RelayCommand _loadCommand;
    private string _txt = "OK";
    private bool _showDeleted = false;
    //private BindingList<ViewModel.ProjectVM> _projects;
    private BindingListView<ProjectVM>? _projects;
    
    

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
        this._dbContext.Database.EnsureCreated();
        //this._saveCommand = new RelayCommand(Save, CanExecuteSaveCommand);
        this._saveCommand = new AsyncRelayCommand(Save, CanExecuteSaveCommand);
        this._showHideDeleted = new RelayCommand(ToggleDeletedItemsView, CanExecuteTrue);
        //this._loadCommand = new RelayCommand(Load, CanExecuteTrue);
    }


    


    public async Task Load()
    {
        await _dbContext.Projects
            .IgnoreQueryFilters()
            .LoadAsync();
        await _dbContext.Clients
            .IgnoreQueryFilters()
            .LoadAsync();

        _projects = new BindingListView<ProjectVM>(
            new BindingList<ProjectVM>(_dbContext
            .Projects
            .Local
            .Select(p => new ProjectVM(p))
            .ToList()));

        _projects.FilterPredicate = delegate (ProjectVM projectVM)
        {
            return projectVM.IsDeleted == _showDeleted;
        };

        
    }



    /// <summary>
    ///  Command that is bound to the button of the Form.
    ///  When the button is clicked, the command is executed.
    /// </summary>
    public IAsyncRelayCommand SaveCommand
    {
        get => _saveCommand;
        /*
        set
        {
            if (_saveCommand == value)
            {
                return;
            }

            _saveCommand = value;
        }
        */
    }

    public RelayCommand ShowHideDeleted
    {
        get => _showHideDeleted;
        /*
        set
        {
            if (_showHideDeleted == value)
            {
                return;
            }
            _showHideDeleted = value;
        }
        */
    }

    public BindingList<Model.Client> Clients
    {
        get
        {
            return new BindingList<Model.Client>(_dbContext
                .Clients
                .Local
                .OrderBy(c => c.Name).ToList());
        }
    }

    public BindingListView<ProjectVM> Projects
    {
        get
        {
            return _projects;
        }
    }



    private void LoadProjects()
    {
        /*
        _projects = new BindingListView<ProjectVM>(
            new BindingList<ProjectVM>(
                _dbContext.Projects
                .IgnoreQueryFilters()
                .OrderBy(p => p.Name)
                .Select(p => new ViewModel.ProjectVM(p))
                .ToList())
            );
        */
        //_projects.FilterAction = Filter;
        //_projects.Filter = new Predicate<object>(Filter);
            
        /*
        foreach (var p in _dbContext.Projects.IgnoreQueryFilters().ToList())
        {
            _projects.Add(new ProjectVM(p));
        }
        */
        
        /*
        if (_showDeleted)
        {
            _projects = new BindingList<ProjectVM>(
                _dbContext.Projects
                .IgnoreQueryFilters()
                .OrderBy(p => p.Name)
                .Select(p => new ViewModel.ProjectVM(p))
                .ToList());
        }
        else
        {
            _projects = new BindingList<ProjectVM>(
                _dbContext.Projects
                .OrderBy(p => p.Client.Name)
                .ThenBy(p => p.Name)
                .Select(p => new ViewModel.ProjectVM(p))
                .ToList());
		}
        */
    }

    

    /*
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
    */

    public bool CanExecuteTrue() => true;


    public bool CanExecuteSaveCommand()
    {
        return this._txt == "OK";
    }

    private void ToggleDeletedItemsView()
    {
        this._showDeleted = !this._showDeleted;
        _projects.Refresh();
    }

    private async Task Save()
    {
        await _dbContext.SaveChangesAsync();
        
    }

    public void Add(ViewModel.ProjectVM project)
    {
        _dbContext.Projects.Add(project.Model);
    }

    public void Remove(ViewModel.ProjectVM project)
    {
        _dbContext.Projects.Remove(project.Model);
    }
}




