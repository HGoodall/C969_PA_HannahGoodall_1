﻿using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace C969_PA_HannahGoodall
{
    public partial class LoginForm : Form
    {
        private MySqlConnection _connection;
        private CultureInfo info = CultureInfo.CurrentCulture;
        public LoginForm(MySqlConnection connection)
        {
            InitializeComponent();
            _connection = connection;
            if(info.ToString().Contains("es"))
            {
                languageLabel.Text = "Por favor ingrese su nombre de usuario y contraseña.";
                usernameLabel.Text = "Usuario:";
                passwordLabel.Text = "Contraseña:";
                loginButton.Text = "Iniciar sesión";
                cancelButton.Text = "Cancelar";
            }
            if(info.ToString().Contains("en"))
            {
                languageLabel.Text = "Please enter your username and password.";
                usernameLabel.Text = "Username:";
                passwordLabel.Text = "Password:";
                loginButton.Text = "Login";
                cancelButton.Text = "Cancel";
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextbox.Text;
            string password = pwdTextbox.Text;
            string sqlString = "SELECT userName, password FROM user;";
            MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adp.Fill(dt);
            bool match = false;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr.ItemArray[0].ToString() == username && dr.ItemArray[1].ToString() == password)
                {
                    match = true;
                    break;
                }
                else
                {
                    match = false;
                }
            }
            if (match)
            {
                //login
            }
            else
            {
                MessageBox.Show("The username and password do not match.");
            }
        }
    }
}
