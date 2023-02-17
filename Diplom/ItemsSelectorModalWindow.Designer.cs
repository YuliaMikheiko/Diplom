namespace Diplom
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
            this.Choice = new System.Windows.Forms.Button();
            this.ItemsDGV = new System.Windows.Forms.DataGridView();
            this.checkedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.keyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowCheckedItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Filter = new System.Windows.Forms.TextBox();
            this.Reset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowCheckedItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Choice
            // 
            this.Choice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Choice.Location = new System.Drawing.Point(363, 189);
            this.Choice.Name = "Choice";
            this.Choice.Size = new System.Drawing.Size(100, 23);
            this.Choice.TabIndex = 3;
            this.Choice.Text = "Выбрать";
            this.Choice.UseVisualStyleBackColor = true;
            this.Choice.Click += new System.EventHandler(this.Choice_Click);
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
            this.ValueColumn});
            this.ItemsDGV.DataSource = this.rowCheckedItemBindingSource;
            this.ItemsDGV.Location = new System.Drawing.Point(6, 1);
            this.ItemsDGV.Name = "ItemsDGV";
            this.ItemsDGV.Size = new System.Drawing.Size(349, 223);
            this.ItemsDGV.TabIndex = 2;
            // 
            // checkedDataGridViewCheckBoxColumn
            // 
            this.checkedDataGridViewCheckBoxColumn.DataPropertyName = "Checked";
            this.checkedDataGridViewCheckBoxColumn.HeaderText = "";
            this.checkedDataGridViewCheckBoxColumn.Name = "checkedDataGridViewCheckBoxColumn";
            this.checkedDataGridViewCheckBoxColumn.Width = 50;
            // 
            // keyDataGridViewTextBoxColumn
            // 
            this.keyDataGridViewTextBoxColumn.DataPropertyName = "Key";
            this.keyDataGridViewTextBoxColumn.HeaderText = "id";
            this.keyDataGridViewTextBoxColumn.Name = "keyDataGridViewTextBoxColumn";
            this.keyDataGridViewTextBoxColumn.Width = 50;
            // 
            // ValueColumn
            // 
            this.ValueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValueColumn.DataPropertyName = "Value";
            this.ValueColumn.HeaderText = "Список";
            this.ValueColumn.Name = "ValueColumn";
            // 
            // rowCheckedItemBindingSource
            // 
            this.rowCheckedItemBindingSource.DataSource = typeof(Diplom.RowCheckedItem);
            // 
            // Filter
            // 
            this.Filter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Filter.Location = new System.Drawing.Point(361, 12);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(100, 20);
            this.Filter.TabIndex = 4;
            this.Filter.TextChanged += new System.EventHandler(this.Filter_TextChanged);
            // 
            // Reset
            // 
            this.Reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Reset.Location = new System.Drawing.Point(363, 160);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(100, 23);
            this.Reset.TabIndex = 5;
            this.Reset.Text = "Сброс";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // ItemsSelectorModalWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 224);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.Filter);
            this.Controls.Add(this.Choice);
            this.Controls.Add(this.ItemsDGV);
            this.Name = "ItemsSelectorModalWindow";
            this.Text = "ItemsSelectorModalWindow";
            ((System.ComponentModel.ISupportInitialize)(this.ItemsDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowCheckedItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Choice;
        private System.Windows.Forms.BindingSource rowCheckedItemBindingSource;
        public System.Windows.Forms.DataGridView ItemsDGV;
        private System.Windows.Forms.TextBox Filter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
        private System.Windows.Forms.Button Reset;
    }
}