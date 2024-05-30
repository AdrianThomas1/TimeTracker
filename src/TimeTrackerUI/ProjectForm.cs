using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTracker.Model;
using TimeTracker.ViewModel;

namespace TimeTrackerUI
{
    public partial class ProjectForm : Form
    {
        private readonly ProjectsViewModel vm;

        public ProjectForm(ProjectsViewModel view)
        {
            InitializeComponent();
            vm = view ?? throw new ArgumentNullException(nameof(view));

            //textBox1.DataBindings.Add(new Binding("Text", vm.CurrentItem, "Client"));
            //textBox2.DataBindings.Add(new Binding("Text", vm.CurrentItem, "Project"));

            cmbClient.Sorted = true;
            cmbClient.DataSource = vm.Clients;
            cmbClient.DisplayMember = "Name";
            //cmbClient.ValueMember = "Id";
            //cmbClient.SelectedItem = vm.CurrentItem;
            //cmbClient.SelectedItem = vm.Clients.Where(c => c.Name == vm.CurrentItem.Client).First();

        }

        private void cmbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            //vm.CurrentItem.Client = ((Client)cmbClient.SelectedItem);
        }
    }
}
