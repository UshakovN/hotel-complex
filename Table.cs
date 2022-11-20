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
    public partial class Table : Form
    {
        private readonly string btnAddBaseText = "Добавить запись";
        private readonly string btnAddConfirmText = "Подтвердить";
        
        private bool stateBtnAdd = false;

        private Handler handler;
        private DataTable tableData;
        private string tableName;

        public Table(string table, DataTable data, Handler handler)
        {
            InitializeComponent();
            SetInitialControlsProperties(table, data, handler);
            SetDataGridColumnProperties(dgv);
            UpdateDataGrid(dgv, data);
            SetReadonlyIdColumn(dgv);
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            if (!stateBtnAdd)
            {
                AddEmptyRow(dgv, tableData);
                btnAddRow.Text = btnAddConfirmText;
                stateBtnAdd = true;
                return;
            }
            var success = ExtractDataFromDGV(dgv, out Dictionary<string, object> values, out Dictionary<string, Type> schema);
            if (!success)
            {
                MessageBox.Show("Ошибка: невозможно извлечь данные из таблицы.");
                return;
            }
            success = handler.Put(tableName, values, schema);
            if (!success)
            {
                MessageBox.Show("Ошибка: невозможно добавить новую запись.\n" +
                    "Проверьте заполнение ячеек и повторите операцию.");
                return;
            }
            MessageBox.Show("Инфо: запись успешно добавлена.\nТаблица сейчас обновится.");
            btnAddRow.Text = btnAddBaseText;
            stateBtnAdd = false;
            UpdateDataGrid(dgv, tableData, true);
        }

        private void SetInitialControlsProperties(string table, DataTable data, Handler handler)
        {
            this.handler = handler;
            btnAddRow.Text = btnAddBaseText;
            Text = $"Просмотр таблицы {table}";
            tableName = data.TableName;
        }

        private void UpdateDataGrid(DataGridView dgv, DataTable data, bool force = false)
        {
            if (force)
            {
                var found = handler.Scan(tableName, out DataTable items);
                if (!found)
                {
                    MessageBox.Show($"Предупреждение: записи в таблице {tableName} не найдены.");
                    return;
                }
                data = items;   
            }
            if (data != null)
            {
                tableData = data;
            }
            var bind = new BindingSource
            {
                DataSource = data,
            };
            dgv.DataSource = bind;
            dgv.Update();

            DisableDataGridSortMode(dgv);
        }

        private void SetDataGridColumnProperties(DataGridView dgv)
        {
            dgv.AutoResizeColumns();
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DisableDataGridSortMode(dgv);
        }

        private void DisableDataGridSortMode(DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void AddEmptyRow(DataGridView dgv, DataTable data)
        {
            var idx = 0;
            for (int jdx = dgv.RowCount - 1; jdx >= 0;)
            {
                var row = dgv.Rows[jdx].Cells;
                for (; idx < row.Count;)
                {
                    idx = Convert.ToInt32(row[idx].Value);
                    break;
                }
                break;
            }
            data.Rows.Add(idx + 1);
            dgv.Update();
        }

        private void SetReadonlyIdColumn(DataGridView dgv)
        {
            for (int idx = 0; idx < dgv.Columns.Count; )
            {
                dgv.Columns[idx].ReadOnly = true;
                break;
            }
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            var success = ExtractKeyFromDGV(dgv, tableData, out Dictionary<DataColumn, object> pk);
            if (!success)
            {
                MessageBox.Show("Ошибка: невозможно извлечь первичный ключ из таблицы для удаления записи.");
                return;
            }
            var res = MessageBox.Show("Внимание: подтвердите удаление строки.\n" +
                $"Таблица: {tableName}, идентификатор записи: {pk.First().Value}.", "", MessageBoxButtons.OKCancel);

            if (res == DialogResult.Cancel)
            {
                return;
            }
            success = handler.Delete(tableName, pk);
            if (!success)
            {
                MessageBox.Show("Ошибка: невозможно удалить запись.\n" +
                    "Операция не может быть выполнена.");
                return;
            }
            MessageBox.Show("Инфо: запись успешно удалена.\nТаблица сейчас обновится.");
            UpdateDataGrid(dgv, tableData, true);
        }

        private int GetSelectedCellIndex(DataGridView dgv)
        {
            var idx = -1;
            var currentCell = dgv.CurrentCell;
            if (currentCell != null)
            {
                idx = dgv.CurrentCell.RowIndex;
            }
            return idx;
        }

        private bool ExtractKeyFromDGV(DataGridView dgv, DataTable data, out Dictionary<DataColumn, object> pk)
        {
            pk = new Dictionary<DataColumn, object>();
            bool success = false;
            var idxSelected = GetSelectedCellIndex(dgv);
            if (idxSelected == -1)
            {
                return success;
            }
            DataGridViewCellCollection row = dgv.Rows[idxSelected].Cells;
            for (int idx = 0; idx < row.Count;)
            {
                var value = row[idx].Value;
                if (data.PrimaryKey.Length != 0)
                {
                    pk.Add(data.PrimaryKey[idx], value);
                }
                break;
            }
            if (pk.Count != 0) 
            {
                success = true;
            }
            return success;
        }

        private bool ExtractSchema(DataTable data, out Dictionary<string, Type> schema)
        {
            bool success = false;
            schema = new Dictionary<string, Type>();
            for (int idx = 0; idx < data.Columns.Count; idx++)
            {
                schema.Add(tableData.Columns[idx].ColumnName, tableData.Columns[idx].DataType);
            }
            if (schema.Count != 0)
            {
                success = true;
            }
            return success;
        }

        private bool ExtractDataFromDGV(DataGridView dgv, out Dictionary<string, object> values, out Dictionary<string, Type> schema, bool selectedRow = false)
        {
            values = new Dictionary<string, object>();
            schema = new Dictionary<string, Type>();
            bool success = false;
            DataGridViewCellCollection row = null;
            int idxRow = dgv.RowCount - 1;
            if (selectedRow)
            {
                var idxSelected = GetSelectedCellIndex(dgv);
                if (idxSelected == -1)
                {
                    return success;
                }
                idxRow = idxSelected;
            }
            for (int idx = idxRow; idx >= 0;)
            {
                row = dgv.Rows[idx].Cells;
                break;
            }
            if (row == null)
            {
                return success;
            }
            for (int idx = 1; idx < row.Count; idx++)
            {
                var column = tableData.Columns[idx].ColumnName;
                values.Add(column, row[idx].Value);
                schema.Add(column, tableData.Columns[idx].DataType);
            }
            success = true;
            return success;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateDataGrid(dgv, tableData, true);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var filter = tbSearch.Text.Trim();
            var success = ExtractSchema(tableData, out Dictionary<string, Type> schema);
            if (!success)
            {
                MessageBox.Show("Ошибка: невозможно найти записи.\n" +
                    "Не удалось извлечь схему таблицы для поиска.");
                return;
            }
            handler.Search(tableName, filter, schema, out DataTable foundData);
            UpdateDataGrid(dgv, foundData, false);
        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                string msg = "";
                Type type = null;
                if (tableData != null)
                {
                    type = tableData.Columns[e.ColumnIndex].DataType;
                    msg = $" Ожидался тип: {type}.";
                }
                MessageBox.Show("Ошибка: введено некорректное значение.\n" +
                    $"Cтрока: {e.RowIndex}, столбец: {e.ColumnIndex}.{msg}");
                return;
            }
            catch
            {
                MessageBox.Show("Ошибка: неверно интерпретировано значение.\n" +
                    $"Повторите ввод.");
                return;
            }
        }

        private void btnChangeRow_Click(object sender, EventArgs e)
        {
            var success = ExtractKeyFromDGV(dgv, tableData, out Dictionary<DataColumn, object> pk);
            if (!success)
            {
                MessageBox.Show("Ошибка: невозможно извлечь первичный ключ из таблицы для обновления.");
                return;
            }
            success = ExtractDataFromDGV(dgv, out Dictionary<string, object> values, out Dictionary<string, Type> schema, true);
            if (!success)
            {
                MessageBox.Show("Ошибка: невозможно извлечь данные из таблицы для обновления.");
                return;
            }
            success = handler.Update(tableName, pk, values, schema);
            if (!success)
            {
                MessageBox.Show("Ошибка: не удалось обновить запись.");
                return;
            }
            MessageBox.Show("Инфо: запись успешно обновлена.\nТаблица сейчас обновится.");
            UpdateDataGrid(dgv, tableData, true);
        }
    }
}
