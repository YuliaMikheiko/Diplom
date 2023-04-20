namespace Diplom
{
    partial class MainWindows
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
            this.scheduleRowDataGridRowItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пожеланияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TeacherWishMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupWishMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AudsWishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Reset = new System.Windows.Forms.Button();
            this.Distribute = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NtColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TeachersColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.GroupsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.KafColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditoriesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DisciplineColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OnlineColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OwnersColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zanlist = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.InformationDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleRowDataGridRowItemBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // InformationDGV
            // 
            this.InformationDGV.AllowUserToAddRows = false;
            this.InformationDGV.AllowUserToDeleteRows = false;
            this.InformationDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InformationDGV.AutoGenerateColumns = false;
            this.InformationDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InformationDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.HColumn,
            this.NtColumn,
            this.TeachersColumn,
            this.TColumn,
            this.GroupsColumn,
            this.GColumn,
            this.KafColumn,
            this.AuditoriesColumn,
            this.AColumn,
            this.DisciplineColumn,
            this.OnlineColumn,
            this.OwnersColumn,
            this.zanlist,
            this.Column1});
            this.InformationDGV.Cursor = System.Windows.Forms.Cursors.Default;
            this.InformationDGV.DataSource = this.scheduleRowDataGridRowItemBindingSource;
            this.InformationDGV.Location = new System.Drawing.Point(0, 47);
            this.InformationDGV.Name = "InformationDGV";
            this.InformationDGV.Size = new System.Drawing.Size(1302, 367);
            this.InformationDGV.TabIndex = 4;
            this.InformationDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InformationDGV_CellContentClick);
            this.InformationDGV.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.InformationDGV_CellMouseClick);
            this.InformationDGV.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.InformationDGV_ColumnHeaderMouseClick);
            // 
            // scheduleRowDataGridRowItemBindingSource
            // 
            this.scheduleRowDataGridRowItemBindingSource.DataSource = typeof(Diplom.ScheduleRowDataGridRowItem);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenMenuItem,
            this.SaveMenuItem,
            this.FilterMenuItem,
            this.пожеланияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1302, 24);
            this.menuStrip1.TabIndex = 5;
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
            // FilterMenuItem
            // 
            this.FilterMenuItem.Name = "FilterMenuItem";
            this.FilterMenuItem.Size = new System.Drawing.Size(60, 20);
            this.FilterMenuItem.Text = "Фильтр";
            this.FilterMenuItem.Click += new System.EventHandler(this.FilterMenuItem_Click);
            // 
            // пожеланияToolStripMenuItem
            // 
            this.пожеланияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TeacherWishMenuItem,
            this.GroupWishMenuItem,
            this.AudsWishToolStripMenuItem});
            this.пожеланияToolStripMenuItem.Name = "пожеланияToolStripMenuItem";
            this.пожеланияToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.пожеланияToolStripMenuItem.Text = "Пожелания";
            // 
            // TeacherWishMenuItem
            // 
            this.TeacherWishMenuItem.Name = "TeacherWishMenuItem";
            this.TeacherWishMenuItem.Size = new System.Drawing.Size(159, 22);
            this.TeacherWishMenuItem.Text = "Преподаватели";
            this.TeacherWishMenuItem.Click += new System.EventHandler(this.TeacherWishMenuItem_Click);
            // 
            // GroupWishMenuItem
            // 
            this.GroupWishMenuItem.Name = "GroupWishMenuItem";
            this.GroupWishMenuItem.Size = new System.Drawing.Size(159, 22);
            this.GroupWishMenuItem.Text = "Группы";
            this.GroupWishMenuItem.Click += new System.EventHandler(this.GroupWishMenuItem_Click);
            // 
            // AudsWishToolStripMenuItem
            // 
            this.AudsWishToolStripMenuItem.Name = "AudsWishToolStripMenuItem";
            this.AudsWishToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.AudsWishToolStripMenuItem.Text = "Аудиториии";
            this.AudsWishToolStripMenuItem.Click += new System.EventHandler(this.AudsWishToolStripMenuItem_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(0, 22);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(103, 23);
            this.Reset.TabIndex = 6;
            this.Reset.Text = "Сброс фильтров";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            this.Reset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Reset_KeyDown);
            // 
            // Distribute
            // 
            this.Distribute.Location = new System.Drawing.Point(109, 22);
            this.Distribute.Name = "Distribute";
            this.Distribute.Size = new System.Drawing.Size(193, 23);
            this.Distribute.TabIndex = 7;
            this.Distribute.Text = "Распространить редактирование";
            this.Distribute.UseVisualStyleBackColor = true;
            this.Distribute.Click += new System.EventHandler(this.Distribute_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(81, 26);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem2.Text = "1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(308, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Объединитьв лист";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // IdColumn
            // 
            this.IdColumn.DataPropertyName = "Id";
            this.IdColumn.HeaderText = "Id";
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.Visible = false;
            // 
            // HColumn
            // 
            this.HColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HColumn.DataPropertyName = "H";
            this.HColumn.HeaderText = "Количество часов";
            this.HColumn.Name = "HColumn";
            // 
            // NtColumn
            // 
            this.NtColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NtColumn.DataPropertyName = "NT";
            this.NtColumn.HeaderText = "Тип занятия";
            this.NtColumn.Name = "NtColumn";
            this.NtColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TeachersColumn
            // 
            this.TeachersColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TeachersColumn.DataPropertyName = "Teachers";
            this.TeachersColumn.HeaderText = "Преподаватель";
            this.TeachersColumn.Name = "TeachersColumn";
            this.TeachersColumn.ReadOnly = true;
            // 
            // TColumn
            // 
            this.TColumn.HeaderText = "";
            this.TColumn.MinimumWidth = 25;
            this.TColumn.Name = "TColumn";
            this.TColumn.ReadOnly = true;
            this.TColumn.Width = 25;
            // 
            // GroupsColumn
            // 
            this.GroupsColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GroupsColumn.DataPropertyName = "Sub_groups";
            this.GroupsColumn.HeaderText = "Список групп";
            this.GroupsColumn.Name = "GroupsColumn";
            this.GroupsColumn.ReadOnly = true;
            // 
            // GColumn
            // 
            this.GColumn.HeaderText = " ";
            this.GColumn.MinimumWidth = 25;
            this.GColumn.Name = "GColumn";
            this.GColumn.ReadOnly = true;
            this.GColumn.Width = 25;
            // 
            // KafColumn
            // 
            this.KafColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.KafColumn.DataPropertyName = "Kaf";
            this.KafColumn.HeaderText = "Кафедра";
            this.KafColumn.Name = "KafColumn";
            // 
            // AuditoriesColumn
            // 
            this.AuditoriesColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AuditoriesColumn.DataPropertyName = "Auds";
            this.AuditoriesColumn.HeaderText = "Список аудиторий";
            this.AuditoriesColumn.Name = "AuditoriesColumn";
            this.AuditoriesColumn.ReadOnly = true;
            // 
            // AColumn
            // 
            this.AColumn.HeaderText = " ";
            this.AColumn.MinimumWidth = 25;
            this.AColumn.Name = "AColumn";
            this.AColumn.ReadOnly = true;
            this.AColumn.Width = 25;
            // 
            // DisciplineColumn
            // 
            this.DisciplineColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DisciplineColumn.DataPropertyName = "Discipline";
            this.DisciplineColumn.HeaderText = "Название дисциплины";
            this.DisciplineColumn.Name = "DisciplineColumn";
            // 
            // OnlineColumn
            // 
            this.OnlineColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OnlineColumn.DataPropertyName = "Is_online";
            this.OnlineColumn.HeaderText = "Занятие онлайн";
            this.OnlineColumn.Name = "OnlineColumn";
            this.OnlineColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // OwnersColumn
            // 
            this.OwnersColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OwnersColumn.DataPropertyName = "Owners";
            this.OwnersColumn.HeaderText = "Диспечер";
            this.OwnersColumn.Name = "OwnersColumn";
            // 
            // zanlist
            // 
            this.zanlist.DataPropertyName = "Zanlist";
            this.zanlist.HeaderText = "Объединенные в список";
            this.zanlist.Name = "zanlist";
            this.zanlist.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.zanlist.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 25;
            this.Column1.Name = "Column1";
            this.Column1.Width = 25;
            // 
            // MainWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 418);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Distribute);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.InformationDGV);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainWindows";
            this.Text = "MainWindows";
            ((System.ComponentModel.ISupportInitialize)(this.InformationDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleRowDataGridRowItemBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView InformationDGV;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveMenuItem;
        private System.Windows.Forms.BindingSource scheduleRowDataGridRowItemBindingSource;
        private System.Windows.Forms.ToolStripMenuItem FilterMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пожеланияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TeacherWishMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GroupWishMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AudsWishToolStripMenuItem;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button Distribute;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn NtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeachersColumn;
        private System.Windows.Forms.DataGridViewButtonColumn TColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupsColumn;
        private System.Windows.Forms.DataGridViewButtonColumn GColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn KafColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditoriesColumn;
        private System.Windows.Forms.DataGridViewButtonColumn AColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisciplineColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn OnlineColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OwnersColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn zanlist;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
    }
}

