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
    public partial class Report : Form
    {
        private string reportName;
        private Handler handler;

        public Report(string report, Handler handler)
        {
            InitializeComponent();

            this.handler = handler;
            reportName = report;

            SetDataGridProperties(dgv);

            PrepareControls(report);
            PrepareReportDescription(report);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetDataGridProperties(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AutoResizeColumns();
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DisableDataGridSortMode(dgv);
        }

        private void DisableDataGridSortMode(DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void FormReport(string report)
        {
            switch (report)
            {
                case "empty_room_by_building":
                case "empty_room_by_location":
                case "empty_room_by_building_by_location":
                case "booked_room_by_location":
                case "booked_room_by_building":
                case "booked_room_by_building_by_location":

                    var date = dtDate.Value.Date;
                    if (date == null)
                    {
                        MessageBox.Show("Ошибка: значение даты не должно быть пустым.");
                        return;
                    }
                    var success = handler.EmptyOrBookedRoomReport(report, date, out DataTable data);
                    NotifyReportStatus(success);
                    SetDataToDataGrid(dgv, data);
                    break;

                case "booking_by_organization":

                    success = handler.BookingByOrganization(report, out data);
                    NotifyReportStatus(success);
                    SetDataToDataGrid(dgv, data);
                    break;

                case "organization_information":
                case "new_clients_by_dates":

                    var stayDate = dtStartDate.Value.Date;
                    var outDate = dtEndDate.Value.Date;
                    if (stayDate == null || outDate == null)
                    {
                        MessageBox.Show("Ошибка: значение даты не должно быть пустым.");
                        return;
                    }
                    success = handler.ClientsOrOrganizationInfoOrBooking(report, stayDate, outDate, out data);
                    NotifyReportStatus(success);
                    SetDataToDataGrid(dgv, data);
                    break;

                case "change_booking_order_cost":

                    var category = cbCategory.Text.Trim();
                    var cost = tbCost.Text.Trim();
                    if (category == "" || cost == "")
                    {
                        MessageBox.Show("Ошибка: необходимо задать стоимость и выбрать категорию.");
                        return;
                    }
                    success = handler.ChangeBookingOrderCost(report, category, cost);
                    NotifyCostChange(success);
                    break;

                case "client_information":

                    var room = tbRoomId.Text.Trim();
                    if (room == "")
                    {
                        MessageBox.Show("Ошибка: необходимо задать номер комнаты.");
                        return;
                    }
                    success = handler.ClientInformationByRoom(report, room, out data);
                    NotifyReportStatus(success);
                    SetDataToDataGrid(dgv, data);
                    break;

                case "orders_history_by_client":

                    var name = tbClientName.Text.Trim();
                    var surname = tbClientSurname.Text.Trim();
                    var client = $"{surname} {name}".Trim();
                    if (client == "")
                    {
                        MessageBox.Show("Ошибка: имя клиента не должно быть пустым.");
                        return;
                    }
                    success = handler.OrderHistoryByClient(report, client, out data);
                    NotifyReportStatus(success);
                    SetDataToDataGrid(dgv, data);
                    break;
            }
        }

        private void SetDataToDataGrid(DataGridView dgv, DataTable data)
        {
            if (data != null)
            {
                var bind = new BindingSource
                {
                    DataSource = data,
                };
                dgv.DataSource = bind;
                dgv.Update();

                DisableDataGridSortMode(dgv);
            }
        }

        private void NotifyCostChange(bool success)
        {
            if (!success)
            {
                MessageBox.Show("Не удалось изменить стоимость.");
                return;
            }
            var found = handler.GetRoomLocations(out DataTable data);
            if (!found)
            {
                MessageBox.Show("Не удалось получить обновленные данные таблицы.");
                return;
            }
            MessageBox.Show("Стоимость успешно изменена.\nТаблица сейчас обновится.");
            SetDataToDataGrid(dgv, data);
        }

        private void NotifyReportStatus(bool success)
        {
            if (!success)
            {
                MessageBox.Show("Нет подходящих записей для заданных параметров.\nПустой отчет.");
                return;
            }
            MessageBox.Show("Отчет успешно сформирован.\nТаблица обновляется.");
        }

        private void PrepareReportDescription(string report)
        {
            var description = "";
            switch (report)
            {
                case "empty_room_by_building":
                    description = "учет свободных номеров по каждому корпусу отеля";
                    break;

                case "empty_room_by_location":
                    description = "учет свободных номеров по каждой категории номеров в отеле";
                    break;

                case "empty_room_by_building_by_location":
                    description = "учет свободных номеров по каждому корпусу и категории";
                    break;

                case "booked_room_by_building":
                    description = "учет бронирования номеров по каждому корпусу отеля";
                    break;

                case "booked_room_by_location":
                    description = "учет бронирования номеров по каждой категории номеров в отеле";
                    break;

                case "booked_room_by_building_by_location":
                    description = "учет бронирования номеров по корпусу и категории";
                    break;

                case "booking_by_organization":
                    description = "учет договоров с организациями на бронирование";
                    break;

                case "change_booking_order_cost":
                    description = "изменить стоимость номеров указанной категории";
                    break;

                case "client_information":
                    description = "получить сведения о постояльце из заданного номера: " +
                        "его счет гостинице за дополнительные услуги, виды дополнительных услуг, которыми он пользовался";
                    break;

                case "organization_information":
                    description = "получить сведения о фирмах, с которыми заключены договора о брони на указанный период";
                    break;

                case "new_clients_by_dates":
                    description = "получить сведения о новых клиентах за указанный период";
                    break;

                case "orders_history_by_client":
                    description = "получить сведения о конкретном человеке, " +
                        "сколько раз он посещал гостиницу, в каких номерах и в какой период останавливался, какие счета оплачивал";
                    break;
            }
            description = "Описание отчета: " + description;
            tbReportDesription.Text = description;
        }

        private void PrepareControls(string report)
        {
            Text = $"Просмотр отчета {report}";

            var customFormat = DateTimePickerFormat.Custom;
            var dateFormat = "dd-MM-yyyy";

            dtDate.Format = customFormat;
            dtDate.CustomFormat = dateFormat;

            dtStartDate.Format = customFormat;
            dtStartDate.CustomFormat = dateFormat;

            dtEndDate.Format = customFormat;
            dtEndDate.CustomFormat = dateFormat;

            switch (report)
            {
                case "empty_room_by_building":
                case "empty_room_by_location":
                case "empty_room_by_building_by_location":
                case "booked_room_by_location":
                case "booked_room_by_building":
                case "booked_room_by_building_by_location":
                    dtDate.Enabled = true;
                    tbClientName.Enabled = false;
                    tbClientSurname.Enabled = false;
                    tbRoomId.Enabled = false;
                    dtStartDate.Enabled = false;
                    dtEndDate.Enabled = false;
                    tbCost.Enabled = false;
                    cbCategory.Enabled = false;
                    break;

                case "organization_information":
                case "new_clients_by_dates":
                    dtStartDate.Enabled = true;
                    dtEndDate.Enabled = true;
                    dtDate.Enabled = false;
                    tbClientName.Enabled = false;
                    tbClientSurname.Enabled = false;
                    tbRoomId.Enabled = false;
                    tbCost.Enabled = false;
                    cbCategory.Enabled = false;
                    break;

                case "change_booking_order_cost":
                    tbCost.Enabled = true;
                    cbCategory.Enabled = true;
                    dtStartDate.Enabled = false;
                    dtEndDate.Enabled = false;
                    dtDate.Enabled = false;
                    tbClientName.Enabled = false;
                    tbClientSurname.Enabled = false;
                    tbRoomId.Enabled = false;

                    var found = handler.GetRoomLocationsNames(out object[] locations);
                    if (!found)
                    {
                        MessageBox.Show("Предупреждение: категории номеров не найдены.");
                    }
                    cbCategory.Items.AddRange(locations);

                    break;

                case "client_information":
                    tbRoomId.Enabled = true;
                    dtDate.Enabled = false;
                    tbClientName.Enabled = false;
                    tbClientSurname.Enabled = false;
                    dtStartDate.Enabled = false;
                    dtEndDate.Enabled = false;
                    tbCost.Enabled = false;
                    cbCategory.Enabled = false;
                    break;

                case "orders_history_by_client":
                    tbClientName.Enabled = true;
                    tbClientSurname.Enabled = true;
                    tbCost.Enabled = false;
                    cbCategory.Enabled = false;
                    dtStartDate.Enabled = false;
                    dtEndDate.Enabled = false;
                    dtDate.Enabled = false;
                    tbRoomId.Enabled = false;
                    break;

                case "booking_by_organization":
                default:
                    tbCost.Enabled = false;
                    cbCategory.Enabled = false;
                    dtStartDate.Enabled = false;
                    dtEndDate.Enabled = false;
                    dtDate.Enabled = false;
                    tbClientName.Enabled = false;
                    tbClientSurname.Enabled = false;
                    tbRoomId.Enabled = false;
                    break;
            }
        }

        private void cbCategory_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            FormReport(reportName);
        }
    }
}
