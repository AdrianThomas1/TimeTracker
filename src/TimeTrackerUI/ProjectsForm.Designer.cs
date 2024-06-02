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
            dgvcSource = new DataGridViewComboBoxColumn();
            dgvcProject = new DataGridViewTextBoxColumn();
            dgvcHours = new DataGridViewTextBoxColumn();
            dgvcBillable = new DataGridViewCheckBoxColumn();
            dgvcProductive = new DataGridViewCheckBoxColumn();
            dgvcEnabled = new DataGridViewCheckBoxColumn();
            dgvcIsDeleted = new DataGridViewCheckBoxColumn();
            dgrcDescription = new DataGridViewTextBoxColumn();
            projectsViewModelBindingSource = new BindingSource(components);
            buttonSave = new Button();
            menuStrip1 = new MenuStrip();
            menu = new ToolStripMenuItem();
            showHideDeletedMenuItem = new ToolStripMenuItem();
            textBoxFilter = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProjects).BeginInit();
            ((System.ComponentModel.ISupportInitialize)projectsViewModelBindingSource).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewProjects
            // 
            dataGridViewProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProjects.Columns.AddRange(new DataGridViewColumn[] { dgvcClient, dgvcSource, dgvcProject, dgvcHours, dgvcBillable, dgvcProductive, dgvcEnabled, dgvcIsDeleted, dgrcDescription });
            dataGridViewProjects.Location = new Point(11, 59);
            dataGridViewProjects.Name = "dataGridViewProjects";
            dataGridViewProjects.RowHeadersWidth = 51;
            dataGridViewProjects.Size = new Size(1170, 316);
            dataGridViewProjects.TabIndex = 0;
            dataGridViewProjects.CellEndEdit += dataGridViewProjects_CellEndEdit;
            dataGridViewProjects.ColumnHeaderMouseClick += dataGridViewProjects_ColumnHeaderMouseClick;
            dataGridViewProjects.RowsRemoved += dataGridViewProjects_RowsRemoved;
            // 
            // dgvcClient
            // 
            dgvcClient.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvcClient.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dgvcClient.FlatStyle = FlatStyle.Flat;
            dgvcClient.HeaderText = "Client";
            dgvcClient.MinimumWidth = 6;
            dgvcClient.Name = "dgvcClient";
            dgvcClient.Resizable = DataGridViewTriState.True;
            dgvcClient.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvcClient.Width = 76;
            // 
            // dgvcSource
            // 
            dgvcSource.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvcSource.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dgvcSource.FlatStyle = FlatStyle.Flat;
            dgvcSource.HeaderText = "Source";
            dgvcSource.MinimumWidth = 6;
            dgvcSource.Name = "dgvcSource";
            dgvcSource.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvcSource.Width = 83;
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
            // textBoxFilter
            // 
            textBoxFilter.Location = new Point(12, 26);
            textBoxFilter.Name = "textBoxFilter";
            textBoxFilter.Size = new Size(1169, 27);
            textBoxFilter.TabIndex = 5;
            // 
            // ProjectsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1194, 473);
            Controls.Add(textBoxFilter);
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
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menu;
        private ToolStripMenuItem showHideDeletedMenuItem;
        private DataGridViewComboBoxColumn dgvcClient;
        private DataGridViewComboBoxColumn dgvcSource;
        private DataGridViewTextBoxColumn dgvcProject;
        private DataGridViewTextBoxColumn dgvcHours;
        private DataGridViewCheckBoxColumn dgvcBillable;
        private DataGridViewCheckBoxColumn dgvcProductive;
        private DataGridViewCheckBoxColumn dgvcEnabled;
        private DataGridViewCheckBoxColumn dgvcIsDeleted;
        private DataGridViewTextBoxColumn dgrcDescription;
        private TextBox textBoxFilter;
    }
}