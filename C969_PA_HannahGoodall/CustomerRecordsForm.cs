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
    public partial class CustomerRecordsForm : Form
    {
        private MySqlConnection _connection;
        private string _user;
        public CustomerRecordsForm(MySqlConnection connection, string user)
        {
            InitializeComponent();
            _connection = connection;
            _user = user;

            utcCustomerDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            utcCustomerDataGrid.DefaultCellStyle.SelectionBackColor = utcCustomerDataGrid.DefaultCellStyle.BackColor;
            utcCustomerDataGrid.DefaultCellStyle.SelectionForeColor = utcCustomerDataGrid.DefaultCellStyle.ForeColor;

            utcCustomerDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            utcCustomerDataGrid.DefaultCellStyle.SelectionBackColor = utcCustomerDataGrid.DefaultCellStyle.BackColor;
            utcCustomerDataGrid.DefaultCellStyle.SelectionForeColor = utcCustomerDataGrid.DefaultCellStyle.ForeColor;

            InitializeDataGrid();

        }
        public void InitializeDataGrid()
        {
            string sqlString = "use client_schedule; SELECT customerName, address, phone FROM customer, address WHERE customer.addressId = address.addressId;";
            MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            utcCustomerDataGrid.DataSource = dt;
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
            var addCustomerForm = new addUpdateCustomerForm(_connection, true, _user, this);
            addCustomerForm.Text = "Add Customer";
            addCustomerForm.ShowDialog();
        }
    }
}
