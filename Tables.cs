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
    public partial class Tables : Form
    {
        private Handler handler;
        private string tableName;

        public Tables(string[] tables, Handler handler)
        {
            InitializeComponent();
            selectorTable.Items.AddRange(tables);
            this.handler = handler;
            btnShowTable.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnShowTable_Click(object sender, EventArgs e)
        {
            tableName = selectorTable.Text;
            var found = handler.Scan(tableName, out DataTable tableData);
            if (!found)
            {
                MessageBox.Show($"Предупреждение: записи в таблице {tableName} не найдены.");
            }
            var table = new Table(tableName, tableData, handler);
            table.Show();
        }

        private void selectorTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnShowTable.Enabled = selectorTable.Text != "";
        }

        private void selectorTable_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}
