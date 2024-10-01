using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace C969_PA_HannahGoodall
{
    public partial class AddUpdateCustomerForm : Form
    {
        private MySqlConnection _connection;
        private string _user;
        private RecordsForm parent;
        private string _customerId;
        public AddUpdateCustomerForm(MySqlConnection connection, string user, RecordsForm form, string customerId = "")
        {
            InitializeComponent();
            _connection = connection;
            _user = user;
            parent = form;
            _customerId = customerId;
            if (!string.IsNullOrEmpty(customerId))
            {
                setCustomer();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string name = "";
        private string address = "";
        private string city = "";
        private string country = "";
        private string phone = "";
        private string cityId = "";
        private string countryId = "";
        private string addressId = "";
        private string createDate = DateTime.Now.ToString("yyyy-MM-dd");
        private void setCustomer()
        {
            string findCustomerSqlString = $"SELECT * FROM customer WHERE customerId = {_customerId};";
            MySqlCommand findCustomerCmd = new MySqlCommand(findCustomerSqlString, _connection);
            MySqlDataAdapter findCusAdp = new MySqlDataAdapter(findCustomerCmd);
            DataTable dt = new DataTable();
            findCusAdp.Fill(dt);

            nameTextbox.Text = dt.Rows[0]["customerName"].ToString();
            name = nameTextbox.Text;
            addressId = dt.Rows[0]["addressId"].ToString();

            string findAddressSqlString = $"SELECT * FROM address WHERE addressId = {addressId};";
            MySqlCommand findAddressCmd = new MySqlCommand(findAddressSqlString, _connection);
            MySqlDataAdapter findAddressAdp = new MySqlDataAdapter(findAddressCmd);
            DataTable dt1 = new DataTable();
            findAddressAdp.Fill(dt1);

            addressTextbox.Text = dt1.Rows[0]["address"].ToString();
            address = addressTextbox.Text;
            phoneTextbox.Text = dt1.Rows[0]["phone"].ToString();
            phone = phoneTextbox.Text;
            cityId = dt1.Rows[0]["cityId"].ToString();

            string findCitySqlString = $"SELECT * FROM city WHERE cityId = {cityId};";
            MySqlCommand findCityCmd = new MySqlCommand(findCitySqlString, _connection);
            MySqlDataAdapter findCityAdp = new MySqlDataAdapter(findCityCmd);
            DataTable dt2 = new DataTable();
            findCityAdp.Fill(dt2);

            cityTextbox.Text = dt2.Rows[0]["city"].ToString();
            city = cityTextbox.Text;
            countryId = dt2.Rows[0]["countryId"].ToString();

            string findCountrySqlString = $"SELECT * FROM country WHERE countryId = {countryId};";
            MySqlCommand findCountryCmd = new MySqlCommand(findCountrySqlString, _connection);
            MySqlDataAdapter findCountryAdp = new MySqlDataAdapter(findCountryCmd);
            DataTable dt3 = new DataTable();
            findCountryAdp.Fill(dt3);

            countryTextbox.Text = dt3.Rows[0]["country"].ToString();
            country = countryTextbox.Text;

        }
        private void saveCusButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (string.IsNullOrEmpty(_customerId))
                {
                    //insert customer to the DB

                    //insert country
                    countryId = GetCountryId();
                    _connection.Close();
                    if (string.IsNullOrEmpty(countryId))
                    {
                        try
                        {
                            if (_connection.State == ConnectionState.Closed)
                            {
                                _connection.Open();
                            }
                            string countryInsertSqlString = $"INSERT INTO country (country, createDate, createdBy, lastUpdateBy) VALUES ('{countryTextbox.Text}', '{createDate}', '{_user}', '{_user}');";
                            MySqlCommand countryInsertCmd = new MySqlCommand(countryInsertSqlString, _connection);
                            MySqlDataReader reader;
                            reader = countryInsertCmd.ExecuteReader();
                            _connection.Close();
                            countryId = GetCountryId();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }

                    //insert city
                    cityId = GetCityId();
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
                }
                else
                {
                    if (nameTextbox.Text != name)
                    {
                        try
                        {
                            if (_connection.State == ConnectionState.Closed)
                            {
                                _connection.Open();
                            }
                            string updateNameSqlString = $"UPDATE customer SET customerName = '{nameTextbox.Text}' WHERE customerId = {_customerId};";
                            MySqlCommand nameUpdateCmd = new MySqlCommand(updateNameSqlString, _connection);
                            MySqlDataReader nameReader;
                            nameReader = nameUpdateCmd.ExecuteReader();
                            _connection.Close();
                        }
                        catch(Exception ex)
                        {
                            throw new Exception(ex.Message, ex);
                        }
                    }
                    if (addressTextbox.Text != address)
                    {
                        if (_connection.State == ConnectionState.Closed)
                        {
                            _connection.Open();
                        }
                        string updateAddressSqlString = $"UPDATE address SET address = '{addressTextbox.Text}' WHERE addressId = {addressId};";
                        MySqlCommand addressUpdateCmd = new MySqlCommand(updateAddressSqlString, _connection);
                        MySqlDataReader addressReader;
                        addressReader = addressUpdateCmd.ExecuteReader();
                        _connection.Close();
                    }
                    if (cityTextbox.Text != city)
                    {
                        try
                        {

                            var existingCity = GetCityId();
                            if (_connection.State == ConnectionState.Closed)
                            {
                                _connection.Open();
                            }
                            if (!string.IsNullOrEmpty(existingCity))
                            {
                                string existingCitySqlString = $"UPDATE address SET cityId = '{existingCity}' WHERE addressId = {addressId};";
                                MySqlCommand cityUpdateCmd = new MySqlCommand(existingCitySqlString, _connection);
                                MySqlDataReader cityReader;
                                cityReader = cityUpdateCmd.ExecuteReader();
                                _connection.Close();
                            }
                            else
                            {
                                if (_connection.State == ConnectionState.Closed)
                                {
                                    _connection.Open();
                                }
                                //insert new city and then update address with new cityID
                                string cityInsertSqlString = $"INSERT INTO city (city, countryId, createDate, createdBy, lastUpdateBy) VALUES ('{cityTextbox.Text}', '{countryId}', '{createDate}', '{_user}', '{_user}');";
                                MySqlCommand cityInsertCmd = new MySqlCommand(cityInsertSqlString, _connection);
                                MySqlDataReader cityReader;
                                cityReader = cityInsertCmd.ExecuteReader();
                                _connection.Close();

                                cityId = GetCityId();
                                if (_connection.State == ConnectionState.Closed)
                                {
                                    _connection.Open();
                                }
                                string updateCitySqlString = $"UPDATE address SET cityId = '{cityId}' WHERE addressId = {addressId};";
                                MySqlCommand cityUpdateCmd = new MySqlCommand(updateCitySqlString, _connection);
                                MySqlDataReader cityUpdateReader;
                                cityUpdateReader = cityUpdateCmd.ExecuteReader();
                                _connection.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message, ex);
                        }
                    }

                    if (countryTextbox.Text != country)
                    {
                        try
                        {
                            var existingCountry = GetCountryId();

                            if (_connection.State == ConnectionState.Closed)
                            {
                                _connection.Open();
                            }
                            if (!string.IsNullOrEmpty(existingCountry))
                            {
                                string existingCountrySqlString = $"UPDATE city SET countryId = '{existingCountry}' WHERE cityId = {cityId};";
                                MySqlCommand countryUpdateCmd = new MySqlCommand(existingCountrySqlString, _connection);
                                MySqlDataReader countryReader;
                                countryReader = countryUpdateCmd.ExecuteReader();
                                _connection.Close();
                            }
                            else
                            {
                                if (_connection.State == ConnectionState.Closed)
                                {
                                    _connection.Open();
                                }
                                string countryInsertSqlString = $"INSERT INTO country (country, createDate, createdBy, lastUpdateBy) VALUES ('{countryTextbox.Text}', '{createDate}', '{_user}', '{_user}');";
                                MySqlCommand countryInsertCmd = new MySqlCommand(countryInsertSqlString, _connection);
                                MySqlDataReader countryReader;
                                countryReader = countryInsertCmd.ExecuteReader();
                                _connection.Close();
                                countryId = GetCountryId();
                                if (_connection.State == ConnectionState.Closed)
                                {
                                    _connection.Open();
                                }
                                string updateCountrySqlString = $"UPDATE city SET countryId = '{countryId}' WHERE cityId = {cityId};";
                                MySqlCommand countryUpdateCmd = new MySqlCommand(updateCountrySqlString, _connection);
                                MySqlDataReader countryUpdateReader;
                                countryUpdateReader = countryUpdateCmd.ExecuteReader();
                                _connection.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message, ex);
                        }

                    }
                    if (phoneTextbox.Text != phone)
                    {
                        if (_connection.State == ConnectionState.Closed)
                        {
                            _connection.Open();
                        }
                        string updatePhoneSqlString = $"UPDATE address SET phone = '{phoneTextbox.Text}' WHERE addressId = {addressId};";
                        MySqlCommand phoneUpdateCmd = new MySqlCommand(updatePhoneSqlString, _connection);
                        MySqlDataReader phoneReader;
                        phoneReader = phoneUpdateCmd.ExecuteReader();
                        _connection.Close();
                    }
                }

                parent.InitializeCustomerDataGrid();
                this.Close();
            }
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
        private bool IsValidData()
        {
            bool valid = false;

            if (string.IsNullOrEmpty(nameTextbox.Text.Trim()))
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

            if (string.IsNullOrEmpty(addressTextbox.Text.Trim()))
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

            if (string.IsNullOrEmpty(cityTextbox.Text.Trim()))
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

            if (string.IsNullOrEmpty(countryTextbox.Text.Trim()))
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

            if (string.IsNullOrEmpty(phoneTextbox.Text.Trim()))
            {
                phoneToolTip.Active = true;
                phoneToolTip.Show("Phone is required.", phoneTextbox);
                phoneTextbox.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                Match match = Regex.Match(phoneTextbox.Text, @"^[0-9-]*$");
                if (!match.Success)
                {
                    phoneToolTip.Active = true;
                    phoneToolTip.Show("Phone can only be numbers and dashes.", phoneTextbox);
                    phoneTextbox.BackColor = Color.Red;
                    valid = false;
                }
                else
                {
                    phoneTextbox.BackColor = Color.White;
                    phoneToolTip.Active = false;
                    valid = true;
                }
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
            if (string.IsNullOrEmpty(addressTextbox.Text.Trim()))
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
            if (string.IsNullOrEmpty(countryTextbox.Text.Trim()))
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
            if (string.IsNullOrEmpty(phoneTextbox.Text.Trim()))
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
