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
    public partial class addUpdateCustomerForm : Form
    {
        private MySqlConnection _connection;
        public addUpdateCustomerForm(MySqlConnection connection,bool newCustomer, string name = "", string address = "", string phone = "")
        {
            InitializeComponent();
            _connection = connection;
            if (newCustomer)
            {
            }
            else
            {
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveCusButton_Click(object sender, EventArgs e)
        {
            //add it to the DB
            string sqlString = "INSERT INTO customer";
        }

    }
}
