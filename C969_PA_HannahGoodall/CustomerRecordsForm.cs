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

            InitializeDataGrid();

        }
        public void InitializeDataGrid()
        {
            string sqlString = "use client_schedule; SELECT customerName, address, phone FROM customer, address WHERE customer.addressId = address.addressId;";
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
            var addCustomerForm = new addUpdateCustomerForm(_connection, _user, this);
            addCustomerForm.Text = "Add Customer";
            addCustomerForm.ShowDialog();
        }

        private void updateCustomerButton_Click(object sender, EventArgs e)
        {
            if (customerDataGrid.SelectedRows.Count > 0)
            {
                string customerId = "";
                for(int i = 0; i < customerDataGrid.SelectedRows.Count; i++)
                {
                    string name = customerDataGrid.SelectedRows[i].Cells[0].Value.ToString();

                    //find customerID
                    string sqlString = $"SELECT customerId FROM customer WHERE customerName = '{name}'";
                    MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    for(int j = 0; j < dt.Rows.Count; j++)
                    {
                        customerId = dt.Rows[j]["customerId"].ToString();
                    }
                }
                var addCustomerForm = new addUpdateCustomerForm(_connection, _user, this, customerId);
                addCustomerForm.Text = "Update Customer";
                addCustomerForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Must select a customer to update.");
            }
        }
    }
}
