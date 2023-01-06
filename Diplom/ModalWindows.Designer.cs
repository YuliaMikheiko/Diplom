namespace WindowsFormsApp2
{
    partial class ModalWindows
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
            this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Choice = new System.Windows.Forms.Button();
            this.GroupsDGV = new System.Windows.Forms.DataGridView();
            this.AuditorysDVG = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TeachersDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AuditorysDVG)).BeginInit();
            this.SuspendLayout();
            // 
            // TeachersDGV
            // 
            this.TeachersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TeachersDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column8,
            this.Column9});
            this.TeachersDGV.Dock = System.Windows.Forms.DockStyle.Left;
            this.TeachersDGV.Location = new System.Drawing.Point(0, 0);
            this.TeachersDGV.Name = "TeachersDGV";
            this.TeachersDGV.Size = new System.Drawing.Size(349, 224);
            this.TeachersDGV.TabIndex = 0;
            this.TeachersDGV.Visible = false;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "";
            this.Column7.Name = "Column7";
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "id";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "ФИО преподавателя";
            this.Column9.Name = "Column9";
            // 
            // Choice
            // 
            this.Choice.Location = new System.Drawing.Point(382, 189);
            this.Choice.Name = "Choice";
            this.Choice.Size = new System.Drawing.Size(75, 23);
            this.Choice.TabIndex = 1;
            this.Choice.Text = "Выбрать";
            this.Choice.UseVisualStyleBackColor = true;
            this.Choice.Click += new System.EventHandler(this.Choice_Click);
            // 
            // GroupsDGV
            // 
            this.GroupsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GroupsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column6});
            this.GroupsDGV.Location = new System.Drawing.Point(0, 0);
            this.GroupsDGV.Name = "GroupsDGV";
            this.GroupsDGV.Size = new System.Drawing.Size(349, 224);
            this.GroupsDGV.TabIndex = 2;
            this.GroupsDGV.Visible = false;
            // 
            // AuditorysDVG
            // 
            this.AuditorysDVG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AuditorysDVG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.AuditorysDVG.Location = new System.Drawing.Point(0, 0);
            this.AuditorysDVG.Name = "AuditorysDVG";
            this.AuditorysDVG.Size = new System.Drawing.Size(349, 224);
            this.AuditorysDVG.TabIndex = 3;
            this.AuditorysDVG.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "id";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Номер аудитории";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "";
            this.Column4.Name = "Column4";
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "id";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Шифр группы";
            this.Column6.Name = "Column6";
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}