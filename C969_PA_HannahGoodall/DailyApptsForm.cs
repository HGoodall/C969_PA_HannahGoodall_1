using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_PA_HannahGoodall
{
    public partial class DailyApptsForm : Form
    {
        private MySqlConnection _connection;
        private DateTimePicker _apptDate;
        public DailyApptsForm(MySqlConnection connection, DateTimePicker apptDate)
        {
            InitializeComponent();
            _apptDate = apptDate;
            _connection = connection;
            InitializeDataGrid();
        }
        private void InitializeDataGrid()
        {
            var parsedDate = _apptDate.Value.Date.ToString("yyyy-MM-dd");
            apptDateLabel.Text += parsedDate;
            string sqlString = $"SELECT type, customer.customerName, CONCAT(cast(start as time), ' - ', cast(end as time)) AS scheduleTime FROM appointment, customer WHERE appointment.customerId = customer.customerId AND cast(start as date) = '{parsedDate}';";
            MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            ApptsDataGrid.DataSource = dt;
        }
    }
}
