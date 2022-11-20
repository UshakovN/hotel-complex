using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelComplex
{
    public partial class Reports : Form
    {
        private Handler handler;

        public Reports(string[] tables, Handler handler)
        {
            InitializeComponent();
            selectorReport.Items.AddRange(tables);
            this.handler = handler;
            btnFormReport.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFormReport_Click(object sender, EventArgs e)
        {
            var reportName = selectorReport.Text;
            var report = new Report(reportName, handler);
            report.Show();
        }

        private void selectorReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnFormReport.Enabled = selectorReport.Text != "";
        }

        private void selectorReport_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}
