
namespace test_DataBase
{
    partial class Admin
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.testDataSet = new test_DataBase.testDataSet();
            this.registerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.registerTableAdapter = new test_DataBase.testDataSetTableAdapters.registerTableAdapter();
            this.iduserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginuserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passworduserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roleuserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iduserDataGridViewTextBoxColumn,
            this.loginuserDataGridViewTextBoxColumn,
            this.passworduserDataGridViewTextBoxColumn,
            this.roleuserDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.registerBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(28, 33);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(548, 241);
            this.dataGridView2.TabIndex = 1;
            // 
            // testDataSet
            // 
            this.testDataSet.DataSetName = "testDataSet";
            this.testDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // registerBindingSource
            // 
            this.registerBindingSource.DataMember = "register";
            this.registerBindingSource.DataSource = this.testDataSet;
            // 
            // registerTableAdapter
            // 
            this.registerTableAdapter.ClearBeforeFill = true;
            // 
            // iduserDataGridViewTextBoxColumn
            // 
            this.iduserDataGridViewTextBoxColumn.DataPropertyName = "id_user";
            this.iduserDataGridViewTextBoxColumn.HeaderText = "id_user";
            this.iduserDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iduserDataGridViewTextBoxColumn.Name = "iduserDataGridViewTextBoxColumn";
            this.iduserDataGridViewTextBoxColumn.ReadOnly = true;
            this.iduserDataGridViewTextBoxColumn.Width = 125;
            // 
            // loginuserDataGridViewTextBoxColumn
            // 
            this.loginuserDataGridViewTextBoxColumn.DataPropertyName = "login_user";
            this.loginuserDataGridViewTextBoxColumn.HeaderText = "login_user";
            this.loginuserDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.loginuserDataGridViewTextBoxColumn.Name = "loginuserDataGridViewTextBoxColumn";
            this.loginuserDataGridViewTextBoxColumn.Width = 125;
            // 
            // passworduserDataGridViewTextBoxColumn
            // 
            this.passworduserDataGridViewTextBoxColumn.DataPropertyName = "password_user";
            this.passworduserDataGridViewTextBoxColumn.HeaderText = "password_user";
            this.passworduserDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.passworduserDataGridViewTextBoxColumn.Name = "passworduserDataGridViewTextBoxColumn";
            this.passworduserDataGridViewTextBoxColumn.Width = 125;
            // 
            // roleuserDataGridViewTextBoxColumn
            // 
            this.roleuserDataGridViewTextBoxColumn.DataPropertyName = "role_user";
            this.roleuserDataGridViewTextBoxColumn.HeaderText = "role_user";
            this.roleuserDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.roleuserDataGridViewTextBoxColumn.Name = "roleuserDataGridViewTextBoxColumn";
            this.roleuserDataGridViewTextBoxColumn.Width = 125;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(501, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(420, 280);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 333);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView2);
            this.Name = "Admin";
            this.Text = "admin";
            this.Load += new System.EventHandler(this.admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView2;
        private testDataSet testDataSet;
        private System.Windows.Forms.BindingSource registerBindingSource;
        private testDataSetTableAdapters.registerTableAdapter registerTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iduserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginuserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passworduserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleuserDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}