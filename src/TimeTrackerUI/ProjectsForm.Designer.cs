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
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Client = new DataGridViewComboBoxColumn();
            clientBindingSource = new BindingSource(components);
            sourceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isProductiveDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            isBillableDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            isEnabledDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            isDeletedDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            hoursDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            projectBindingSource = new BindingSource(components);
            buttonSave = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProjects).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clientBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)projectBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewProjects
            // 
            dataGridViewProjects.AutoGenerateColumns = false;
            dataGridViewProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProjects.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, Client, sourceDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, isProductiveDataGridViewCheckBoxColumn, isBillableDataGridViewCheckBoxColumn, isEnabledDataGridViewCheckBoxColumn, isDeletedDataGridViewCheckBoxColumn, hoursDataGridViewTextBoxColumn });
            dataGridViewProjects.DataSource = projectBindingSource;
            dataGridViewProjects.Location = new Point(12, 21);
            dataGridViewProjects.Name = "dataGridViewProjects";
            dataGridViewProjects.RowHeadersWidth = 51;
            dataGridViewProjects.Size = new Size(736, 188);
            dataGridViewProjects.TabIndex = 0;
            dataGridViewProjects.DataError += dataGridViewProjects_DataError;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Width = 125;
            // 
            // Client
            // 
            Client.DataPropertyName = "Client";
            Client.DataSource = clientBindingSource;
            Client.DisplayMember = "Name";
            Client.HeaderText = "Client";
            Client.MinimumWidth = 6;
            Client.Name = "Client";
            Client.Width = 125;
            // 
            // clientBindingSource
            // 
            clientBindingSource.DataSource = typeof(TimeTracker.Model.Client);
            // 
            // sourceDataGridViewTextBoxColumn
            // 
            sourceDataGridViewTextBoxColumn.DataPropertyName = "Source";
            sourceDataGridViewTextBoxColumn.HeaderText = "Source";
            sourceDataGridViewTextBoxColumn.MinimumWidth = 6;
            sourceDataGridViewTextBoxColumn.Name = "sourceDataGridViewTextBoxColumn";
            sourceDataGridViewTextBoxColumn.Width = 125;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            descriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            descriptionDataGridViewTextBoxColumn.Width = 125;
            // 
            // isProductiveDataGridViewCheckBoxColumn
            // 
            isProductiveDataGridViewCheckBoxColumn.DataPropertyName = "IsProductive";
            isProductiveDataGridViewCheckBoxColumn.HeaderText = "IsProductive";
            isProductiveDataGridViewCheckBoxColumn.MinimumWidth = 6;
            isProductiveDataGridViewCheckBoxColumn.Name = "isProductiveDataGridViewCheckBoxColumn";
            isProductiveDataGridViewCheckBoxColumn.Width = 125;
            // 
            // isBillableDataGridViewCheckBoxColumn
            // 
            isBillableDataGridViewCheckBoxColumn.DataPropertyName = "IsBillable";
            isBillableDataGridViewCheckBoxColumn.HeaderText = "IsBillable";
            isBillableDataGridViewCheckBoxColumn.MinimumWidth = 6;
            isBillableDataGridViewCheckBoxColumn.Name = "isBillableDataGridViewCheckBoxColumn";
            isBillableDataGridViewCheckBoxColumn.Width = 125;
            // 
            // isEnabledDataGridViewCheckBoxColumn
            // 
            isEnabledDataGridViewCheckBoxColumn.DataPropertyName = "IsEnabled";
            isEnabledDataGridViewCheckBoxColumn.HeaderText = "IsEnabled";
            isEnabledDataGridViewCheckBoxColumn.MinimumWidth = 6;
            isEnabledDataGridViewCheckBoxColumn.Name = "isEnabledDataGridViewCheckBoxColumn";
            isEnabledDataGridViewCheckBoxColumn.Width = 125;
            // 
            // isDeletedDataGridViewCheckBoxColumn
            // 
            isDeletedDataGridViewCheckBoxColumn.DataPropertyName = "IsDeleted";
            isDeletedDataGridViewCheckBoxColumn.HeaderText = "IsDeleted";
            isDeletedDataGridViewCheckBoxColumn.MinimumWidth = 6;
            isDeletedDataGridViewCheckBoxColumn.Name = "isDeletedDataGridViewCheckBoxColumn";
            isDeletedDataGridViewCheckBoxColumn.Width = 125;
            // 
            // hoursDataGridViewTextBoxColumn
            // 
            hoursDataGridViewTextBoxColumn.DataPropertyName = "Hours";
            hoursDataGridViewTextBoxColumn.HeaderText = "Hours";
            hoursDataGridViewTextBoxColumn.MinimumWidth = 6;
            hoursDataGridViewTextBoxColumn.Name = "hoursDataGridViewTextBoxColumn";
            hoursDataGridViewTextBoxColumn.Width = 125;
            // 
            // projectBindingSource
            // 
            projectBindingSource.DataSource = typeof(TimeTracker.Model.Project);
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(566, 215);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
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
            ((System.ComponentModel.ISupportInitialize)clientBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)projectBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewProjects;
        private Button buttonSave;
        private BindingSource projectBindingSource;
        private DataGridViewTextBoxColumn clientDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn Client;
        private BindingSource clientBindingSource;
        private DataGridViewTextBoxColumn sourceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isProductiveDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn isBillableDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn isEnabledDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn isDeletedDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn hoursDataGridViewTextBoxColumn;
    }
}