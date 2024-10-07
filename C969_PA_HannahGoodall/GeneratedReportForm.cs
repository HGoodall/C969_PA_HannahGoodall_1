using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_PA_HannahGoodall
{
    public partial class GeneratedReportForm : Form
    {
        private MySqlConnection _connection;
        public GeneratedReportForm(MySqlConnection connection, string typeReport = "", string userId = "")
        {
            InitializeComponent();
            _connection = connection;
            if (!string.IsNullOrEmpty(typeReport))
            {
                userScheduleDataGrid.Visible = false;
                typePerMonthReportLabel.Text = typeReport;
            }
            if (!string.IsNullOrEmpty(userId))
            {
                string sqlString = $"SELECT type, customerId, cast(start as date) AS scheduleDate,  CONCAT(cast(start as time), ' - ', cast(end as time)) AS scheduleTime FROM appointment WHERE userId = '{userId}';";
                MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                userScheduleDataGrid.DataSource = dt;
            }
        }
    }
}
