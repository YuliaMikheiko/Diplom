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
            this.components = new System.ComponentModel.Container();
            this.ItemsDGV = new System.Windows.Forms.DataGridView();
            this.Choice = new System.Windows.Forms.Button();
            this.checkedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.keyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowCheckedItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ItemsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowCheckedItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemsDGV
            // 
            this.ItemsDGV.AllowUserToAddRows = false;
            this.ItemsDGV.AllowUserToDeleteRows = false;
            this.ItemsDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemsDGV.AutoGenerateColumns = false;
            this.ItemsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkedDataGridViewCheckBoxColumn,
            this.keyDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.ItemsDGV.DataSource = this.rowCheckedItemBindingSource;
            this.ItemsDGV.Location = new System.Drawing.Point(0, 1);
            this.ItemsDGV.Name = "ItemsDGV";
            this.ItemsDGV.Size = new System.Drawing.Size(349, 223);
            this.ItemsDGV.TabIndex = 0;
            // 
            // Choice
            // 
            this.Choice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Choice.Location = new System.Drawing.Point(357, 189);
            this.Choice.Name = "Choice";
            this.Choice.Size = new System.Drawing.Size(100, 23);
            this.Choice.TabIndex = 1;
            this.Choice.Text = "Выбрать";
            this.Choice.UseVisualStyleBackColor = true;
            this.Choice.Click += new System.EventHandler(this.Choice_Click);
            // 
            // checkedDataGridViewCheckBoxColumn
            // 
            this.checkedDataGridViewCheckBoxColumn.DataPropertyName = "Checked";
            this.checkedDataGridViewCheckBoxColumn.HeaderText = "";
            this.checkedDataGridViewCheckBoxColumn.Name = "checkedDataGridViewCheckBoxColumn";
            this.checkedDataGridViewCheckBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.checkedDataGridViewCheckBoxColumn.Width = 50;
            // 
            // keyDataGridViewTextBoxColumn
            // 
            this.keyDataGridViewTextBoxColumn.DataPropertyName = "Key";
            this.keyDataGridViewTextBoxColumn.HeaderText = "id";
            this.keyDataGridViewTextBoxColumn.Name = "keyDataGridViewTextBoxColumn";
            this.keyDataGridViewTextBoxColumn.Width = 50;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Список";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            // 
            // rowCheckedItemBindingSource
            // 
            this.rowCheckedItemBindingSource.DataSource = typeof(WindowsFormsApp2.RowCheckedItem);
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
            ((System.ComponentModel.ISupportInitialize)(this.rowCheckedItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ItemsDGV;
        private System.Windows.Forms.Button Choice;
        private System.Windows.Forms.BindingSource rowCheckedItemBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
    }
}