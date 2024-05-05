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
            dgvcClient = new DataGridViewTextBoxColumn();
            dgvcProject = new DataGridViewTextBoxColumn();
            buttonSave = new Button();
            projectsViewModelBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridViewProjects).BeginInit();
            ((System.ComponentModel.ISupportInitialize)projectsViewModelBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewProjects
            // 
            dataGridViewProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProjects.Columns.AddRange(new DataGridViewColumn[] { dgvcClient, dgvcProject });
            dataGridViewProjects.Location = new Point(12, 21);
            dataGridViewProjects.Name = "dataGridViewProjects";
            dataGridViewProjects.RowHeadersWidth = 51;
            dataGridViewProjects.Size = new Size(736, 188);
            dataGridViewProjects.TabIndex = 0;
            // 
            // dgvcClient
            // 
            dgvcClient.DataPropertyName = "Client";
            dgvcClient.HeaderText = "Client";
            dgvcClient.MinimumWidth = 6;
            dgvcClient.Name = "dgvcClient";
            dgvcClient.Width = 125;
            // 
            // dgvcProject
            // 
            dgvcProject.DataPropertyName = "Project";
            dgvcProject.HeaderText = "Project";
            dgvcProject.MinimumWidth = 6;
            dgvcProject.Name = "dgvcProject";
            dgvcProject.Width = 125;
            // 
            // buttonSave
            // 
            buttonSave.DataBindings.Add(new Binding("Command", projectsViewModelBindingSource, "SaveIt", true));
            buttonSave.Location = new Point(577, 237);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // projectsViewModelBindingSource
            // 
            projectsViewModelBindingSource.DataSource = typeof(TimeTracker.ViewModel.ProjectsViewModel);
            // 
            // ProjectsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonSave);
            Controls.Add(dataGridViewProjects);
            Name = "ProjectsForm";
            Text = "ProjectsForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewProjects).EndInit();
            ((System.ComponentModel.ISupportInitialize)projectsViewModelBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewProjects;
        private Button buttonSave;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn projectDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dgvcClient;
        private DataGridViewTextBoxColumn dgvcProject;
        private BindingSource projectsViewModelBindingSource;
    }
}