using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace C969_PA_HannahGoodall
{
    public partial class RecordsForm : Form
    {
        private MySqlConnection _connection;
        private string _user;
        private string _userId;
        public RecordsForm(MySqlConnection connection, string user, string userId)
        {
            InitializeComponent();
            _connection = connection;
            _user = user;
            _userId = userId;

            InitializeCustomerDataGrid();
            InitializeAppointmentDataGrid();

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

        private void CustomerRecordsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
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
            catch(Exception ex)
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
    }
}
