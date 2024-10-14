using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace C969_PA_HannahGoodall
{
    public partial class DailyApptsForm : Form
    {
        private MySqlConnection _connection;
        private DateTimePicker _apptDate;
        public DailyApptsForm(MySqlConnection connection, DateTimePicker apptDate, bool monthly)
        {
            InitializeComponent();
            _apptDate = apptDate;
            _connection = connection;
            if (!monthly)
            {
                InitializeDailyDataGrid();
            }
            else
            {
                InitializeMonthlyDataGrid();
            }
        }
        private void InitializeDailyDataGrid()
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
        private void InitializeMonthlyDataGrid()
        {
            var month = _apptDate.Value.Month;
            var year = _apptDate.Value.Year;
            apptDateLabel.Text += $"{month}/{year}";
            string sqlString = $"SELECT type, customer.customerName, CONCAT(cast(start as time), ' - ', cast(end as time)) AS scheduleTime FROM appointment, customer WHERE appointment.customerId = customer.customerId AND EXTRACT(MONTH FROM start) = {month} AND EXTRACT(YEAR FROM start) = {year};";
            MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            ApptsDataGrid.DataSource = dt;
        }
    }
}
