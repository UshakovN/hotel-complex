namespace HotelComplex
{
    partial class Main
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
            this.btnTables = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTables
            // 
            this.btnTables.Location = new System.Drawing.Point(12, 52);
            this.btnTables.Name = "btnTables";
            this.btnTables.Size = new System.Drawing.Size(362, 44);
            this.btnTables.TabIndex = 0;
            this.btnTables.Text = "Таблицы";
            this.btnTables.UseVisualStyleBackColor = true;
            this.btnTables.Click += new System.EventHandler(this.btnTables_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(12, 118);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(362, 44);
            this.btnReports.TabIndex = 0;
            this.btnReports.Text = "Отчеты";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 186);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(362, 39);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Выход";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuInfo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(386, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(59, 24);
            this.menuFile.Text = "Файл";
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(136, 26);
            this.menuExit.Text = "Выход";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuInfo
            // 
            this.menuInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbout});
            this.menuInfo.Name = "menuInfo";
            this.menuInfo.Size = new System.Drawing.Size(62, 24);
            this.menuInfo.Text = "Инфо";
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(187, 26);
            this.menuAbout.Text = "О программе";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 255);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnTables);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Гостиничный комплекс";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTables;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuInfo;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
    }
}

