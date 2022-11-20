namespace HotelComplex
{
    partial class Reports
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFormReport = new System.Windows.Forms.Button();
            this.labelSelectReport = new System.Windows.Forms.Label();
            this.selectorReport = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(18, 146);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(384, 39);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFormReport
            // 
            this.btnFormReport.Location = new System.Drawing.Point(18, 89);
            this.btnFormReport.Name = "btnFormReport";
            this.btnFormReport.Size = new System.Drawing.Size(384, 39);
            this.btnFormReport.TabIndex = 6;
            this.btnFormReport.Text = "Сформировать отчет";
            this.btnFormReport.UseVisualStyleBackColor = true;
            this.btnFormReport.Click += new System.EventHandler(this.btnFormReport_Click);
            // 
            // labelSelectReport
            // 
            this.labelSelectReport.AutoSize = true;
            this.labelSelectReport.Location = new System.Drawing.Point(15, 18);
            this.labelSelectReport.Name = "labelSelectReport";
            this.labelSelectReport.Size = new System.Drawing.Size(113, 16);
            this.labelSelectReport.TabIndex = 5;
            this.labelSelectReport.Text = "Выберите отчет";
            // 
            // selectorReport
            // 
            this.selectorReport.FormattingEnabled = true;
            this.selectorReport.Location = new System.Drawing.Point(18, 47);
            this.selectorReport.Name = "selectorReport";
            this.selectorReport.Size = new System.Drawing.Size(384, 24);
            this.selectorReport.TabIndex = 4;
            this.selectorReport.SelectedIndexChanged += new System.EventHandler(this.selectorReport_SelectedIndexChanged);
            this.selectorReport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectorReport_KeyDown);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 207);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFormReport);
            this.Controls.Add(this.labelSelectReport);
            this.Controls.Add(this.selectorReport);
            this.Name = "Reports";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчеты";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnFormReport;
        private System.Windows.Forms.Label labelSelectReport;
        private System.Windows.Forms.ComboBox selectorReport;
    }
}