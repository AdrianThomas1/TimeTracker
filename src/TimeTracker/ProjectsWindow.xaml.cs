using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TimeTracker
{
    /// <summary>
    /// Interaction logic for ProjectsWindow.xaml
    /// </summary>
    public partial class ProjectsWindow : Window
    {
        private readonly IServiceProvider service;
        private readonly Views.ProjectsView vm;
        private CollectionViewSource clientViewSource;
        private CollectionViewSource projectViewSource;
        public ProjectsWindow(IServiceProvider serviceProvider, Views.ProjectsView view)
        {
            InitializeComponent();
            service = serviceProvider;
            vm = view;
            clientViewSource = (CollectionViewSource)FindResource(nameof(clientViewSource));
            projectViewSource = (CollectionViewSource)FindResource(nameof(projectViewSource));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            clientViewSource.Source = vm.Clients;
            projectViewSource.Source = vm.Projects;

        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            vm.Save();
            vm.RefreshProjects();
            projectViewSource.View.Refresh();
            
        }

        private void Button_Click_ShowDeleted(object sender, RoutedEventArgs e)
        {
            var button = (System.Windows.Controls.Button)e.Source;
            if (button.Content.ToString() == "Show Deleted")
            {
                vm.ShowDeleted();
                button.Content = "Show Active";
            }
            else
            {
                vm.RefreshProjects();
                button.Content = "Show Deleted";
            }
            projectViewSource.Source = vm.Projects;
        }

        private void Context_Undelete_Click(object sender, RoutedEventArgs e)
        {
            //Get the clicked MenuItem
            var menuItem = (MenuItem)sender;

            //Get the ContextMenu to which the menuItem belongs
            var contextMenu = (ContextMenu)menuItem.Parent;

            //Find the placementTarget
            var grid = (DataGrid)contextMenu.PlacementTarget;
            foreach (Models.Project item in grid.SelectedItems)
            {
                item.IsDeleted = false;
            }
            vm.Save();
            vm.ShowDeleted();
            //Get the underlying item, that you cast to your object that is bound
            //to the DataGrid (and has subject and state as property)
            //var toDeleteFromBindedList = (YourObject)item.SelectedCells[0].Item;

            //Remove the toDeleteFromBindedList object from your ObservableCollection
            //yourObservableCollection.Remove(toDeleteFromBindedList);
        }
    }
}
