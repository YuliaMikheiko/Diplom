
namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.InformationDGV = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleRowDataGridRowItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NtColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.teachersDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.subgroupsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.audsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.disciplineDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isonlineDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.InformationDGV)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleRowDataGridRowItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // InformationDGV
            // 
            this.InformationDGV.AllowUserToAddRows = false;
            this.InformationDGV.AllowUserToDeleteRows = false;
            this.InformationDGV.AutoGenerateColumns = false;
            this.InformationDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InformationDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hDataGridViewTextBoxColumn,
            this.NtColumn,
            this.teachersDataGridViewTextBoxColumn,
            this.TColumn,
            this.subgroupsDataGridViewTextBoxColumn,
            this.GColumn,
            this.audsDataGridViewTextBoxColumn,
            this.AColumn,
            this.disciplineDataGridViewTextBoxColumn,
            this.isonlineDataGridViewCheckBoxColumn});
            this.InformationDGV.Cursor = System.Windows.Forms.Cursors.Default;
            this.InformationDGV.DataSource = this.scheduleRowDataGridRowItemBindingSource;
            this.InformationDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InformationDGV.Location = new System.Drawing.Point(0, 24);
            this.InformationDGV.Name = "InformationDGV";
            this.InformationDGV.Size = new System.Drawing.Size(1129, 394);
            this.InformationDGV.TabIndex = 0;
            this.InformationDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenMenuItem,
            this.SaveMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1129, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // OpenMenuItem
            // 
            this.OpenMenuItem.Name = "OpenMenuItem";
            this.OpenMenuItem.Size = new System.Drawing.Size(66, 20);
            this.OpenMenuItem.Text = "Открыть";
            this.OpenMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.Name = "SaveMenuItem";
            this.SaveMenuItem.Size = new System.Drawing.Size(78, 20);
            this.SaveMenuItem.Text = "Сохранить";
            this.SaveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // scheduleRowDataGridRowItemBindingSource
            // 
            this.scheduleRowDataGridRowItemBindingSource.DataSource = typeof(WindowsFormsApp2.ScheduleRowDataGridRowItem);
            // 
            // hDataGridViewTextBoxColumn
            // 
            this.hDataGridViewTextBoxColumn.DataPropertyName = "H";
            this.hDataGridViewTextBoxColumn.HeaderText = "H";
            this.hDataGridViewTextBoxColumn.Name = "hDataGridViewTextBoxColumn";
            // 
            // NtColumn
            // 
            this.NtColumn.DataPropertyName = "NT";
            this.NtColumn.HeaderText = "NT";
            this.NtColumn.Items.AddRange(new object[] {
            "Лекционное занятие",
            "Практическое занятие",
            "Лабораторное занятие"});
            this.NtColumn.Name = "NtColumn";
            this.NtColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NtColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // teachersDataGridViewTextBoxColumn
            // 
            this.teachersDataGridViewTextBoxColumn.DataPropertyName = "Teachers";
            this.teachersDataGridViewTextBoxColumn.HeaderText = "Teachers";
            this.teachersDataGridViewTextBoxColumn.Name = "teachersDataGridViewTextBoxColumn";
            // 
            // TColumn
            // 
            this.TColumn.HeaderText = "";
            this.TColumn.MinimumWidth = 25;
            this.TColumn.Name = "TColumn";
            this.TColumn.ReadOnly = true;
            this.TColumn.Width = 25;
            // 
            // subgroupsDataGridViewTextBoxColumn
            // 
            this.subgroupsDataGridViewTextBoxColumn.DataPropertyName = "Sub_groups";
            this.subgroupsDataGridViewTextBoxColumn.HeaderText = "Sub_groups";
            this.subgroupsDataGridViewTextBoxColumn.Name = "subgroupsDataGridViewTextBoxColumn";
            // 
            // GColumn
            // 
            this.GColumn.HeaderText = " ";
            this.GColumn.MinimumWidth = 25;
            this.GColumn.Name = "GColumn";
            this.GColumn.ReadOnly = true;
            this.GColumn.Width = 25;
            // 
            // audsDataGridViewTextBoxColumn
            // 
            this.audsDataGridViewTextBoxColumn.DataPropertyName = "Auds";
            this.audsDataGridViewTextBoxColumn.HeaderText = "Auds";
            this.audsDataGridViewTextBoxColumn.Name = "audsDataGridViewTextBoxColumn";
            // 
            // AColumn
            // 
            this.AColumn.HeaderText = " ";
            this.AColumn.MinimumWidth = 25;
            this.AColumn.Name = "AColumn";
            this.AColumn.ReadOnly = true;
            this.AColumn.Width = 25;
            // 
            // disciplineDataGridViewTextBoxColumn
            // 
            this.disciplineDataGridViewTextBoxColumn.DataPropertyName = "Discipline";
            this.disciplineDataGridViewTextBoxColumn.HeaderText = "Discipline";
            this.disciplineDataGridViewTextBoxColumn.Name = "disciplineDataGridViewTextBoxColumn";
            // 
            // isonlineDataGridViewCheckBoxColumn
            // 
            this.isonlineDataGridViewCheckBoxColumn.DataPropertyName = "Is_online";
            this.isonlineDataGridViewCheckBoxColumn.HeaderText = "Is_online";
            this.isonlineDataGridViewCheckBoxColumn.Name = "isonlineDataGridViewCheckBoxColumn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 418);
            this.Controls.Add(this.InformationDGV);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.InformationDGV)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleRowDataGridRowItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataGridView InformationDGV;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveMenuItem;
        private System.Windows.Forms.BindingSource scheduleRowDataGridRowItemBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn hDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn NtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn teachersDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn TColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subgroupsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn GColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn audsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn AColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn disciplineDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isonlineDataGridViewCheckBoxColumn;
    }
}

