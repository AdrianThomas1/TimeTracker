using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TimeTracker.Model;
using System.Linq.Dynamic.Core;
using System.Data;

namespace TimeTracker.ViewModel;

public class ProjectsViewModel : PropertyObservable
{
    private readonly TimeTrackerDbContext _dbContext;
    //private readonly RelayCommand _saveCommand;
    private readonly AsyncRelayCommand _saveCommand;
    private readonly RelayCommand _toggleDeletedItemsViewCommand;
    //private readonly RelayCommand _loadCommand;
    private bool _showDeleted = false;
    private string _showDeletedMenuText = "Show &Deleted";
    //private BindingList<ViewModel.ProjectVM> _projects;
    //private BindingListView<ProjectVM>? _projects;
    private DataTable _projects;
    

    public ProjectsViewModel(TimeTrackerDbContext dbContext)
    {
        this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        this._dbContext.Database.EnsureCreated();
        this._saveCommand = new AsyncRelayCommand(Save, CanExecuteSaveCommand);
        //this._toggleDeletedItemsViewCommand = new RelayCommand(ToggleDeletedItemsView, CanExecuteTrue);
    }


    public string[] Sources
    {
        get
        {
            return new string[] { "EPM", "ITSM" };
        }
    }


    public async Task Load()
    {
        await _dbContext.Projects
            .IgnoreQueryFilters()
            .LoadAsync();
            
        await _dbContext.Clients
            .IgnoreQueryFilters()
            .LoadAsync();


        _projects = ToDataTable(_dbContext.Projects.Local.ToList());

        /*
        _projects = new BindingListView<ProjectVM>(
            new BindingList<ProjectVM>(_dbContext
            .Projects
            .Local
            .Select(p => new ProjectVM(p))
            .ToList()));

        _projects.FilterPredicate = IsFiltered;
        */
    }

    private DataTable ToDataTable(List<Project> projects)
    {
        DataTable dt = new DataTable();
        // Headers
        var properties = typeof(Project).GetProperties().ToList();
        foreach (var prop in properties)
        {
           dt.Columns.Add(prop.Name, prop.PropertyType);
        }
        
        foreach (var project in projects)
        {
            var r = dt.NewRow();
            foreach (var prop in properties)
            {
                r[prop.Name] = prop.GetValue(project);
            }
            dt.Rows.Add(r);
        }
        return dt;
    }

    public bool ShowDeleted
    {
        get
        {
            return _showDeleted;
        }
    }

    public string ViewHideDeletedMenuText
    {
        get
        {
            return _showDeletedMenuText;
        }
    }
    private void DataSouce_AddingNew(object? sender, AddingNewEventArgs e)
    {
        //var p = new ProjectVM();
        //_dbContext.Projects.Local.Add(p.Model);

        //e.
        //throw new NotImplementedException();
    }

    private void _projects_AddingNew(object? sender, AddingNewEventArgs e)
    {
        /*
        var p = new ProjectVM();
        p.Model.Name = "sssss";
        e.NewObject = p;
        _dbContext.Projects.Local.Add(p.Model);
        //throw new NotImplementedException();
        */
    }

    /*
    private bool IsFiltered(ProjectVM item)
    {
        return item.IsDeleted == _showDeleted;
    }
    */

    /*
    private BindingList<ProjectVM> RebuildBindingList()
    {
        return
            new BindingList<ProjectVM>(_dbContext
            .Projects
            .Local
            .Select(p => new ProjectVM(p))
            .ToList());
    }
    */

    /// <summary>
    ///  Command that is bound to the button of the Form.
    ///  When the button is clicked, the command is executed.
    /// </summary>
    public IAsyncRelayCommand SaveCommand
    {
        get => _saveCommand;
    }

    public RelayCommand ToggleViewDeletedItemsCommand
    {
        get => _toggleDeletedItemsViewCommand;
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

    public DataTable Projects
    {
        get
        {
            return _projects;
        }
    }

    /*
    public BindingListView<ProjectVM> Projects
    {
        get
        {
            return _projects;
        }
    }
    */


    

    private bool CanExecuteTrue() => true;


    private bool CanExecuteSaveCommand()
    {
        return _dbContext.ChangeTracker.HasChanges();
    }

    /*
    private void ToggleDeletedItemsView()
    {
        this._showDeleted = !this._showDeleted;
        if (! _showDeleted)
        {
            _showDeletedMenuText = "Show &Deleted";
        }
        else
        {
            _showDeletedMenuText = "Hide &Deleted";
        }
        OnPropertyChanged("ViewHideDeletedMenuText");
        _projects.Refresh();
    }
    */

    private async Task Save()
    {
        //Test();
        await _dbContext.SaveChangesAsync();
        //_projects.Refresh();
    }

    /*
    public void Test()
    {
        try
        {
            string exp1 = "Client.Name=\"CFS\"";
            var results = _projects.DataSource.AsQueryable().Where(exp1);
        }
        catch (Exception ex)
        {

        }
    }
    */


    public void Add(ViewModel.ProjectVM project)
    {
        //_dbContext.Projects.Local.Add(project.Model);
        //_projects.DataSource.Add(project);
        //_saveCommand.NotifyCanExecuteChanged();
        /*
        if (_dbContext.Projects.Local.Where(p => p.Id == project.Model.Id).Count() == 0)
        {
            //_projects?.Add(project);
            _dbContext.Projects.Local.Add(project.Model);
            //_projects.DataSource = RebuildBindingList();
            //_projects.DataSource.Add(project);
            _saveCommand.NotifyCanExecuteChanged();
        }*/
    }
    

    public void Remove(ViewModel.ProjectVM project)
    {
        //project.IsDeleted = true;
        //_projects.Refresh();
        //_saveCommand.NotifyCanExecuteChanged();
    }
}




