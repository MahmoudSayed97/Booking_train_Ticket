using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    class DP
    {
      public MySqlConnection connection;
        public string server, user, password, database;
        public DP()
        {
            server = "localhost";
            database = "project";
            user = "root";
            password = "";
            string connectionstring;
            connectionstring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + user + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionstring);
        }
        public void openconnection()
        {
            try
            {
                connection.Open();
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("can not connect to server ");
                        break;
                    case 1045:
                        MessageBox.Show("invalid username /password ,please try again ");
                        break;
                }
            }
        }
        public void closeconnection()
        {
            try
            {
                connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
