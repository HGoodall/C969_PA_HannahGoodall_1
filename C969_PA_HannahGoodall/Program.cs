using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace C969_PA_HannahGoodall
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //MySQL connection
            string connectionString = ConfigurationManager.ConnectionStrings["mySqlKey"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);

            conn.Open();
            string sqlString = "use client_schedule;";
            MySqlCommand cmd = new MySqlCommand(sqlString, conn);
            Application.Run(new LoginForm(conn));
        }
    }
}
