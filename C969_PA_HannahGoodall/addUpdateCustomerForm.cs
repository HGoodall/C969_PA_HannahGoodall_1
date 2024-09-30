using Google.Protobuf.Collections;
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
        private string _user;
        private CustomerRecordsForm parent;
        public addUpdateCustomerForm(MySqlConnection connection, bool newCustomer, string user, CustomerRecordsForm form, string name = "", string address = "", string phone = "")
        {
            InitializeComponent();
            _connection = connection;
            _user = user;
            parent = form;
            if (!newCustomer)
            {
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string GetCountryId()
        {
            string selectAllCountries = "use client_schedule; SELECT * FROM country;";
            MySqlCommand countryCmd = new MySqlCommand(selectAllCountries, _connection);
            MySqlDataAdapter adp = new MySqlDataAdapter(countryCmd);
            DataTable countryDt = new DataTable();
            adp.Fill(countryDt);
            string countryId = "";
            for (int i = 0; i < countryDt.Rows.Count; i++)
            {
                if (countryDt.Rows[i]["country"].ToString() == countryTextbox.Text)
                {
                    countryId = countryDt.Rows[i]["countryId"].ToString();
                    break;
                }
            }
            return countryId;
        }
        private string GetCityId()
        {
            string selectAllCities = "use client_schedule; SELECT * FROM city;";
            MySqlCommand cityCmd = new MySqlCommand(selectAllCities, _connection);
            MySqlDataAdapter cityAdp = new MySqlDataAdapter(cityCmd);
            DataTable cityDt = new DataTable();
            cityAdp.Fill(cityDt);
            string cityId = "";
            for (int i = 0; i < cityDt.Rows.Count; i++)
            {
                if (cityDt.Rows[i]["city"].ToString() == cityTextbox.Text)
                {
                    cityId = cityDt.Rows[i]["cityId"].ToString();
                    break;
                }
            }
            return cityId;
        }
        private string GetAddressId()
        {
            string selectAllAddresses = "SELECT * FROM address;";
            MySqlCommand addressCmd = new MySqlCommand(selectAllAddresses, _connection);
            MySqlDataAdapter addressAdp = new MySqlDataAdapter(addressCmd);
            DataTable addressDt = new DataTable();
            addressAdp.Fill(addressDt);
            string addressId = "";
            for (int i = 0; i < addressDt.Rows.Count; i++)
            {
                if (addressDt.Rows[i]["address"].ToString() == addressTextbox.Text)
                {
                    addressId = addressDt.Rows[i]["addressId"].ToString();
                    break;
                }
            }
            return addressId;
        }
        private void saveCusButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                //insert customer to the DB
                var createDate = DateTime.Now.ToString("yyyy-MM-dd");

                //insert country
                string countryId = GetCountryId();
                _connection.Close();
                if (string.IsNullOrEmpty(countryId))
                {
                    try
                    {
                        if (_connection.State == ConnectionState.Open)
                        {
                            _connection.Close();
                        }
                        else
                        {
                            _connection.Open();
                        }
                        string countryInsertSqlString = $"INSERT INTO country (country, createDate, createdBy, lastUpdateBy) VALUES ('{countryTextbox.Text}', '{createDate}', '{_user}', '{_user}');";
                        MySqlCommand countryInsertCmd = new MySqlCommand(countryInsertSqlString, _connection);
                        MySqlDataReader reader;
                        reader = countryInsertCmd.ExecuteReader();
                        countryId = GetCountryId();
                        _connection.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }

                //insert city
                string cityId = GetCityId();
                if (string.IsNullOrEmpty(cityId))
                {
                    try
                    {
                        if (_connection.State != ConnectionState.Open)
                        {
                            _connection.Open();
                        }
                        string cityInsertSqlString = $"INSERT INTO city (city, countryId, createDate, createdBy, lastUpdateBy) VALUES ('{cityTextbox.Text}', '{countryId}', '{createDate}', '{_user}', '{_user}');";
                        MySqlCommand cityInsertCmd = new MySqlCommand(cityInsertSqlString, _connection);
                        MySqlDataReader cityReader;
                        cityReader = cityInsertCmd.ExecuteReader();
                        _connection.Close();
                        cityId = GetCityId();
                        _connection.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }

                //insert address
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                string addressInsertSqlString = $"use client_schedule; INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdateBy) VALUES ('{addressTextbox.Text}', '{string.Empty}', '{cityId}', '{string.Empty}', '{phoneTextbox.Text}', '{createDate}', '{_user}', '{_user}');";
                MySqlCommand addressInsertCmd = new MySqlCommand(addressInsertSqlString, _connection);
                MySqlDataReader addressReader;
                addressReader = addressInsertCmd.ExecuteReader();
                _connection.Close();
                string addressId = GetAddressId();
                _connection.Close();

                //insert customer
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                string customerInsertSqlString = $"use client_schedule; INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdateBy) VALUES ('{nameTextbox.Text}', '{addressId}', '{1}', '{createDate}', '{_user}', '{_user}');";
                MySqlCommand customerInsertCmd = new MySqlCommand(customerInsertSqlString, _connection);
                MySqlDataReader customerReader;
                customerReader = customerInsertCmd.ExecuteReader();
                _connection.Close();
                parent.InitializeDataGrid();
                this.Close();
            }
        }
        private bool IsValidData()
        {
            bool valid = false;

            if (string.IsNullOrEmpty(nameTextbox.Text))
            {
                nameToolTip.Active = true;
                nameToolTip.Show("Name is required.", nameTextbox);
                nameTextbox.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                nameTextbox.BackColor = Color.White;
                nameToolTip.Active = false;
                valid = true;
            }

            if (string.IsNullOrEmpty(addressTextbox.Text))
            {
                addressToolTip.Active = true;
                addressToolTip.Show("Address is required.", addressTextbox);
                addressTextbox.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                addressTextbox.BackColor = Color.White;
                addressToolTip.Active = false;
                valid = true;
            }

            if (string.IsNullOrEmpty(cityTextbox.Text))
            {
                cityToolTip.Active = true;
                cityToolTip.Show("City is required.", cityTextbox);
                cityTextbox.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                cityTextbox.BackColor = Color.White;
                cityToolTip.Active = false;
                valid = true;
            }

            if (string.IsNullOrEmpty(countryTextbox.Text))
            {
                countryToolTip.Active = true;
                countryToolTip.Show("Country is required.", countryTextbox);
                countryTextbox.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                countryTextbox.BackColor = Color.White;
                countryToolTip.Active = false;
                valid = true;
            }

            if (string.IsNullOrEmpty(phoneTextbox.Text))
            {
                phoneToolTip.Active = true;
                phoneToolTip.Show("Phone is required.", phoneTextbox);
                phoneTextbox.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                phoneTextbox.BackColor = Color.White;
                phoneToolTip.Active = false;
                valid = true;
            }

            return valid;
        }

        private void nameTextbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameTextbox.Text))
            {
                nameToolTip.Active = true;
                nameToolTip.Show("Name is required.", nameTextbox);
                nameTextbox.BackColor = Color.Red;
            }
            else
            {
                nameTextbox.BackColor = Color.White;
                nameToolTip.Active = false;
            }
        }

        private void addressTextbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(addressTextbox.Text))
            {
                addressToolTip.Active = true;
                addressToolTip.Show("Address is required.", addressTextbox);
                addressTextbox.BackColor = Color.Red;
            }
            else
            {
                addressTextbox.BackColor = Color.White;
                addressToolTip.Active = false;
            }
        }

        private void cityTextbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cityTextbox.Text))
            {
                cityToolTip.Active = true;
                cityToolTip.Show("City is required.", cityTextbox);
                cityTextbox.BackColor = Color.Red;
            }
            else
            {
                cityTextbox.BackColor = Color.White;
                cityToolTip.Active = false;
            }
        }

        private void countryTextbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(countryTextbox.Text))
            {
                countryToolTip.Active = true;
                countryToolTip.Show("Country is required.", countryTextbox);
                countryTextbox.BackColor = Color.Red;
            }
            else
            {
                countryTextbox.BackColor = Color.White;
                countryToolTip.Active = false;
            }
        }

        private void phoneTextbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(phoneTextbox.Text))
            {
                phoneToolTip.Active = true;
                phoneToolTip.Show("Phone is required.", phoneTextbox);
                phoneTextbox.BackColor = Color.Red;
            }
            else
            {
                phoneTextbox.BackColor = Color.White;
                phoneToolTip.Active = false;
            }
        }
    }
}
