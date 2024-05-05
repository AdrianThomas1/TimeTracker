using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTracker;
using TimeTracker.Model;
using TimeTracker.ViewModel;

namespace TimeTrackerUI
{
    public partial class ProjectsForm : Form
    {
        private readonly ProjectsViewModel vm;
        //private readonly TimeTrackerDbContext dbContext;
        public ProjectsForm(ProjectsViewModel view)
        {
            //this.dbContext = context ?? throw new ArgumentNullException(nameof(context));
            InitializeComponent();
            vm = view ?? throw new ArgumentNullException(nameof(view));
            dataGridViewProjects.AutoGenerateColumns = false;
            dataGridViewProjects.DataSource = view.Projects;
            
            
            
            
            
        }

        private void DataGridViewProjects_RowsAdded(object? sender, DataGridViewRowsAddedEventArgs e)
        {
            var entry = (ProjectVM)dataGridViewProjects.Rows[e.RowIndex - 1].DataBoundItem;
            vm.Add(entry);
            //throw new NotImplementedException();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //this.dbContext.Projects.Load();
            //this.dbContext.Clients.Load();
            dataGridViewProjects.RowsAdded += DataGridViewProjects_RowsAdded;

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            //base.OnClosing(e);
            //this.clientBindingSource.DataSource = null;
            //this.dbContext?.Dispose();
        }

        /*
        private void buttonSave_Click(object sender, EventArgs e)
        {
            BindingList<ProjectVM> projects = (BindingList<ProjectVM>)this.dataGridViewProjects.DataSource;

            //projects.First().Client = "aaaa";
            vm.Save();
            //this.dbContext!.SaveChanges();
            //this.dataGridViewProjects.Refresh();
        }
        */
        
    }
}
