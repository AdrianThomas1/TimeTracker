using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimeTracker.DbContext;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Models;
using Microsoft.Extensions.DependencyInjection;

namespace TimeTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IServiceProvider serviceProvider;
        private readonly Views.TimeEntiesView vm;
        private CollectionViewSource timeEntriesViewSource;

        public MainWindow(IServiceProvider serviceProvider, Views.TimeEntiesView view)
        {
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            this.vm = view;
            InitializeComponent();
            timeEntriesViewSource = (CollectionViewSource)FindResource(nameof(timeEntriesViewSource));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timeEntriesViewSource.Source = vm.TimeEntries;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var projectsWindows = serviceProvider.GetService<ProjectsWindow>();
            projectsWindows.Show();
        }

        private void timeEntriesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dg = (System.Windows.Controls.DataGrid)sender;
            
        }
    }
}
