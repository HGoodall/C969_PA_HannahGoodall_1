using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace C969_PA_HannahGoodall
{
    public partial class RecordsForm : Form
    {
        private MySqlConnection _connection;
        private string _user;
        private string _userId;
        private DateTime _loginTime;
        public RecordsForm(MySqlConnection connection, string user, string userId, DateTime loginTime)
        {
            InitializeComponent();
            _connection = connection;
            _user = user;
            _userId = userId;
            _loginTime = loginTime;
            UpcomingAppointment();
            InitializeCustomerDataGrid();
            InitializeAppointmentDataGrid();

        }
        private void UpcomingAppointment()
        {
            string sqlString = "SELECT userId, start FROM appointment;";
            MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["userId"].ToString() == _userId)
                {
                    var dbTime = DateTime.Parse(dr["start"].ToString()).TimeOfDay;
                    var timeNow = DateTime.Now.TimeOfDay;
                    if (DateTime.Parse(dr["start"].ToString()).Date == DateTime.Now.Date)
                    {
                        var diff = dbTime.Subtract(timeNow);
                        if (diff.TotalMinutes <= 15)
                        {
                            MessageBox.Show("You have an upcoming appointment in 15 minutes or less!");
                        }
                    }
                }
            }

        }
        public void InitializeAppointmentDataGrid()
        {
            string sqlString = "use client_schedule; SELECT type, customer.customerName, cast(start as date) AS scheduleDate,  CONCAT(cast(start as time), ' - ', cast(end as time)) AS scheduleTime FROM appointment, customer WHERE appointment.customerId = customer.customerId;";
            MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            appointmentDataGrid.DataSource = dt;
        }
        private void InitializeAppointmentLocalDataGrid()
        {
            string sqlString = "SELECT type, customer.customerName, cast(start as date) AS scheduleDate,  CONCAT(cast(start as time), ' - ', cast(end as time)) AS scheduleTime FROM appointment, customer WHERE appointment.customerId = customer.customerId;";
            MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                DateTime convertedStartTime = DateTime.SpecifyKind(
                        DateTime.Parse(dr["scheduleTime"].ToString().Split('-')[0]),
                        DateTimeKind.Utc);
                DateTime convertedEndTime = DateTime.SpecifyKind(
                        DateTime.Parse(dr["scheduleTime"].ToString().Split('-')[1]),
                        DateTimeKind.Utc);
                var startDt = convertedStartTime.ToLocalTime().ToString("hh:mm tt");
                var endDt = convertedEndTime.ToLocalTime().ToString("hh:mm tt");
                dr["scheduleTime"] = $"{startDt} - {endDt}";
            }

            appointmentDataGrid.DataSource = dt;
        }
        public void InitializeCustomerDataGrid()
        {
            string sqlString = "use client_schedule; SELECT customerId, customerName, address, phone FROM customer, address WHERE customer.addressId = address.addressId;";
            MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            customerDataGrid.DataSource = dt;
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void CustomerRecordsForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            File.AppendAllText("Login_History.txt", $"{_user} logged in at {_loginTime}\n");
            Application.Exit();
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            var addCustomerForm = new AddUpdateCustomerForm(_connection, _user, this);
            addCustomerForm.Text = "Add Customer";
            addCustomerForm.ShowDialog();
        }

        private void updateCustomerButton_Click(object sender, EventArgs e)
        {
            if (customerDataGrid.SelectedRows.Count > 0)
            {
                string customerId = GetSelectedCustomerId();
                var addCustomerForm = new AddUpdateCustomerForm(_connection, _user, this, customerId);
                addCustomerForm.Text = "Update Customer";
                addCustomerForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Must select a customer to update.");
            }
        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
            if (customerDataGrid.SelectedRows.Count > 0)
            {
                var confirmation = MessageBox.Show("Are you sure you would like to delete this customer?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (confirmation == DialogResult.Yes)
                {
                    string customerId = GetSelectedCustomerId();
                    if (_connection.State != ConnectionState.Open)
                    {
                        _connection.Open();
                    }
                    string deleteCustomerSqlString = $"DELETE FROM customer WHERE customerId = '{customerId}';";
                    MySqlCommand cmd = new MySqlCommand(deleteCustomerSqlString, _connection);
                    MySqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    _connection.Close();
                    InitializeCustomerDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Must select a customer to delete.");
            }
        }

        private string GetSelectedCustomerId(bool appt = false)
        {
            try
            {
                string customerId = "";
                for (int i = 0; i < customerDataGrid.SelectedRows.Count; i++)
                {
                    string name = "";
                    if (!appt)
                    {
                        name = customerDataGrid.SelectedRows[i].Cells[1].Value.ToString();
                    }
                    else
                    {
                        name = appointmentDataGrid.SelectedRows[i].Cells[1].Value.ToString();
                    }

                    //find customerID
                    string sqlString = $"SELECT customerId FROM customer WHERE customerName = '{name}';";
                    MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        customerId = dt.Rows[j]["customerId"].ToString();
                    }
                }
                return customerId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private string GetSelectedAppointmentId()
        {
            try
            {
                string appointmentId = "";
                for (int i = 0; i < appointmentDataGrid.SelectedRows.Count; i++)
                {
                    string customerId = GetSelectedCustomerId(true);
                    string scheduleTime = $"{DateTime.Parse(appointmentDataGrid.SelectedRows[i].Cells[2].Value.ToString()).Date.ToString("yyyy-MM-dd")} {appointmentDataGrid.SelectedRows[i].Cells[3].Value.ToString().Split('-')[0]}";

                    //find appointmentID
                    string sqlString = $"SELECT appointmentId FROM appointment WHERE customerId = '{customerId}' AND start = '{scheduleTime}';";
                    MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        appointmentId = dt.Rows[j]["appointmentId"].ToString();
                    }
                }
                return appointmentId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void deleteApptButton_Click(object sender, EventArgs e)
        {
            if (appointmentDataGrid.SelectedRows.Count > 0)
            {
                var confirmation = MessageBox.Show("Are you sure you would like to delete this appointment?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (confirmation == DialogResult.Yes)
                {
                    if (_connection.State != ConnectionState.Open)
                    {
                        _connection.Open();
                    }
                    var appointmentId = GetSelectedAppointmentId();
                    string deleteApptSqlString = $"DELETE FROM appointment WHERE appointmentId = '{appointmentId}';";
                    MySqlCommand cmd = new MySqlCommand(deleteApptSqlString, _connection);
                    MySqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    _connection.Close();
                    if (localApptsRadio.Checked)
                    {
                        InitializeAppointmentLocalDataGrid();
                    }
                    else
                    {
                        InitializeAppointmentDataGrid();
                    }
                }
            }
            else
            {
                MessageBox.Show("Must select an appointment to delete.");
            }
        }

        private void updateApptButton_Click(object sender, EventArgs e)
        {
            if (appointmentDataGrid.SelectedRows.Count > 0)
            {
                string appointmentId = GetSelectedAppointmentId();
                var form = new AddUpdateAppointmentForm(_connection, this, _userId, _user, appointmentId);
                form.Text = "Update Appointment";
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Must select an appointment to update.");
            }
        }

        private void addApptButton_Click(object sender, EventArgs e)
        {
            var form = new AddUpdateAppointmentForm(_connection, this, _userId, _user);
            form.Text = "Add Appointment";
            form.ShowDialog();
        }

        private void ApptByDayPicker_ValueChanged(object sender, EventArgs e)
        {
            var dailyApptsForm = new DailyApptsForm(_connection, ApptByDayPicker);
            dailyApptsForm.ShowDialog();
        }

        private void localApptsRadio_CheckedChanged(object sender, EventArgs e)
        {

            if (localApptsRadio.Checked)
            {
                InitializeAppointmentLocalDataGrid();
            }

        }

        private void utcApptsRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (utcApptsRadio.Checked)
            {
                InitializeAppointmentDataGrid();
            }
        }

        private void apptTypeReportButton_Click(object sender, EventArgs e)
        {
            string sqlString = $"SELECT type, start FROM appointment;";
            MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            var collection = dt.Rows.Cast<DataRow>().ToList();
            var dates = collection.Select(r => r["start"].ToString()).ToList();

            string report = "";
            for (int i = 1; i < 13; i++)
            {
                var count = collection.Where(row => DateTime.Parse(row["start"].ToString()).Month == i).Select(row => row["type"].ToString()).Distinct().ToList().Count;
                report += $"There are {count} types of appointments in month {i}.\n";
            }
            var form = new GeneratedReportForm(_connection, report);
            form.ShowDialog();
        }

        private void userScheduleButton_Click(object sender, EventArgs e)
        {
            string sqlString = $"SELECT COUNT(userId) AS count FROM appointment WHERE userId = '{userIdScheduleTextBox.Text}'";
            MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (!string.IsNullOrEmpty(userIdScheduleTextBox.Text))
            {

                if (Convert.ToInt32(dt.Rows[0]["count"].ToString()) > 0)
                {
                    var form = new GeneratedReportForm(_connection, "", userIdScheduleTextBox.Text);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("User ID does not have any appointments.");
                }
            }
            else
            {
                MessageBox.Show("Must enter a User ID to view schedule.");
            }
        }

        private void customerAppointmentsButton_Click(object sender, EventArgs e)
        {
            string sqlString = $"SELECT customerId FROM appointment;";
            MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            var customerIds = dt.Rows.Cast<DataRow>().ToList();
            var groups = customerIds.GroupBy(row => row["customerId"].ToString()).ToList();
            int count = 0;
            string report = "";

            foreach (var grp in groups)
            {
                count = grp.Count();
                report += $"Customer ID: {grp.Key} has {count} appointment(s).\n";
            }

            var form = new GeneratedReportForm(_connection, report);
            form.ShowDialog();
        }
    }
}
