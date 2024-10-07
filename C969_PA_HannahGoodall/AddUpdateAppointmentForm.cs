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
        private string _appointmentId;
        public AddUpdateAppointmentForm(MySqlConnection connection, RecordsForm parent, string userId, string username, string appointmentId = "")
        {
            InitializeComponent();
            _connection = connection;
            _userId = userId;
            _username = username;
            _parent = parent;
            _appointmentId = appointmentId;
            endTimePicker.Format = DateTimePickerFormat.Custom;
            endTimePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss tt";
            startTimePicker.Format = DateTimePickerFormat.Custom;
            startTimePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss tt";
            if (!string.IsNullOrEmpty(_appointmentId))
            {
                SetAppointment();
            }
        }
        private string createDate = DateTime.Now.ToString("yyyy-MM-dd");
        string existingType;
        string existingCustomerId;
        DateTime existingStart;
        DateTime existingEnd;
        private void SetAppointment()
        {
            try
            {
                string getApptSqlString = $"SELECT type, customerId, start, end FROM appointment WHERE appointmentId = {_appointmentId};";
                MySqlCommand apptCmd = new MySqlCommand(getApptSqlString, _connection);
                MySqlDataAdapter apptAdp = new MySqlDataAdapter(apptCmd);
                DataTable apptTable = new DataTable();
                apptAdp.Fill(apptTable);
                foreach (DataRow row in apptTable.Rows)
                {
                    existingType = row["type"].ToString();
                    typeTextBox.Text = existingType;
                    existingCustomerId = row["customerId"].ToString();
                    customerIdTextBox.Text = existingCustomerId;
                    existingStart = DateTime.Parse(row["start"].ToString());
                    startTimePicker.Value = existingStart;
                    existingEnd = DateTime.Parse(row["end"].ToString());
                    endTimePicker.Value = existingEnd;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveApptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData())
                {
                    if (string.IsNullOrEmpty(_appointmentId))
                    {
                        if (_connection.State == ConnectionState.Closed)
                        {
                            _connection.Open();
                        }
                        string insertApptSqlString = $"INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdateBy) VALUES ('{customerIdTextBox.Text}', '{_userId}', '{string.Empty}', '{string.Empty}', '{string.Empty}', '{string.Empty}', '{typeTextBox.Text}', '{string.Empty}', '{startTimePicker.Value.Date.ToString("yyyy-MM-dd")} {startTimePicker.Value.TimeOfDay.ToString()}', '{endTimePicker.Value.Date.ToString("yyyy-MM-dd")} {endTimePicker.Value.TimeOfDay.ToString()}', '{createDate}', '{_username}', '{_username}');";
                        MySqlCommand insertCmd = new MySqlCommand(insertApptSqlString, _connection);
                        MySqlDataReader reader;
                        reader = insertCmd.ExecuteReader();
                        _connection.Close();
                    }
                    else
                    {
                        if (_connection.State == ConnectionState.Closed)
                        {
                            _connection.Open();
                        }
                        bool changes = false;
                        string updateApptSqlString = $"UPDATE appointment SET ";

                        if (typeTextBox.Text != existingType)
                        {
                            updateApptSqlString += $"type = '{typeTextBox.Text}'";
                            changes = true;
                        }
                        if (customerIdTextBox.Text != existingCustomerId)
                        {
                            if (changes)
                            {
                                updateApptSqlString += ", ";
                            }
                            updateApptSqlString += $"customerId = '{customerIdTextBox.Text}'";
                            changes = true;
                        }
                        if (startTimePicker.Value != existingStart)
                        {
                            if (changes)
                            {
                                updateApptSqlString += ", ";
                            }
                            updateApptSqlString += $"start = '{startTimePicker.Value.Date.ToString("yyyy-MM-dd")} {startTimePicker.Value.TimeOfDay}'";
                            changes = true;
                        }
                        if (endTimePicker.Value != existingEnd)
                        {
                            if (changes)
                            {
                                updateApptSqlString += ", ";
                            }
                            updateApptSqlString += $"end = '{endTimePicker.Value.Date.ToString("yyyy-MM-dd")} {endTimePicker.Value.TimeOfDay}'";
                            changes = true;
                        }
                        if (changes)
                        {
                            updateApptSqlString += $" WHERE appointmentId = '{_appointmentId}'";
                            MySqlCommand updateCmd = new MySqlCommand(updateApptSqlString, _connection);
                            MySqlDataReader updateReader;
                            updateReader = updateCmd.ExecuteReader();
                            _connection.Close();
                        }
                    }
                    _parent.InitializeAppointmentDataGrid();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private bool IsValidData()
        {
            bool valid = false;
            try
            {
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
                //9-5 mon-fri appts
                var startTime = startTimePicker.Value.TimeOfDay;
                var startDate = startTimePicker.Value.DayOfWeek;
                var endTime = endTimePicker.Value.TimeOfDay;
                var endDate = endTimePicker.Value.DayOfWeek;
                if (startTime.Hours < 9 || startTime.Hours > 17)
                {
                    valid = false;
                    MessageBox.Show("Start time must be scheduled from 9AM - 5PM.");
                }
                if (startDate == DayOfWeek.Sunday || startDate == DayOfWeek.Saturday)
                {
                    valid = false;
                    MessageBox.Show("Start time must be Monday-Friday");
                }
                if (endTime.Hours < 9 || endTime.Hours > 17)
                {
                    valid = false;
                    MessageBox.Show("End time must be scheduled from 9AM - 5PM.");
                }
                if (endDate == DayOfWeek.Sunday || endDate == DayOfWeek.Saturday)
                {
                    valid = false;
                    MessageBox.Show("End time must be Monday-Friday");
                }
                if (endTime < startTime)
                {
                    valid = false;
                    MessageBox.Show("End time cannot be before start time.");
                }
                //overlapping appts
                string overlappingApptSqlString = $"SELECT appointmentId, customerId, start, end FROM appointment WHERE customerId = {customerIdTextBox.Text};";
                MySqlCommand overlapCmd = new MySqlCommand(overlappingApptSqlString, _connection);
                MySqlDataAdapter overlapAdp = new MySqlDataAdapter(overlapCmd);
                DataTable table = new DataTable();
                overlapAdp.Fill(table);
                if (DateTime.Parse(startTimePicker.Text).Date != DateTime.Parse(endTimePicker.Text).Date)
                {
                    MessageBox.Show("Appointment start and end time must be on the same day.");
                }
                else
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        if (DateTime.Parse(dr["start"].ToString()).Date == startTimePicker.Value.Date && DateTime.Parse(dr["end"].ToString()).Date == endTimePicker.Value.Date && dr["customerId"].ToString() == customerIdTextBox.Text)
                        {
                            if (dr["appointmentId"].ToString() != _appointmentId)
                            {
                                if (endTime <= DateTime.Parse(dr["end"].ToString()).TimeOfDay && endTime >= DateTime.Parse(dr["start"].ToString()).TimeOfDay ||
                                    startTime <= DateTime.Parse(dr["end"].ToString()).TimeOfDay && startTime >= DateTime.Parse(dr["start"].ToString()).TimeOfDay ||
                                    DateTime.Parse(dr["end"].ToString()).TimeOfDay <= endTime && DateTime.Parse(dr["end"].ToString()).TimeOfDay >= startTime)
                                {
                                    valid = false;
                                    MessageBox.Show("Appointment cannot overlap with an existing appointment.");
                                }
                            }
                        }
                    }
                }

                return valid;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
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
