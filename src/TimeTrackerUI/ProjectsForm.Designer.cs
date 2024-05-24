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
			projectsViewModelBindingSource = new BindingSource(components);
			buttonSave = new Button();
			textBox1 = new TextBox();
			button1 = new Button();
			dgvcClient = new DataGridViewComboBoxColumn();
			dgvcProject = new DataGridViewTextBoxColumn();
			dgvcHours = new DataGridViewTextBoxColumn();
			dgvcBillable = new DataGridViewCheckBoxColumn();
			dgvcProductive = new DataGridViewCheckBoxColumn();
			dgvcEnabled = new DataGridViewCheckBoxColumn();
			dgvcIsDeleted = new DataGridViewCheckBoxColumn();
			dgrcDescription = new DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)dataGridViewProjects).BeginInit();
			((System.ComponentModel.ISupportInitialize)projectsViewModelBindingSource).BeginInit();
			SuspendLayout();
			// 
			// dataGridViewProjects
			// 
			dataGridViewProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewProjects.Columns.AddRange(new DataGridViewColumn[] { dgvcClient, dgvcProject, dgvcHours, dgvcBillable, dgvcProductive, dgvcEnabled, dgvcIsDeleted, dgrcDescription });
			dataGridViewProjects.Location = new Point(10, 44);
			dataGridViewProjects.Margin = new Padding(3, 2, 3, 2);
			dataGridViewProjects.Name = "dataGridViewProjects";
			dataGridViewProjects.RowHeadersWidth = 51;
			dataGridViewProjects.Size = new Size(1024, 237);
			dataGridViewProjects.TabIndex = 0;
			dataGridViewProjects.ColumnHeaderMouseClick += dataGridViewProjects_ColumnHeaderMouseClick;
			dataGridViewProjects.RowEnter += dataGridViewProjects_RowEnter;
			dataGridViewProjects.RowsRemoved += dataGridViewProjects_RowsRemoved;
			// 
			// projectsViewModelBindingSource
			// 
			projectsViewModelBindingSource.DataSource = typeof(TimeTracker.ViewModel.ProjectsViewModel);
			// 
			// buttonSave
			// 
			buttonSave.Location = new Point(556, 299);
			buttonSave.Margin = new Padding(3, 2, 3, 2);
			buttonSave.Name = "buttonSave";
			buttonSave.Size = new Size(82, 22);
			buttonSave.TabIndex = 1;
			buttonSave.Text = "Save";
			buttonSave.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			textBox1.DataBindings.Add(new Binding("DataContext", projectsViewModelBindingSource, "MyTextBox", true));
			textBox1.Location = new Point(216, 297);
			textBox1.Margin = new Padding(3, 2, 3, 2);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(110, 23);
			textBox1.TabIndex = 2;
			// 
			// button1
			// 
			button1.Location = new Point(707, 306);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 3;
			button1.Text = "button1";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// dgvcClient
			// 
			dgvcClient.HeaderText = "Client";
			dgvcClient.Name = "dgvcClient";
			dgvcClient.Resizable = DataGridViewTriState.True;
			dgvcClient.SortMode = DataGridViewColumnSortMode.Automatic;
			// 
			// dgvcProject
			// 
			dgvcProject.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			dgvcProject.DataPropertyName = "Project";
			dgvcProject.HeaderText = "Project";
			dgvcProject.MinimumWidth = 6;
			dgvcProject.Name = "dgvcProject";
			dgvcProject.Width = 69;
			// 
			// dgvcHours
			// 
			dgvcHours.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			dgvcHours.DataPropertyName = "Hours";
			dgvcHours.HeaderText = "Hours";
			dgvcHours.MinimumWidth = 6;
			dgvcHours.Name = "dgvcHours";
			dgvcHours.Width = 64;
			// 
			// dgvcBillable
			// 
			dgvcBillable.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			dgvcBillable.DataPropertyName = "IsBillable";
			dgvcBillable.HeaderText = "Billable";
			dgvcBillable.MinimumWidth = 6;
			dgvcBillable.Name = "dgvcBillable";
			dgvcBillable.Width = 51;
			// 
			// dgvcProductive
			// 
			dgvcProductive.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			dgvcProductive.DataPropertyName = "IsProductive";
			dgvcProductive.HeaderText = "Productive";
			dgvcProductive.MinimumWidth = 6;
			dgvcProductive.Name = "dgvcProductive";
			dgvcProductive.Width = 70;
			// 
			// dgvcEnabled
			// 
			dgvcEnabled.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			dgvcEnabled.DataPropertyName = "IsEnabled";
			dgvcEnabled.HeaderText = "Enabled";
			dgvcEnabled.MinimumWidth = 6;
			dgvcEnabled.Name = "dgvcEnabled";
			dgvcEnabled.Width = 55;
			// 
			// dgvcIsDeleted
			// 
			dgvcIsDeleted.DataPropertyName = "IsDeleted";
			dgvcIsDeleted.HeaderText = "IsDeleted";
			dgvcIsDeleted.Name = "dgvcIsDeleted";
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
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1045, 355);
			Controls.Add(button1);
			Controls.Add(textBox1);
			Controls.Add(buttonSave);
			Controls.Add(dataGridViewProjects);
			Margin = new Padding(3, 2, 3, 2);
			Name = "ProjectsForm";
			Text = "Projects";
			Resize += ProjectsForm_Resize;
			((System.ComponentModel.ISupportInitialize)dataGridViewProjects).EndInit();
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
		private Button button1;
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