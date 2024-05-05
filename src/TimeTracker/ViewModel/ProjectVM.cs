using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model;

namespace TimeTracker.ViewModel
{
    public class ProjectVM : PropertyObservable
    {
        //https://learn.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-implement-property-change-notification?view=netframeworkdesktop-4.8
        private readonly Project _project;
        
        public ProjectVM(Model.Project project)
        {
            _project = project;

        }

        public Project Model
        {
            get
            {
                return _project;
            }
        }

        public ProjectVM()
        {
            _project = new Project();
            _project.Client = new Client();
        }

        public string Client
        {
            get
            {
                return _project.Client.Name;
            }
            set
            {
                _project.Client.Name = value;
                OnPropertyChanged(nameof(Client));
            }
        }

        public string Project
        {
            get
            {
                return _project.Name;
            }
            set
            {
                _project.Name = value;
                OnPropertyChanged(nameof(Client));
            }
        }

        

    }
}
