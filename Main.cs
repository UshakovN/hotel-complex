using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DB;

namespace HotelComplex
{
    public partial class Main : Form
    {
        private Handler handler;
        private string[] tableNames;
        private string[] procNames;

        public Main()
        {
            InitializeComponent();
            handler = new Handler();
            var found = handler.GetTableNames(out tableNames);
            if (!found)
            {
                MessageBox.Show("Ошибка: не найдены таблицы базы данных.");
                Close();
                return;
            }
            found = handler.GetStoredProcedureNames(out procNames);
            if (!found)
            {
                MessageBox.Show("Ошибка: не найдены отчеты по базе данных.");
                Close();
                return;
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            var tablesForm = new Tables(tableNames, handler);
            tablesForm.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            var reports = new Reports(procNames, handler);
            reports.Show();
        }
    }
}
