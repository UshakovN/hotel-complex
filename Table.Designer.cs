namespace HotelComplex
{
    partial class Table
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnChangeRow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(12, 12);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv.Size = new System.Drawing.Size(1092, 330);
            this.dgv.TabIndex = 0;
            this.dgv.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_DataError);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(590, 368);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(161, 49);
            this.btnAddRow.TabIndex = 1;
            this.btnAddRow.Text = "Добавить запись";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Location = new System.Drawing.Point(766, 369);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(161, 49);
            this.btnDeleteRow.TabIndex = 2;
            this.btnDeleteRow.Text = "Удалить запись";
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(413, 368);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(161, 50);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Обновить таблицу";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(11, 362);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(378, 22);
            this.tbSearch.TabIndex = 4;
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(9, 394);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(163, 32);
            this.labelSearch.TabIndex = 5;
            this.labelSearch.Text = "Быстрый поиск записей\r\nв таблице";
            this.labelSearch.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(197, 392);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(189, 36);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Найти записи";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnChangeRow
            // 
            this.btnChangeRow.Location = new System.Drawing.Point(943, 370);
            this.btnChangeRow.Name = "btnChangeRow";
            this.btnChangeRow.Size = new System.Drawing.Size(161, 48);
            this.btnChangeRow.TabIndex = 7;
            this.btnChangeRow.Text = "Обновить запись";
            this.btnChangeRow.UseVisualStyleBackColor = true;
            this.btnChangeRow.Click += new System.EventHandler(this.btnChangeRow_Click);
            // 
            // Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 445);
            this.Controls.Add(this.btnChangeRow);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDeleteRow);
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.dgv);
            this.Name = "Table";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Просмотр таблицы";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnChangeRow;
    }
}