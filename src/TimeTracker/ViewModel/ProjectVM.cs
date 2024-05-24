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
            //_project.Client = new Client();
        }

        

        public Client Client
        {
            get
            {
                return _project.Client;
            }
            set
            {

                _project.Client = value;
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
                OnPropertyChanged(nameof(Project));
            }
        }

        public string Source
        {
            get
            {
                return _project.Source;
            }
            set
            {
                _project.Source = value;
                OnPropertyChanged(nameof(Source));
            }
        }

        public string? Description
        {
            get
            {
                return _project.Description;
            }
            set
            {
                _project.Source = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public bool IsProductive
        {
            get
            {
                return _project.IsProductive;
            }
            set
            {
                _project.IsProductive = value;
                OnPropertyChanged(nameof(IsProductive));
            }
        }

        public bool IsBillable
        {
            get
            {
                return _project.IsBillable;
            }
            set
            {
                _project.IsBillable = value;
                OnPropertyChanged(nameof(IsBillable));
            }
        }

        public bool IsEnabled
        {
            get
            {
                return _project.IsEnabled;
            }
            set
            {
                _project.IsEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }

        public int Hours
        {
            get
            {
                return _project.Hours;
            }
            set
            {
                _project.Hours = value;
                OnPropertyChanged(nameof(Hours));
            }
        }
    }
}
