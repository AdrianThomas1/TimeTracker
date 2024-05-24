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
            clientsBindingSource = new BindingSource(components);
            projectsViewModelBindingSource = new BindingSource(components);
            buttonSave = new Button();
            textBox1 = new TextBox();
            dgvcClient = new DataGridViewComboBoxColumn();
            dgvcProject = new DataGridViewTextBoxColumn();
            dgvcHours = new DataGridViewTextBoxColumn();
            dgvcBillable = new DataGridViewCheckBoxColumn();
            dgvcProductive = new DataGridViewCheckBoxColumn();
            dgvcEnabled = new DataGridViewCheckBoxColumn();
            dgrcDescription = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProjects).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clientsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)projectsViewModelBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewProjects
            // 
            dataGridViewProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProjects.Columns.AddRange(new DataGridViewColumn[] { dgvcClient, dgvcProject, dgvcHours, dgvcBillable, dgvcProductive, dgvcEnabled, dgrcDescription });
            dataGridViewProjects.Location = new Point(12, 59);
            dataGridViewProjects.Name = "dataGridViewProjects";
            dataGridViewProjects.RowHeadersWidth = 51;
            dataGridViewProjects.Size = new Size(1170, 316);
            dataGridViewProjects.TabIndex = 0;
            dataGridViewProjects.CellMouseDoubleClick += dataGridViewProjects_CellMouseDoubleClick;
            dataGridViewProjects.EditingControlShowing += dataGridViewProjects_EditingControlShowing_1;
            dataGridViewProjects.RowEnter += dataGridViewProjects_RowEnter;
            // 
            // clientsBindingSource
            // 
            clientsBindingSource.DataMember = "Clients";
            clientsBindingSource.DataSource = projectsViewModelBindingSource;
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
            // dgvcClient
            // 
            dgvcClient.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvcClient.DataPropertyName = "Name";
            dgvcClient.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dgvcClient.HeaderText = "Client";
            dgvcClient.MinimumWidth = 6;
            dgvcClient.Name = "dgvcClient";
            dgvcClient.Width = 53;
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
            // dgrcDescription
            // 
            dgrcDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgrcDescription.DataPropertyName = "Description";
            dgrcDescription.HeaderText = "Description";
            dgrcDescription.MinimumWidth = 6;
            dgrcDescription.Name = "dgrcDescription";
            // 
            // ProjectsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1194, 473);
            Controls.Add(textBox1);
            Controls.Add(buttonSave);
            Controls.Add(dataGridViewProjects);
            Name = "ProjectsForm";
            Text = "Projects";
            Resize += ProjectsForm_Resize;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProjects).EndInit();
            ((System.ComponentModel.ISupportInitialize)clientsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)projectsViewModelBindingSource).EndInit();
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
        private BindingSource clientsBindingSource;
        private DataGridViewComboBoxColumn dgvcClient;
        private DataGridViewTextBoxColumn dgvcProject;
        private DataGridViewTextBoxColumn dgvcHours;
        private DataGridViewCheckBoxColumn dgvcBillable;
        private DataGridViewCheckBoxColumn dgvcProductive;
        private DataGridViewCheckBoxColumn dgvcEnabled;
        private DataGridViewTextBoxColumn dgrcDescription;
    }
}