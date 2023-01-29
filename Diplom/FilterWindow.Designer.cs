namespace Diplom
{
    partial class FilterWindow
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
            this.Filter = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.KursButton = new System.Windows.Forms.Button();
            this.NtButton = new System.Windows.Forms.Button();
            this.KursCheckBox = new System.Windows.Forms.CheckBox();
            this.NtCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.KafedraCheckBox = new System.Windows.Forms.CheckBox();
            this.GroupsCheckBox = new System.Windows.Forms.CheckBox();
            this.TeacherCheckBox = new System.Windows.Forms.CheckBox();
            this.AuditorysCheckBox = new System.Windows.Forms.CheckBox();
            this.DisciplineCheckBox = new System.Windows.Forms.CheckBox();
            this.KafedraTextBox = new System.Windows.Forms.TextBox();
            this.TeacherTextBox = new System.Windows.Forms.TextBox();
            this.AuditorysTextBox = new System.Windows.Forms.TextBox();
            this.DisciplineTextBox = new System.Windows.Forms.TextBox();
            this.GroupsTextBox = new System.Windows.Forms.TextBox();
            this.AuditorysButton = new System.Windows.Forms.Button();
            this.DisciplineButton = new System.Windows.Forms.Button();
            this.TeacherButton = new System.Windows.Forms.Button();
            this.KafedraButton = new System.Windows.Forms.Button();
            this.GroupsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NtTextBox = new System.Windows.Forms.TextBox();
            this.KursTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Filter
            // 
            this.Filter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Filter.Location = new System.Drawing.Point(423, 252);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(75, 23);
            this.Filter.TabIndex = 1;
            this.Filter.Text = "Фильтр";
            this.Filter.UseVisualStyleBackColor = true;
            this.Filter.Click += new System.EventHandler(this.Filter_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.30588F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0047F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.68567F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.003757F));
            this.tableLayoutPanel1.Controls.Add(this.KursButton, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.NtButton, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.KursCheckBox, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.NtCheckBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.KafedraCheckBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.GroupsCheckBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TeacherCheckBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.AuditorysCheckBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.DisciplineCheckBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.KafedraTextBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.TeacherTextBox, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.AuditorysTextBox, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.DisciplineTextBox, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.GroupsTextBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.AuditorysButton, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.DisciplineButton, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.TeacherButton, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.KafedraButton, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.GroupsButton, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.NtTextBox, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.KursTextBox, 2, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(507, 232);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // KursButton
            // 
            this.KursButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KursButton.Location = new System.Drawing.Point(468, 177);
            this.KursButton.Name = "KursButton";
            this.KursButton.Size = new System.Drawing.Size(36, 23);
            this.KursButton.TabIndex = 30;
            this.KursButton.Text = "...";
            this.KursButton.UseVisualStyleBackColor = true;
            this.KursButton.Click += new System.EventHandler(this.KursButton_Click);
            // 
            // NtButton
            // 
            this.NtButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NtButton.Location = new System.Drawing.Point(468, 148);
            this.NtButton.Name = "NtButton";
            this.NtButton.Size = new System.Drawing.Size(36, 23);
            this.NtButton.TabIndex = 29;
            this.NtButton.Text = "...";
            this.NtButton.UseVisualStyleBackColor = true;
            this.NtButton.Click += new System.EventHandler(this.NtButton_Click);
            // 
            // KursCheckBox
            // 
            this.KursCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KursCheckBox.AutoSize = true;
            this.KursCheckBox.Location = new System.Drawing.Point(141, 177);
            this.KursCheckBox.Name = "KursCheckBox";
            this.KursCheckBox.Size = new System.Drawing.Size(44, 23);
            this.KursCheckBox.TabIndex = 27;
            this.KursCheckBox.Text = "не";
            this.KursCheckBox.UseVisualStyleBackColor = true;
            // 
            // NtCheckBox
            // 
            this.NtCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NtCheckBox.AutoSize = true;
            this.NtCheckBox.Location = new System.Drawing.Point(141, 148);
            this.NtCheckBox.Name = "NtCheckBox";
            this.NtCheckBox.Size = new System.Drawing.Size(44, 23);
            this.NtCheckBox.TabIndex = 26;
            this.NtCheckBox.Text = "не";
            this.NtCheckBox.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 29);
            this.label7.TabIndex = 24;
            this.label7.Text = "Курс";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 29);
            this.label6.TabIndex = 23;
            this.label6.Text = "Тип занятия";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Кафедра";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Преподаватели";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "Аудитории";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "Название дисциплин";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KafedraCheckBox
            // 
            this.KafedraCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KafedraCheckBox.AutoSize = true;
            this.KafedraCheckBox.Location = new System.Drawing.Point(141, 32);
            this.KafedraCheckBox.Name = "KafedraCheckBox";
            this.KafedraCheckBox.Size = new System.Drawing.Size(44, 23);
            this.KafedraCheckBox.TabIndex = 6;
            this.KafedraCheckBox.Text = "не";
            this.KafedraCheckBox.UseVisualStyleBackColor = true;
            // 
            // GroupsCheckBox
            // 
            this.GroupsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupsCheckBox.AutoSize = true;
            this.GroupsCheckBox.Location = new System.Drawing.Point(141, 3);
            this.GroupsCheckBox.Name = "GroupsCheckBox";
            this.GroupsCheckBox.Size = new System.Drawing.Size(44, 23);
            this.GroupsCheckBox.TabIndex = 5;
            this.GroupsCheckBox.Text = "не";
            this.GroupsCheckBox.UseVisualStyleBackColor = true;
            // 
            // TeacherCheckBox
            // 
            this.TeacherCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TeacherCheckBox.AutoSize = true;
            this.TeacherCheckBox.Location = new System.Drawing.Point(141, 61);
            this.TeacherCheckBox.Name = "TeacherCheckBox";
            this.TeacherCheckBox.Size = new System.Drawing.Size(44, 23);
            this.TeacherCheckBox.TabIndex = 7;
            this.TeacherCheckBox.Text = "не";
            this.TeacherCheckBox.UseVisualStyleBackColor = true;
            // 
            // AuditorysCheckBox
            // 
            this.AuditorysCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AuditorysCheckBox.AutoSize = true;
            this.AuditorysCheckBox.Location = new System.Drawing.Point(141, 90);
            this.AuditorysCheckBox.Name = "AuditorysCheckBox";
            this.AuditorysCheckBox.Size = new System.Drawing.Size(44, 23);
            this.AuditorysCheckBox.TabIndex = 8;
            this.AuditorysCheckBox.Text = "не";
            this.AuditorysCheckBox.UseVisualStyleBackColor = true;
            // 
            // DisciplineCheckBox
            // 
            this.DisciplineCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisciplineCheckBox.AutoSize = true;
            this.DisciplineCheckBox.Location = new System.Drawing.Point(141, 119);
            this.DisciplineCheckBox.Name = "DisciplineCheckBox";
            this.DisciplineCheckBox.Size = new System.Drawing.Size(44, 23);
            this.DisciplineCheckBox.TabIndex = 9;
            this.DisciplineCheckBox.Text = "не";
            this.DisciplineCheckBox.UseVisualStyleBackColor = true;
            // 
            // KafedraTextBox
            // 
            this.KafedraTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KafedraTextBox.Location = new System.Drawing.Point(191, 32);
            this.KafedraTextBox.Name = "KafedraTextBox";
            this.KafedraTextBox.ReadOnly = true;
            this.KafedraTextBox.Size = new System.Drawing.Size(271, 20);
            this.KafedraTextBox.TabIndex = 11;
            this.KafedraTextBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GroupsTextBox_MouseMove);
            // 
            // TeacherTextBox
            // 
            this.TeacherTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TeacherTextBox.Location = new System.Drawing.Point(191, 61);
            this.TeacherTextBox.Name = "TeacherTextBox";
            this.TeacherTextBox.ReadOnly = true;
            this.TeacherTextBox.Size = new System.Drawing.Size(271, 20);
            this.TeacherTextBox.TabIndex = 12;
            this.TeacherTextBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GroupsTextBox_MouseMove);
            // 
            // AuditorysTextBox
            // 
            this.AuditorysTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AuditorysTextBox.Location = new System.Drawing.Point(191, 90);
            this.AuditorysTextBox.Name = "AuditorysTextBox";
            this.AuditorysTextBox.ReadOnly = true;
            this.AuditorysTextBox.Size = new System.Drawing.Size(271, 20);
            this.AuditorysTextBox.TabIndex = 13;
            this.AuditorysTextBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GroupsTextBox_MouseMove);
            // 
            // DisciplineTextBox
            // 
            this.DisciplineTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisciplineTextBox.Location = new System.Drawing.Point(191, 119);
            this.DisciplineTextBox.Name = "DisciplineTextBox";
            this.DisciplineTextBox.ReadOnly = true;
            this.DisciplineTextBox.Size = new System.Drawing.Size(271, 20);
            this.DisciplineTextBox.TabIndex = 14;
            this.DisciplineTextBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GroupsTextBox_MouseMove);
            // 
            // GroupsTextBox
            // 
            this.GroupsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupsTextBox.Location = new System.Drawing.Point(191, 3);
            this.GroupsTextBox.Name = "GroupsTextBox";
            this.GroupsTextBox.ReadOnly = true;
            this.GroupsTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GroupsTextBox.Size = new System.Drawing.Size(271, 20);
            this.GroupsTextBox.TabIndex = 10;
            this.GroupsTextBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GroupsTextBox_MouseMove);
            // 
            // AuditorysButton
            // 
            this.AuditorysButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AuditorysButton.Location = new System.Drawing.Point(468, 90);
            this.AuditorysButton.Name = "AuditorysButton";
            this.AuditorysButton.Size = new System.Drawing.Size(36, 23);
            this.AuditorysButton.TabIndex = 18;
            this.AuditorysButton.Text = "...";
            this.AuditorysButton.UseVisualStyleBackColor = true;
            this.AuditorysButton.Click += new System.EventHandler(this.AuditorysButton_Click);
            // 
            // DisciplineButton
            // 
            this.DisciplineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisciplineButton.Location = new System.Drawing.Point(468, 119);
            this.DisciplineButton.Name = "DisciplineButton";
            this.DisciplineButton.Size = new System.Drawing.Size(36, 23);
            this.DisciplineButton.TabIndex = 19;
            this.DisciplineButton.Text = "...";
            this.DisciplineButton.UseVisualStyleBackColor = true;
            this.DisciplineButton.Click += new System.EventHandler(this.DisciplineButton_Click);
            // 
            // TeacherButton
            // 
            this.TeacherButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TeacherButton.Location = new System.Drawing.Point(468, 61);
            this.TeacherButton.Name = "TeacherButton";
            this.TeacherButton.Size = new System.Drawing.Size(36, 23);
            this.TeacherButton.TabIndex = 17;
            this.TeacherButton.Text = "...";
            this.TeacherButton.UseVisualStyleBackColor = true;
            this.TeacherButton.Click += new System.EventHandler(this.TeacherButton_Click);
            // 
            // KafedraButton
            // 
            this.KafedraButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KafedraButton.Location = new System.Drawing.Point(468, 32);
            this.KafedraButton.Name = "KafedraButton";
            this.KafedraButton.Size = new System.Drawing.Size(36, 23);
            this.KafedraButton.TabIndex = 16;
            this.KafedraButton.Text = "...";
            this.KafedraButton.UseVisualStyleBackColor = true;
            this.KafedraButton.Click += new System.EventHandler(this.KafedraButton_Click);
            // 
            // GroupsButton
            // 
            this.GroupsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupsButton.Location = new System.Drawing.Point(468, 3);
            this.GroupsButton.Name = "GroupsButton";
            this.GroupsButton.Size = new System.Drawing.Size(36, 23);
            this.GroupsButton.TabIndex = 15;
            this.GroupsButton.Text = "...";
            this.GroupsButton.UseVisualStyleBackColor = true;
            this.GroupsButton.Click += new System.EventHandler(this.GroupsButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Группы";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NtTextBox
            // 
            this.NtTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NtTextBox.Location = new System.Drawing.Point(191, 148);
            this.NtTextBox.Name = "NtTextBox";
            this.NtTextBox.ReadOnly = true;
            this.NtTextBox.Size = new System.Drawing.Size(271, 20);
            this.NtTextBox.TabIndex = 20;
            this.NtTextBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GroupsTextBox_MouseMove);
            // 
            // KursTextBox
            // 
            this.KursTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KursTextBox.Location = new System.Drawing.Point(191, 177);
            this.KursTextBox.Name = "KursTextBox";
            this.KursTextBox.ReadOnly = true;
            this.KursTextBox.Size = new System.Drawing.Size(271, 20);
            this.KursTextBox.TabIndex = 21;
            this.KursTextBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GroupsTextBox_MouseMove);
            // 
            // FilterWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 284);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Filter);
            this.Name = "FilterWindow";
            this.Text = "FilterWindow";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Filter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox KafedraCheckBox;
        private System.Windows.Forms.CheckBox GroupsCheckBox;
        private System.Windows.Forms.CheckBox TeacherCheckBox;
        private System.Windows.Forms.CheckBox AuditorysCheckBox;
        private System.Windows.Forms.CheckBox DisciplineCheckBox;
        private System.Windows.Forms.TextBox KafedraTextBox;
        private System.Windows.Forms.TextBox TeacherTextBox;
        private System.Windows.Forms.TextBox AuditorysTextBox;
        private System.Windows.Forms.TextBox DisciplineTextBox;
        private System.Windows.Forms.TextBox GroupsTextBox;
        private System.Windows.Forms.Button AuditorysButton;
        private System.Windows.Forms.Button DisciplineButton;
        private System.Windows.Forms.Button TeacherButton;
        private System.Windows.Forms.Button KafedraButton;
        private System.Windows.Forms.Button GroupsButton;
        private System.Windows.Forms.Button KursButton;
        private System.Windows.Forms.Button NtButton;
        private System.Windows.Forms.CheckBox KursCheckBox;
        private System.Windows.Forms.CheckBox NtCheckBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox NtTextBox;
        private System.Windows.Forms.TextBox KursTextBox;
    }
}