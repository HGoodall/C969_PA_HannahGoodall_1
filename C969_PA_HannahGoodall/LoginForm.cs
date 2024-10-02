using MySql.Data.MySqlClient;
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
            locationLabel.Text = $"You are located in: {info.ToString()}";
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
            string sqlString = "SELECT userId, userName, password FROM user;";
            MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adp.Fill(dt);
            bool match = false;
            string userId = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["userName"].ToString() == username && dr["password"].ToString() == password)
                {
                    match = true;
                    userId = dr["userId"].ToString();
                    break;
                }
                else
                {
                    match = false;
                }
            }
            if (match)
            {
                var customerForm = new RecordsForm(_connection, username, userId);
                this.Hide();
                customerForm.ShowDialog();
            }
            else
            {
                if (info.ToString().Contains("es"))
                {
                    MessageBox.Show("El nombre de usuario y la contraseña no coinciden");
                }
                else
                {
                    MessageBox.Show("The username and password do not match.");
                }
            }
        }

        private void pwdTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton_Click(sender, e);
            }
        }
    }
}
