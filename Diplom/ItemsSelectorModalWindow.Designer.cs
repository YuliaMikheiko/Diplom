namespace WindowsFormsApp2
{
    partial class ItemsSelectorModalWindow
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
            this.TeachersDGV = new System.Windows.Forms.DataGridView();
            this.Choice = new System.Windows.Forms.Button();
            this.GroupsDGV = new System.Windows.Forms.DataGridView();
            this.AuditorysDVG = new System.Windows.Forms.DataGridView();
            this.ACheckColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ATitleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GCheckColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GTitleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TCheckColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TeachersDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AuditorysDVG)).BeginInit();
            this.SuspendLayout();
            // 
            // TeachersDGV
            // 
            this.TeachersDGV.AllowUserToAddRows = false;
            this.TeachersDGV.AllowUserToDeleteRows = false;
            this.TeachersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TeachersDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TCheckColumn,
            this.TIdColumn,
            this.TNameColumn});
            this.TeachersDGV.Dock = System.Windows.Forms.DockStyle.Left;
            this.TeachersDGV.Location = new System.Drawing.Point(0, 0);
            this.TeachersDGV.Name = "TeachersDGV";
            this.TeachersDGV.Size = new System.Drawing.Size(349, 224);
            this.TeachersDGV.TabIndex = 0;
            this.TeachersDGV.Visible = false;
            // 
            // Choice
            // 
            this.Choice.Location = new System.Drawing.Point(369, 189);
            this.Choice.Name = "Choice";
            this.Choice.Size = new System.Drawing.Size(88, 23);
            this.Choice.TabIndex = 1;
            this.Choice.Text = "Выбрать";
            this.Choice.UseVisualStyleBackColor = true;
            this.Choice.Click += new System.EventHandler(this.Choice_Click);
            // 
            // GroupsDGV
            // 
            this.GroupsDGV.AllowUserToAddRows = false;
            this.GroupsDGV.AllowUserToDeleteRows = false;
            this.GroupsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GroupsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GCheckColumn,
            this.GIdColumn,
            this.GTitleColumn});
            this.GroupsDGV.Location = new System.Drawing.Point(0, 0);
            this.GroupsDGV.Name = "GroupsDGV";
            this.GroupsDGV.Size = new System.Drawing.Size(349, 224);
            this.GroupsDGV.TabIndex = 2;
            this.GroupsDGV.Visible = false;
            // 
            // AuditorysDVG
            // 
            this.AuditorysDVG.AllowUserToAddRows = false;
            this.AuditorysDVG.AllowUserToDeleteRows = false;
            this.AuditorysDVG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AuditorysDVG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ACheckColumn,
            this.AIdColumn,
            this.ATitleColumn});
            this.AuditorysDVG.Location = new System.Drawing.Point(0, 0);
            this.AuditorysDVG.Name = "AuditorysDVG";
            this.AuditorysDVG.Size = new System.Drawing.Size(349, 224);
            this.AuditorysDVG.TabIndex = 3;
            this.AuditorysDVG.Visible = false;
            // 
            // ACheckColumn
            // 
            this.ACheckColumn.HeaderText = "";
            this.ACheckColumn.Name = "ACheckColumn";
            this.ACheckColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // AIdColumn
            // 
            this.AIdColumn.HeaderText = "id";
            this.AIdColumn.Name = "AIdColumn";
            this.AIdColumn.ReadOnly = true;
            // 
            // ATitleColumn
            // 
            this.ATitleColumn.HeaderText = "Номер аудитории";
            this.ATitleColumn.Name = "ATitleColumn";
            this.ATitleColumn.ReadOnly = true;
            // 
            // GCheckColumn
            // 
            this.GCheckColumn.HeaderText = "";
            this.GCheckColumn.Name = "GCheckColumn";
            this.GCheckColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // GIdColumn
            // 
            this.GIdColumn.HeaderText = "id";
            this.GIdColumn.Name = "GIdColumn";
            this.GIdColumn.ReadOnly = true;
            // 
            // GTitleColumn
            // 
            this.GTitleColumn.HeaderText = "Шифр группы";
            this.GTitleColumn.Name = "GTitleColumn";
            this.GTitleColumn.ReadOnly = true;
            // 
            // TCheckColumn
            // 
            this.TCheckColumn.HeaderText = "";
            this.TCheckColumn.Name = "TCheckColumn";
            this.TCheckColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TIdColumn
            // 
            this.TIdColumn.HeaderText = "id";
            this.TIdColumn.Name = "TIdColumn";
            this.TIdColumn.ReadOnly = true;
            // 
            // TNameColumn
            // 
            this.TNameColumn.HeaderText = "ФИО преподавателя";
            this.TNameColumn.Name = "TNameColumn";
            this.TNameColumn.ReadOnly = true;
            // 
            // ModalWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 224);
            this.Controls.Add(this.AuditorysDVG);
            this.Controls.Add(this.GroupsDGV);
            this.Controls.Add(this.Choice);
            this.Controls.Add(this.TeachersDGV);
            this.Name = "ModalWindows";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.TeachersDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupsDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AuditorysDVG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TeachersDGV;
        private System.Windows.Forms.Button Choice;
        private System.Windows.Forms.DataGridView GroupsDGV;
        private System.Windows.Forms.DataGridView AuditorysDVG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TCheckColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TNameColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn GCheckColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GTitleColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ACheckColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATitleColumn;
    }
}