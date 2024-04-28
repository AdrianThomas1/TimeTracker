using Microsoft.EntityFrameworkCore;
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

namespace TimeTrackerUI
{
    public partial class ProjectsForm : Form
    {

        private readonly TimeTrackerDbContext dbContext;
        public ProjectsForm(TimeTrackerDbContext context)
        {
            this.dbContext = context ?? throw new ArgumentNullException(nameof(context));
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.dbContext.Projects.Load();
            this.dbContext.Clients.Load();
            this.projectBindingSource.DataSource = this.dbContext.Projects.Local.ToBindingList();
            this.Client.ValueType = typeof(Client);
            this.Client.DataSource = this.dbContext.Clients.Local.ToBindingList();
            //this.Client.ValueMember = "Name";
            this.Client.DisplayMember = "Name";
            this.Client.ValueMember = "Name";

            //this.clientDataGridViewTextBoxColumn.DataSource = this.dbContext.Clients.Local.ToBindingList();
            //this.clientDataGridViewTextBoxColumn.DisplayMember = "Name";
            //this.clientDataGridViewTextBoxColumn.DataPropertyName = "Name";
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            //this.clientBindingSource.DataSource = null;
            this.dbContext?.Dispose();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.dbContext!.SaveChanges();
            this.dataGridViewProjects.Refresh();
        }

        private void dataGridViewProjects_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
