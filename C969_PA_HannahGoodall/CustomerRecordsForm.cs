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
        public CustomerRecordsForm(MySqlConnection connection)
        {
            InitializeComponent();
            _connection = connection;

            utcCustomerDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            utcCustomerDataGrid.DefaultCellStyle.SelectionBackColor = utcCustomerDataGrid.DefaultCellStyle.BackColor;
            utcCustomerDataGrid.DefaultCellStyle.SelectionForeColor = utcCustomerDataGrid.DefaultCellStyle.ForeColor;

            utcCustomerDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            utcCustomerDataGrid.DefaultCellStyle.SelectionBackColor = utcCustomerDataGrid.DefaultCellStyle.BackColor;
            utcCustomerDataGrid.DefaultCellStyle.SelectionForeColor = utcCustomerDataGrid.DefaultCellStyle.ForeColor;

            string sqlString = "use client_schedule; SELECT customerName, address, phone FROM customer, address WHERE customer.addressId = address.addressId;";
            MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            utcCustomerDataGrid.DataSource = dt;

            // Set your desired AutoSize Mode:
            utcCustomerDataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            utcCustomerDataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            utcCustomerDataGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Now that DataGridView has calculated it's Widths; we can now store each column Width values.
            for (int i = 0; i <= utcCustomerDataGrid.Columns.Count - 1; i++)
            {
                // Store Auto Sized Widths:
                int colw = utcCustomerDataGrid.Columns[i].Width;

                // Remove AutoSizing:
                utcCustomerDataGrid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                // Set Width to calculated AutoSize value:
                utcCustomerDataGrid.Columns[i].Width = colw;
            }
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
            var addCustomerForm = new addUpdateCustomerForm(_connection, true);
            addCustomerForm.Text = "Add Customer";
            addCustomerForm.ShowDialog();
        }
    }
}
