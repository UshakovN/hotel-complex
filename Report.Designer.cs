namespace HotelComplex
{
    partial class Report
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
            this.tbClientName = new System.Windows.Forms.TextBox();
            this.tbClientSurname = new System.Windows.Forms.TextBox();
            this.tbRoomId = new System.Windows.Forms.TextBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.tbCost = new System.Windows.Forms.TextBox();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.labelClient = new System.Windows.Forms.Label();
            this.labelClientSurname = new System.Windows.Forms.Label();
            this.labelRoomId = new System.Windows.Forms.Label();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelCost = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.tbReportDesription = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // tbClientName
            // 
            this.tbClientName.Location = new System.Drawing.Point(181, 127);
            this.tbClientName.Name = "tbClientName";
            this.tbClientName.Size = new System.Drawing.Size(233, 22);
            this.tbClientName.TabIndex = 0;
            // 
            // tbClientSurname
            // 
            this.tbClientSurname.Location = new System.Drawing.Point(181, 165);
            this.tbClientSurname.Name = "tbClientSurname";
            this.tbClientSurname.Size = new System.Drawing.Size(233, 22);
            this.tbClientSurname.TabIndex = 1;
            // 
            // tbRoomId
            // 
            this.tbRoomId.Location = new System.Drawing.Point(793, 78);
            this.tbRoomId.Name = "tbRoomId";
            this.tbRoomId.Size = new System.Drawing.Size(233, 22);
            this.tbRoomId.TabIndex = 2;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(793, 120);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(233, 24);
            this.cbCategory.TabIndex = 3;
            this.cbCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCategory_KeyDown);
            // 
            // tbCost
            // 
            this.tbCost.Location = new System.Drawing.Point(793, 162);
            this.tbCost.Name = "tbCost";
            this.tbCost.Size = new System.Drawing.Size(233, 22);
            this.tbCost.TabIndex = 4;
            // 
            // dtDate
            // 
            this.dtDate.Location = new System.Drawing.Point(792, 37);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(233, 22);
            this.dtDate.TabIndex = 6;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(1139, 76);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(221, 33);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Сформировать отчет";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1139, 130);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(221, 34);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Закрыть окно отчета";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtEndDate
            // 
            this.dtEndDate.Location = new System.Drawing.Point(181, 82);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(233, 22);
            this.dtEndDate.TabIndex = 9;
            // 
            // dtStartDate
            // 
            this.dtStartDate.Location = new System.Drawing.Point(181, 42);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(233, 22);
            this.dtStartDate.TabIndex = 10;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(12, 223);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(1401, 444);
            this.dgv.TabIndex = 11;
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Location = new System.Drawing.Point(76, 130);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(90, 16);
            this.labelClient.TabIndex = 12;
            this.labelClient.Text = "Имя клиента";
            // 
            // labelClientSurname
            // 
            this.labelClientSurname.AutoSize = true;
            this.labelClientSurname.Location = new System.Drawing.Point(43, 168);
            this.labelClientSurname.Name = "labelClientSurname";
            this.labelClientSurname.Size = new System.Drawing.Size(123, 16);
            this.labelClientSurname.TabIndex = 12;
            this.labelClientSurname.Text = "Фамилия клиента";
            // 
            // labelRoomId
            // 
            this.labelRoomId.AutoSize = true;
            this.labelRoomId.Location = new System.Drawing.Point(667, 81);
            this.labelRoomId.Name = "labelRoomId";
            this.labelRoomId.Size = new System.Drawing.Size(103, 16);
            this.labelRoomId.TabIndex = 12;
            this.labelRoomId.Text = "Номер в отеле";
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(597, 123);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(180, 16);
            this.labelCategory.TabIndex = 12;
            this.labelCategory.Text = "Категория номера в отеле";
            // 
            // labelCost
            // 
            this.labelCost.AutoSize = true;
            this.labelCost.Location = new System.Drawing.Point(554, 165);
            this.labelCost.Name = "labelCost";
            this.labelCost.Size = new System.Drawing.Size(224, 16);
            this.labelCost.TabIndex = 12;
            this.labelCost.Text = "Новая стоимость номера в отеле";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(680, 42);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(97, 16);
            this.labelDate.TabIndex = 12;
            this.labelDate.Text = "Текущая дата";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(73, 48);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(90, 16);
            this.labelStartDate.TabIndex = 12;
            this.labelStartDate.Text = "Дата заезда";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(74, 87);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(91, 16);
            this.labelEndDate.TabIndex = 12;
            this.labelEndDate.Text = "Дата выезда";
            // 
            // tbReportDesription
            // 
            this.tbReportDesription.Location = new System.Drawing.Point(14, 685);
            this.tbReportDesription.Multiline = true;
            this.tbReportDesription.Name = "tbReportDesription";
            this.tbReportDesription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbReportDesription.Size = new System.Drawing.Size(1399, 28);
            this.tbReportDesription.TabIndex = 13;
            this.tbReportDesription.Text = "Описание отчета";
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 732);
            this.Controls.Add(this.tbReportDesription);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelCost);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.labelRoomId);
            this.Controls.Add(this.labelClientSurname);
            this.Controls.Add(this.labelClient);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.dtStartDate);
            this.Controls.Add(this.dtEndDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.tbCost);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.tbRoomId);
            this.Controls.Add(this.tbClientSurname);
            this.Controls.Add(this.tbClientName);
            this.Name = "Report";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчет";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbClientName;
        private System.Windows.Forms.TextBox tbClientSurname;
        private System.Windows.Forms.TextBox tbRoomId;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.TextBox tbCost;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.Label labelClientSurname;
        private System.Windows.Forms.Label labelRoomId;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Label labelCost;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.TextBox tbReportDesription;
    }
}