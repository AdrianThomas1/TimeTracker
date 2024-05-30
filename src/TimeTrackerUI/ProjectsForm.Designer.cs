namespace TimeTrackerUI
{
    partial class ProjectsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridViewProjects = new DataGridView();
            dgvcClient = new DataGridViewComboBoxColumn();
            dgvcProject = new DataGridViewTextBoxColumn();
            dgvcHours = new DataGridViewTextBoxColumn();
            dgvcBillable = new DataGridViewCheckBoxColumn();
            dgvcProductive = new DataGridViewCheckBoxColumn();
            dgvcEnabled = new DataGridViewCheckBoxColumn();
            dgvcIsDeleted = new DataGridViewCheckBoxColumn();
            dgrcDescription = new DataGridViewTextBoxColumn();
            projectsViewModelBindingSource = new BindingSource(components);
            buttonSave = new Button();
            textBox1 = new TextBox();
            button1 = new Button();
            menuStrip1 = new MenuStrip();
            menu = new ToolStripMenuItem();
            showHideDeletedMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProjects).BeginInit();
            ((System.ComponentModel.ISupportInitialize)projectsViewModelBindingSource).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewProjects
            // 
            dataGridViewProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProjects.Columns.AddRange(new DataGridViewColumn[] { dgvcClient, dgvcProject, dgvcHours, dgvcBillable, dgvcProductive, dgvcEnabled, dgvcIsDeleted, dgrcDescription });
            dataGridViewProjects.Location = new Point(11, 59);
            dataGridViewProjects.Name = "dataGridViewProjects";
            dataGridViewProjects.RowHeadersWidth = 51;
            dataGridViewProjects.Size = new Size(1170, 316);
            dataGridViewProjects.TabIndex = 0;
            dataGridViewProjects.ColumnHeaderMouseClick += dataGridViewProjects_ColumnHeaderMouseClick;
            dataGridViewProjects.RowEnter += dataGridViewProjects_RowEnter;
            dataGridViewProjects.RowsRemoved += dataGridViewProjects_RowsRemoved;
            // 
            // dgvcClient
            // 
            dgvcClient.HeaderText = "Client";
            dgvcClient.MinimumWidth = 6;
            dgvcClient.Name = "dgvcClient";
            dgvcClient.Resizable = DataGridViewTriState.True;
            dgvcClient.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvcClient.Width = 125;
            // 
            // dgvcProject
            // 
            dgvcProject.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvcProject.DataPropertyName = "Project";
            dgvcProject.HeaderText = "Project";
            dgvcProject.MinimumWidth = 6;
            dgvcProject.Name = "dgvcProject";
            dgvcProject.Width = 84;
            // 
            // dgvcHours
            // 
            dgvcHours.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvcHours.DataPropertyName = "Hours";
            dgvcHours.HeaderText = "Hours";
            dgvcHours.MinimumWidth = 6;
            dgvcHours.Name = "dgvcHours";
            dgvcHours.Width = 77;
            // 
            // dgvcBillable
            // 
            dgvcBillable.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvcBillable.DataPropertyName = "IsBillable";
            dgvcBillable.HeaderText = "Billable";
            dgvcBillable.MinimumWidth = 6;
            dgvcBillable.Name = "dgvcBillable";
            dgvcBillable.Width = 65;
            // 
            // dgvcProductive
            // 
            dgvcProductive.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvcProductive.DataPropertyName = "IsProductive";
            dgvcProductive.HeaderText = "Productive";
            dgvcProductive.MinimumWidth = 6;
            dgvcProductive.Name = "dgvcProductive";
            dgvcProductive.Width = 85;
            // 
            // dgvcEnabled
            // 
            dgvcEnabled.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvcEnabled.DataPropertyName = "IsEnabled";
            dgvcEnabled.HeaderText = "Enabled";
            dgvcEnabled.MinimumWidth = 6;
            dgvcEnabled.Name = "dgvcEnabled";
            dgvcEnabled.Width = 69;
            // 
            // dgvcIsDeleted
            // 
            dgvcIsDeleted.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvcIsDeleted.DataPropertyName = "IsDeleted";
            dgvcIsDeleted.HeaderText = "IsDeleted";
            dgvcIsDeleted.MinimumWidth = 6;
            dgvcIsDeleted.Name = "dgvcIsDeleted";
            dgvcIsDeleted.Width = 78;
            // 
            // dgrcDescription
            // 
            dgrcDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrcDescription.DataPropertyName = "Description";
            dgrcDescription.HeaderText = "Description";
            dgrcDescription.MinimumWidth = 6;
            dgrcDescription.Name = "dgrcDescription";
            // 
            // projectsViewModelBindingSource
            // 
            projectsViewModelBindingSource.DataSource = typeof(TimeTracker.ViewModel.ProjectsViewModel);
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(635, 399);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.DataBindings.Add(new Binding("DataContext", projectsViewModelBindingSource, "MyTextBox", true));
            textBox1.Location = new Point(247, 396);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(808, 408);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menu });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1194, 28);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // menu
            // 
            menu.DropDownItems.AddRange(new ToolStripItem[] { showHideDeletedMenuItem });
            menu.Name = "menu";
            menu.Size = new Size(55, 24);
            menu.Text = "&View";
            // 
            // showHideDeletedMenuItem
            // 
            showHideDeletedMenuItem.Name = "showHideDeletedMenuItem";
            showHideDeletedMenuItem.Size = new Size(223, 26);
            showHideDeletedMenuItem.Text = "Show/Hide &Deleted";
            // 
            // ProjectsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1194, 473);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(buttonSave);
            Controls.Add(dataGridViewProjects);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ProjectsForm";
            Text = "Projects";
            Load += ProjectsForm_Load;
            Resize += ProjectsForm_Resize;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProjects).EndInit();
            ((System.ComponentModel.ISupportInitialize)projectsViewModelBindingSource).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewProjects;
        private Button buttonSave;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn projectDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private BindingSource projectsViewModelBindingSource;
        private TextBox textBox1;
		private Button button1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menu;
        private ToolStripMenuItem showHideDeletedMenuItem;
        private DataGridViewComboBoxColumn dgvcClient;
        private DataGridViewTextBoxColumn dgvcProject;
        private DataGridViewTextBoxColumn dgvcHours;
        private DataGridViewCheckBoxColumn dgvcBillable;
        private DataGridViewCheckBoxColumn dgvcProductive;
        private DataGridViewCheckBoxColumn dgvcEnabled;
        private DataGridViewCheckBoxColumn dgvcIsDeleted;
        private DataGridViewTextBoxColumn dgrcDescription;
    }
}