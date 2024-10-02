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
        public AddUpdateAppointmentForm(MySqlConnection connection, string userId, string username)
        {
            InitializeComponent();
            _connection = connection;
            _userId = userId;
            _username = username;
            endTimePicker.Format = DateTimePickerFormat.Custom;
            endTimePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            startTimePicker.Format = DateTimePickerFormat.Custom;
            startTimePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss";
        }
        private string createDate = DateTime.Now.ToString("yyyy-MM-dd");
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveApptButton_Click(object sender, EventArgs e)
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            string insertApptSqlString = $"INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdateBy) VALUES ('{customerIdTextBox.Text}', '{_userId}', '{string.Empty}', '{string.Empty}', '{string.Empty}', '{string.Empty}', '{typeTextBox.Text}', '{string.Empty}', '{startTimePicker.Text}', '{endTimePicker.Text}', '{createDate}', '{_username}', '{_username}');";
            MySqlCommand insertCmd = new MySqlCommand(insertApptSqlString, _connection);
            MySqlDataReader reader;
            reader = insertCmd.ExecuteReader();
            _connection.Close();
        }
    }
}
