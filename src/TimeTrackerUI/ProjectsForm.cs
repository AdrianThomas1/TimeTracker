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
        private ComboBox curCombo;
        //private readonly TimeTrackerDbContext dbContext;
        public ProjectsForm(IServiceProvider serviceProvider, ProjectsViewModel view)
        {
            InitializeComponent();
            vm = view ?? throw new ArgumentNullException(nameof(view));
            _services = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            dataGridViewProjects.AutoGenerateColumns = false;
            dataGridViewProjects.DataSource = view.Projects;
            dgvcClient.DataSource = vm.Clients;
            dgvcClient.DisplayMember = "Name";
            //dgvcClient.DataPropertyName = "Name";
            dgvcClient.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            dgvcClient.ValueMember = "Client";
            //dgvcClient.ValueType = typeof(Client);

            textBox1.DataBindings.Add(new Binding("Text", vm, "MyTextBox"));
            buttonSave.Command = vm.SaveCommand;
            this.dataGridViewOffset = this.Width - (dataGridViewProjects.Width);


            curCombo = new ComboBox();
            curCombo.DataSource = vm.Clients;
            curCombo.DisplayMember = "Name";
            curCombo.DropDownStyle = ComboBoxStyle.DropDownList;

            /*
            comboBox1.DataSource = vm.Clients;
            comboBox1.DisplayMember = "Name";
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            */
        }



        /*
        private void ComboBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            var cmb = (ComboBox)sender;
            System.Diagnostics.Debug.WriteLine(cmb.SelectedValue.GetType().ToString());
            var c = (Client)cmb.SelectedValue;
            System.Diagnostics.Debug.WriteLine(c.Id);
            throw new NotImplementedException();
        }
        */

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







        private void dataGridViewProjects_EditingControlShowing_1(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridViewProjects.Columns[dataGridViewProjects.CurrentCell.ColumnIndex].HeaderText == "xClient")
            {

                curCombo = e.Control as ComboBox;
                if (curCombo != null)
                {
                    curCombo.SelectedIndexChanged -= new EventHandler(curCombo_SelectedIndexChanged);
                    curCombo.SelectedIndexChanged += new EventHandler(curCombo_SelectedIndexChanged);
                }

            }
        }

        private void curCombo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            curCombo.SelectedIndexChanged -= new EventHandler(curCombo_SelectedIndexChanged);
            var cmb = (ComboBox)sender;
            System.Diagnostics.Debug.WriteLine(cmb.SelectedValue.GetType().ToString());
            var c = (Client)cmb.SelectedValue;
            //dataGridViewProjects.CurrentRow.Cells["dgvcClient"].Value = c;
            vm.CurrentItem.Client = c;
            //System.Diagnostics.Debug.WriteLine(c.Id);
            //throw new NotImplementedException();
        }

        /*
        private void dataGridViewProjects_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewProjects.Columns[dataGridViewProjects.CurrentCell.ColumnIndex].HeaderText == "Client")
            {
                if (curCombo != null)
                {
                    curCombo.SelectedIndexChanged -= new EventHandler(curCombo_SelectedIndexChanged);
                }
            }
        }
        */
    }


}
