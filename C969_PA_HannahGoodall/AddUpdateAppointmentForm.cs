using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_PA_HannahGoodall
{
    public partial class AddUpdateAppointmentForm : Form
    {
        private MySqlConnection _connection;
        private string _userId;
        private string _username;
        RecordsForm _parent;
        public AddUpdateAppointmentForm(MySqlConnection connection, RecordsForm parent, string userId, string username)
        {
            InitializeComponent();
            _connection = connection;
            _userId = userId;
            _username = username;
            _parent = parent;
            endTimePicker.Format = DateTimePickerFormat.Custom;
            endTimePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss tt";
            startTimePicker.Format = DateTimePickerFormat.Custom;
            startTimePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss tt";
        }
        private string createDate = DateTime.Now.ToString("yyyy-MM-dd");
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveApptButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
                string insertApptSqlString = $"INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdateBy) VALUES ('{customerIdTextBox.Text}', '{_userId}', '{string.Empty}', '{string.Empty}', '{string.Empty}', '{string.Empty}', '{typeTextBox.Text}', '{string.Empty}', '{startTimePicker.Text.Substring(0, startTimePicker.Text.Length - 3)}', '{endTimePicker.Text.Substring(0, endTimePicker.Text.Length - 3)}', '{createDate}', '{_username}', '{_username}');";
                MySqlCommand insertCmd = new MySqlCommand(insertApptSqlString, _connection);
                MySqlDataReader reader;
                reader = insertCmd.ExecuteReader();
                _connection.Close();
                _parent.InitializeAppointmentDataGrid();
                this.Close();
            }

        }
        private bool IsValidData()
        {
            bool valid = false;

            if (string.IsNullOrEmpty(typeTextBox.Text.Trim()))
            {
                typeToolTip.Active = true;
                typeToolTip.Show("Type is required.", typeTextBox);
                typeTextBox.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                typeTextBox.BackColor = Color.White;
                typeToolTip.Active = false;
                valid = true;
            }

            if (string.IsNullOrEmpty(customerIdTextBox.Text.Trim()))
            {
                custIdToolTip.Active = true;
                custIdToolTip.Show("Customer ID is required.", customerIdTextBox);
                customerIdTextBox.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                var exists = false;
                var custIdExistsSqlString = "SELECT customerId FROM customer";
                MySqlCommand cmd = new MySqlCommand(custIdExistsSqlString, _connection);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    if (row["customerId"].ToString() == customerIdTextBox.Text)
                    {
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    custIdToolTip.Active = true;
                    custIdToolTip.Show("Customer ID doesn't exist. Enter an existing Customer ID.", customerIdTextBox);
                    customerIdTextBox.BackColor = Color.Red;
                    valid = false;
                }
                else
                {
                    customerIdTextBox.BackColor = Color.White;
                    custIdToolTip.Active = false;
                    valid = true;
                }
            }
            var startTime = startTimePicker.Value.TimeOfDay;
            var startDate = startTimePicker.Value.DayOfWeek;
            var endTime = endTimePicker.Value.TimeOfDay;
            var endDate = endTimePicker.Value.DayOfWeek;
            if (startTime.Hours < 9 || startTime.Hours > 5)
            {
                var tooltip = new ToolTip();
                tooltip.ToolTipIcon = ToolTipIcon.Info;
                tooltip.IsBalloon = true;
                tooltip.ShowAlways = true;
                tooltip.SetToolTip(startTimePicker, "Appointments must be scheduled from 9AM - 5PM.");

                valid = false;
            }
            else
            {
                startToolTip.Active = false;
                startTimePicker.BackColor = Color.White;
                valid = false;
            }
            if (startDate == DayOfWeek.Sunday || startDate == DayOfWeek.Saturday)
            {
                startToolTip.Active = true;
                startToolTip.Show("Appointment must be Monday-Friday", startTimePicker);
                startTimePicker.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                startToolTip.Active = false;
                startTimePicker.BackColor = Color.White;
                valid = false;
            }
            if (endTime.Hours < 9 || endTime.Hours > 5)
            {
                endToolTip.Active = true;
                endToolTip.Show("Appointments must be scheduled from 9AM - 5PM.", endTimePicker);
                endTimePicker.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                endToolTip.Active = false;
                endTimePicker.BackColor = Color.White;
                valid = false;
            }
            if (endDate == DayOfWeek.Sunday || endDate == DayOfWeek.Saturday)
            {
                endToolTip.Active = true;
                endToolTip.Show("Appointment must be Monday-Friday", endTimePicker);
                endTimePicker.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                endToolTip.Active = false;
                endTimePicker.BackColor = Color.White;
                valid = false;
            }
            return valid;
        }

        private void typeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(typeTextBox.Text.Trim()))
            {
                typeToolTip.Active = true;
                typeToolTip.Show("Type is required.", typeTextBox);
                typeTextBox.BackColor = Color.Red;
            }
            else
            {
                typeTextBox.BackColor = Color.White;
                typeToolTip.Active = false;
            }
        }

        private void customerIdTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(customerIdTextBox.Text.Trim()))
            {
                custIdToolTip.Active = true;
                custIdToolTip.Show("Customer ID is required.", customerIdTextBox);
                customerIdTextBox.BackColor = Color.Red;
            }
            else
            {
                customerIdTextBox.BackColor = Color.White;
                custIdToolTip.Active = false;
            }

        }
    }
}
