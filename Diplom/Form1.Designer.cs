
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
            this.InformationDGV = new System.Windows.Forms.DataGridView();
            this.Save = new System.Windows.Forms.Button();
            this.Open = new System.Windows.Forms.Button();
            this.HColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NtColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TeachersColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.GroupsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.AuditoriesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DisciplineColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OnlineColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.InformationDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // InformationDGV
            // 
            this.InformationDGV.AllowUserToAddRows = false;
            this.InformationDGV.AllowUserToDeleteRows = false;
            this.InformationDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InformationDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HColumn,
            this.NtColumn,
            this.TeachersColumn,
            this.TColumn,
            this.GroupsColumn,
            this.GColumn,
            this.AuditoriesColumn,
            this.AColumn,
            this.DisciplineColumn,
            this.OnlineColumn});
            this.InformationDGV.Dock = System.Windows.Forms.DockStyle.Left;
            this.InformationDGV.Location = new System.Drawing.Point(0, 0);
            this.InformationDGV.Name = "InformationDGV";
            this.InformationDGV.Size = new System.Drawing.Size(970, 418);
            this.InformationDGV.TabIndex = 0;
            this.InformationDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(998, 383);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(119, 23);
            this.Save.TabIndex = 1;
            this.Save.Text = "Сохранить ";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(998, 344);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(119, 23);
            this.Open.TabIndex = 2;
            this.Open.Text = "Открыть ";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // HColumn
            // 
            this.HColumn.HeaderText = "Количество часов";
            this.HColumn.Name = "HColumn";
            this.HColumn.Width = 120;
            // 
            // NtColumn
            // 
            this.NtColumn.FillWeight = 110F;
            this.NtColumn.HeaderText = "Тип занятия";
            this.NtColumn.Items.AddRange(new object[] {
            "Лекционное занятие",
            "Практическое занятие",
            "Лабораторное занятие"});
            this.NtColumn.Name = "NtColumn";
            this.NtColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NtColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.NtColumn.Width = 120;
            // 
            // TeachersColumn
            // 
            this.TeachersColumn.FillWeight = 110F;
            this.TeachersColumn.HeaderText = "Преподаватель";
            this.TeachersColumn.Name = "TeachersColumn";
            this.TeachersColumn.Width = 120;
            // 
            // TColumn
            // 
            this.TColumn.HeaderText = "";
            this.TColumn.MinimumWidth = 25;
            this.TColumn.Name = "TColumn";
            this.TColumn.Width = 25;
            // 
            // GroupsColumn
            // 
            this.GroupsColumn.FillWeight = 110F;
            this.GroupsColumn.HeaderText = "Список групп";
            this.GroupsColumn.Name = "GroupsColumn";
            this.GroupsColumn.Width = 120;
            // 
            // GColumn
            // 
            this.GColumn.HeaderText = " ";
            this.GColumn.MinimumWidth = 25;
            this.GColumn.Name = "GColumn";
            this.GColumn.Width = 25;
            // 
            // AuditoriesColumn
            // 
            this.AuditoriesColumn.FillWeight = 110F;
            this.AuditoriesColumn.HeaderText = "Список аудиторий";
            this.AuditoriesColumn.Name = "AuditoriesColumn";
            this.AuditoriesColumn.Width = 120;
            // 
            // AColumn
            // 
            this.AColumn.HeaderText = " ";
            this.AColumn.MinimumWidth = 25;
            this.AColumn.Name = "AColumn";
            this.AColumn.Width = 25;
            // 
            // DisciplineColumn
            // 
            this.DisciplineColumn.FillWeight = 110F;
            this.DisciplineColumn.HeaderText = "Название дисциплин";
            this.DisciplineColumn.Name = "DisciplineColumn";
            this.DisciplineColumn.Width = 120;
            // 
            // OnlineColumn
            // 
            this.OnlineColumn.FillWeight = 110F;
            this.OnlineColumn.HeaderText = "Занатие онлайн";
            this.OnlineColumn.Name = "OnlineColumn";
            this.OnlineColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OnlineColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.OnlineColumn.Width = 120;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 418);
            this.Controls.Add(this.Open);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.InformationDGV);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.InformationDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Open;
        public System.Windows.Forms.DataGridView InformationDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn HColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn NtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeachersColumn;
        private System.Windows.Forms.DataGridViewButtonColumn TColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupsColumn;
        private System.Windows.Forms.DataGridViewButtonColumn GColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditoriesColumn;
        private System.Windows.Forms.DataGridViewButtonColumn AColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisciplineColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn OnlineColumn;
    }
}

