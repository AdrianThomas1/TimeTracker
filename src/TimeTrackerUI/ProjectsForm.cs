using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IServiceProvider _services;
        private int dataGridViewOffset = 0;
        //private readonly TimeTrackerDbContext dbContext;
        public ProjectsForm(IServiceProvider serviceProvider, ProjectsViewModel view)
        {
            InitializeComponent();
            vm = view ?? throw new ArgumentNullException(nameof(view));
            _services = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            dataGridViewProjects.AutoGenerateColumns = false;
            dataGridViewProjects.DataSource = view.Projects;
            dgvcClient.DataSource = vm.Clients;
            //dgvcClient.ValueMember = "Client";
            dgvcClient.ValueType = typeof(Client);
            
            textBox1.DataBindings.Add(new Binding("Text", vm, "MyTextBox"));
            buttonSave.Command = vm.SaveCommand;
            this.dataGridViewOffset = this.Width - (dataGridViewProjects.Width);

            //AddClientsColumn();

            MyComboBoxColumn col =
            new MyComboBoxColumn();
            dataGridViewProjects.Columns.Add(col);
            col.DataSource = vm.Clients;
            col.Name = "RollOver";
            // col.DefaultCellStyle.Format = "##:##";
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
        int i = 0;
        private void dataGridViewProjects_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex == 0)
                return;

            vm.CurrentItem = (ProjectVM)((DataGridView)sender).Rows[e.RowIndex].DataBoundItem;
        }

        private void dataGridViewProjects_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var frm = _services.GetRequiredService<ProjectForm>();
            frm.ShowDialog(this);
            frm.Close();
        }


        private void ProjectsForm_Resize(object sender, EventArgs e)
        {
            dataGridViewProjects.Width = this.Width - this.dataGridViewOffset;
        }

        private void dataGridViewProjects_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            i++;
            this.textBox1.Text = i.ToString();
        }

        private void AddClientsColumn()
        {
            DataGridViewComboBoxColumn comboBoxColumn =
                new DataGridViewComboBoxColumn();
            comboBoxColumn.Items.AddRange(
                vm.Clients);
            comboBoxColumn.ValueType = typeof(Client);
            dataGridViewProjects.Columns.AddRange(comboBoxColumn);
            dataGridViewProjects.EditingControlShowing +=
                new DataGridViewEditingControlShowingEventHandler(
                dataGridViewProjects_EditingControlShowing);
        }

        private void dataGridViewProjects_EditingControlShowing(object sender,
    DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox combo = e.Control as ComboBox;
            if (combo != null)
            {
                // Remove an existing event-handler, if present, to avoid 
                // adding multiple handlers when the editing control is reused.
                combo.SelectedIndexChanged -=
                    new EventHandler(ComboBox_SelectedIndexChanged);

                // Add the event handler. 
                combo.SelectedIndexChanged +=
                    new EventHandler(ComboBox_SelectedIndexChanged);
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //((ComboBox)sender).BackColor = (Client)((ComboBox)sender).SelectedItem;
        }


        /*
        private void dataGridViewProjects_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string property = dataGridViewProjects.Columns[e.ColumnIndex].DataPropertyName;
            object value = dataGridViewProjects[e.ColumnIndex, e.RowIndex].Value;
            try
            {
                vm.ValidateEntry(property, value);
                dataGridViewProjects.EndEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        */

        /*
        private void dataGridViewProjects_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            // Check if validation is required.  Check the state of client if it is dirty.
            // Do this on the Project VM
            if (dataGridViewProjects.Columns[e.ColumnIndex].DataPropertyName == "Client")
            {
                //projectViewModel
                var projectVMInstance = (ProjectVM)dataGridViewProjects.Rows[e.RowIndex].DataBoundItem;
                vm.CurrentItem = projectVMInstance; 
                if (vm.ClientValidationRequired())
                {

                }
                
            }
        }
        */


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
