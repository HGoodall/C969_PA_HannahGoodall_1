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
        public AddUpdateAppointmentForm(MySqlConnection connection)
        {
            InitializeComponent();
            _connection = connection;
            endTimePicker.ShowUpDown = true;
            endTimePicker.CustomFormat = "hh:mm";
            endTimePicker.Format = DateTimePickerFormat.Custom;
            startTimePicker.ShowUpDown = true;
            startTimePicker.CustomFormat = "hh:mm";
            startTimePicker.Format = DateTimePickerFormat.Custom;
        }

        private void AddUpdateAppointmentForm_Load(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveApptButton_Click(object sender, EventArgs e)
        {

        }
    }
}
