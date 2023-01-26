using Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    

    public class DataBase
    {
        SqlConnection connectionString = new SqlConnection("Server=LAPTOP-89HNI065;Database=Astronauts;Trusted_Connection=True;");
        public void openConnection()
        {
            connectionString.Open();
        }
        public void closeConnection()
        {
            if (connectionString.State == System.Data.ConnectionState.Open)
            {
                connectionString.Close();
            }
        }
        public SqlConnection GetConnection()
        {
            return connectionString;
        }
    }
    public class Login : ILogin
    {
        public static DataBase database = new DataBase();

        public int Log_in(string username, string password)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"select id_user, login_user, password_user from register where login_user = '{username}' and password_user = '{password}'";

            SqlCommand cmd = new SqlCommand(queryString, database.GetConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Registration(string username, string password)
        {
            if (checkUser(username))
                return 0;
            string querystring = $"insert into register(login_user, password_user) values('{username}','{password}')";

            SqlCommand cmd = new SqlCommand(querystring, database.GetConnection());
            database.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
            database.closeConnection();
        }
        private Boolean checkUser(string loginUser)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string querystring = $"select * from register where login_user = '{loginUser}'";
            SqlCommand cmd = new SqlCommand(querystring, database.GetConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
