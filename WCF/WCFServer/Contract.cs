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
    public class Contract : IContract
    {
        public static string connectionString = "Server=(local);Database=Astronauts;Trusted_Connection=True;";
        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand deleteCommand = new SqlCommand("delete from Astronaut where Id=" + id);
            deleteCommand.Connection = connection;
            deleteCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void Insert(Astronaut astronaut)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand insertCommand = new SqlCommand("insert into Astronaut (FirstName, SecondName, Age, IdNumber,ResultMathTest, ResultSportTest, CountryId) " +
                "values (@FirstName, @SecondName, @Age, @IdNumber,@ResultMathTest, @ResultSportTest, @AstronautId)", connection);

            insertCommand.Connection = connection;
            SqlParameter parName = new SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar);
            parName.Value = astronaut.FirstName;
            insertCommand.Parameters.Add(parName);
            insertCommand.Parameters.AddWithValue("@SecondName", astronaut.SecondName);
            insertCommand.Parameters.AddWithValue("@Age", astronaut.Age);
            insertCommand.Parameters.AddWithValue("@IdNumber", astronaut.IdNumber);
            insertCommand.Parameters.AddWithValue("@ResultMathTest", astronaut.ResultMathTest);
            insertCommand.Parameters.AddWithValue("@ResultSportTest", astronaut.ResultSportTest);
            insertCommand.Parameters.AddWithValue("@AstronautId", astronaut.AstronautId);
            //  SqlCommand insert = new SqlCommand("Set Identity_insert Astronaut ON");
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        public Astronaut Load(int id)
        {
            Astronaut astronaut = new Astronaut();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand readerCommand = new SqlCommand("select FirstName, SecondName, Age, IdNumber, ResultMathTest, ResultSportTest, CountryId  from Astronaut where Id=" + id);
            readerCommand.Connection = connection;
            SqlDataReader reader = readerCommand.ExecuteReader();

            while (reader.Read())
            {
                astronaut.Id = id;
                astronaut.FirstName = (string)reader["FirstName"];
                astronaut.SecondName = (string)reader["SecondName"];
                astronaut.Age = (int)reader["Age"];
                astronaut.IdNumber = ((string)reader["IdNumber"])[0];
                astronaut.ResultMathTest = (double)reader["ResultMathTest"];
                astronaut.ResultSportTest = (decimal)reader["ResultSportTest"];
                astronaut.AstronautId = (int)reader["CountryId"];
            }
            reader.Close();
            connection.Close();
            return astronaut;
        }

        public void Update(Astronaut astronaut)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand updateCommand = new SqlCommand("update Astronaut set FirstName=@FirstName,SecondName=@SecondName, Age=@Age, IdNumber=@IdNumber, ResultMathTest=@ResultMathTest,ResultSportTest=@ResultSportTest from Astronaut where Id=" +astronaut.Id );
            updateCommand.Parameters.AddWithValue("@FirstName", astronaut.FirstName);
            updateCommand.Parameters.AddWithValue("@SecondName", astronaut.SecondName);
            updateCommand.Parameters.AddWithValue("@Age", astronaut.Age);
            updateCommand.Parameters.AddWithValue("@IdNumber", astronaut.IdNumber);
            updateCommand.Parameters.AddWithValue("@ResultMathTest", astronaut.ResultMathTest);
            updateCommand.Parameters.AddWithValue("@ResultSportTest", astronaut.ResultSportTest);
            updateCommand.Parameters.AddWithValue("@Id", astronaut.Id);
            updateCommand.Connection = connection;
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable RefreshView(string name)
        {
            DataTable dataTable = new DataTable("Astronaut");
            string sql = "SELECT Astronaut.Id As ID, Astronaut.FirstName , Astronaut.SecondName, Astronaut.Age, Astronaut.IdNumber, Astronaut.ResultMathTest, Astronaut.ResultSportTest from Astronaut";
           
            if (name != "")
            {
                sql = sql + " where Astronaut.FirstName like '%" + name + "%'";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                // Создаем объект Dataset
                // Заполняем Dataset
                adapter.Fill(dataTable);
                // Отображаем данные
            }
            return dataTable;
        } 
    }
}

