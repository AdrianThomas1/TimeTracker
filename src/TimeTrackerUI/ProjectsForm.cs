using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

            dgvcClient.Items.Add("Select");
            dgvcClient.DefaultCellStyle.NullValue = "Select";
            dgvcClient.DataPropertyName = "Client";
            dgvcClient.DisplayMember = "Name";
            dgvcClient.ValueMember = "Self";

            dgvcSource.DataPropertyName = "Source";
            dgvcSource.DefaultCellStyle.NullValue = "Select";

            dgvcSource.Items.AddRange(vm.Sources);
            buttonSave.Command = vm.SaveCommand;
            this.dataGridViewOffset = this.Width - (dataGridViewProjects.Width);

            curCombo = new ComboBox();
            curCombo.DataSource = vm.Clients;
            curCombo.DisplayMember = "Name";
            curCombo.DropDownStyle = ComboBoxStyle.DropDownList;

            this.showHideDeletedMenuItem.Command = vm.ToggleViewDeletedItemsCommand;
            this.showHideDeletedMenuItem.DataBindings.Add("Text", vm, "ViewHideDeletedMenuText");

            //dgvcIsDeleted.Visible = vm.ShowDeleted;

            dataGridViewProjects.UserDeletingRow += DataGridViewProjects_UserDeletingRow;
            dataGridViewProjects.UserAddedRow += DataGridViewProjects_UserAddedRow;
           //dataGridViewProjects.RowsAdded += DataGridViewProjects_RowsAdded;
            
        }

        private void DataGridViewProjects_UserAddedRow(object? sender, DataGridViewRowEventArgs e)
        {
            var item = vm.Projects[vm.Projects.Count - 1];
            vm.Add(item);
            //dataGridViewProjects.Refresh();
            //var p = vm.Projects.DataSource.AddNew();
            //vm.Add(new ProjectVM());
        }

        private void DataGridViewProjects_UserDeletingRow(object? sender, DataGridViewRowCancelEventArgs e)
        {
            var item = e.Row?.DataBoundItem as ProjectVM;
            if (item != null)
            {
                vm.Remove(item);
            }
            e.Cancel = true;
        }

        
        

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            //base.OnClosing(e);
            //this.clientBindingSource.DataSource = null;
            //this.dbContext?.Dispose();
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






        /*
		private void dataGridViewProjects_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			if (dataGridViewProjects.Columns[dataGridViewProjects.CurrentCell.ColumnIndex].HeaderText == "Client")
			{
				/*
                dataGridViewProjects.CurrentCell = new DataGridViewComboBoxCell();
                var t = (DataGridViewComboBoxCell)dataGridViewProjects.CurrentCell; ;
                t.Items.Add("test");
                t.Items.Add("testasdf");
                
                curCombo = e.Control as ComboBox;
                if (curCombo != null)
                {
                    curCombo.SelectedIndexChanged -= new EventHandler(curCombo_SelectedIndexChanged);
                    curCombo.SelectedIndexChanged += new EventHandler(curCombo_SelectedIndexChanged);
                }
                
			}
		}
		*/


        /*
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
		*/

        private void dataGridViewProjects_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (e.RowIndex == 0)
                return;

            /*
            var dgv = (DataGridView)sender;
            var item = dgv.Rows[e.RowIndex].DataBoundItem as ProjectVM;
            if (item != null)
                vm.Remove(item);
            */
            //vm.SaveCommand.NotifyCanExecuteChanged();
        }

        private void dataGridViewProjects_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /*
			var dgv = sender as DataGridView;
			var col = dgv.Columns[e.ColumnIndex];
			dgv.Sort(col, ListSortDirection.Ascending);
			*/
        }

        private async void ProjectsForm_Load(object sender, EventArgs e)
        {
            await vm.Load();
            dgvcClient.Items.AddRange(vm.Clients.ToArray());
            dataGridViewProjects.DataSource = vm.Projects;
            vm.Projects.Refresh();
        }

        
        private void dataGridViewProjects_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            vm.SaveCommand.NotifyCanExecuteChanged();
        }
    }


}
