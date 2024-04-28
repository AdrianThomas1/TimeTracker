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

namespace TimeTrackerUI
{
    public partial class ClientsForm : Form
    {
        private readonly TimeTrackerDbContext dbContext;
        public ClientsForm(TimeTrackerDbContext context)
        {
            this.dbContext = context ?? throw new ArgumentNullException(nameof(context));
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.dbContext.Clients.Load();
            this.clientBindingSource.DataSource = this.dbContext.Clients.Local.ToBindingList();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this.clientBindingSource.DataSource = null;
            this.dbContext?.Dispose();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.dbContext!.SaveChanges();
            this.dataGridViewClients.Refresh();
        }
    }
}
