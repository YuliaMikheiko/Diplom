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
            this.ItemsDGV = new System.Windows.Forms.DataGridView();
            this.Choice = new System.Windows.Forms.Button();
            this.TCheckColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemsDGV
            // 
            this.ItemsDGV.AllowUserToAddRows = false;
            this.ItemsDGV.AllowUserToDeleteRows = false;
            this.ItemsDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TCheckColumn,
            this.TIdColumn,
            this.TNameColumn});
            this.ItemsDGV.Location = new System.Drawing.Point(0, 1);
            this.ItemsDGV.Name = "ItemsDGV";
            this.ItemsDGV.Size = new System.Drawing.Size(349, 223);
            this.ItemsDGV.TabIndex = 0;
            // 
            // Choice
            // 
            this.Choice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Choice.Location = new System.Drawing.Point(369, 189);
            this.Choice.Name = "Choice";
            this.Choice.Size = new System.Drawing.Size(88, 23);
            this.Choice.TabIndex = 1;
            this.Choice.Text = "Выбрать";
            this.Choice.UseVisualStyleBackColor = true;
            this.Choice.Click += new System.EventHandler(this.Choice_Click);
            // 
            // TCheckColumn
            // 
            this.TCheckColumn.HeaderText = "";
            this.TCheckColumn.Name = "TCheckColumn";
            this.TCheckColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TCheckColumn.Width = 50;
            // 
            // TIdColumn
            // 
            this.TIdColumn.HeaderText = "id";
            this.TIdColumn.Name = "TIdColumn";
            this.TIdColumn.ReadOnly = true;
            this.TIdColumn.Width = 50;
            // 
            // TNameColumn
            // 
            this.TNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TNameColumn.HeaderText = "Список";
            this.TNameColumn.Name = "TNameColumn";
            this.TNameColumn.ReadOnly = true;
            // 
            // ItemsSelectorModalWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 224);
            this.Controls.Add(this.Choice);
            this.Controls.Add(this.ItemsDGV);
            this.Name = "ItemsSelectorModalWindow";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.ItemsDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ItemsDGV;
        private System.Windows.Forms.Button Choice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TCheckColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TNameColumn;
    }
}