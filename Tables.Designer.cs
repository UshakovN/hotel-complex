namespace HotelComplex
{
    partial class Tables
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
            this.selectorTable = new System.Windows.Forms.ComboBox();
            this.labelSelectTable = new System.Windows.Forms.Label();
            this.btnShowTable = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectorTable
            // 
            this.selectorTable.FormattingEnabled = true;
            this.selectorTable.Location = new System.Drawing.Point(17, 49);
            this.selectorTable.Name = "selectorTable";
            this.selectorTable.Size = new System.Drawing.Size(384, 24);
            this.selectorTable.TabIndex = 0;
            this.selectorTable.SelectedIndexChanged += new System.EventHandler(this.selectorTable_SelectedIndexChanged);
            this.selectorTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectorTable_KeyDown);
            // 
            // labelSelectTable
            // 
            this.labelSelectTable.AutoSize = true;
            this.labelSelectTable.Location = new System.Drawing.Point(14, 20);
            this.labelSelectTable.Name = "labelSelectTable";
            this.labelSelectTable.Size = new System.Drawing.Size(130, 16);
            this.labelSelectTable.TabIndex = 1;
            this.labelSelectTable.Text = "Выберите таблицу";
            // 
            // btnShowTable
            // 
            this.btnShowTable.Location = new System.Drawing.Point(17, 91);
            this.btnShowTable.Name = "btnShowTable";
            this.btnShowTable.Size = new System.Drawing.Size(384, 39);
            this.btnShowTable.TabIndex = 2;
            this.btnShowTable.Text = "Показать таблицу";
            this.btnShowTable.UseVisualStyleBackColor = true;
            this.btnShowTable.Click += new System.EventHandler(this.btnShowTable_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(17, 148);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(384, 39);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Tables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 208);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnShowTable);
            this.Controls.Add(this.labelSelectTable);
            this.Controls.Add(this.selectorTable);
            this.Name = "Tables";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор таблицы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox selectorTable;
        private System.Windows.Forms.Label labelSelectTable;
        private System.Windows.Forms.Button btnShowTable;
        private System.Windows.Forms.Button btnClose;
    }
}