using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace programm
{
    public class DbConnector
    {
        SqlConnection dbConnection = new SqlConnection("Server=CH10LT1284\\SQLEXPRESS;Database=blj-projectwpf;Trusted_Connection=True;");

        public SqlConnection GetConnection()
        {
            try
            {
                if (dbConnection.State != ConnectionState.Open)
                    dbConnection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Verbindung zur Datenbank konnte nicht aufgebaut werden: " + ex.Message);
            }
           return dbConnection;
        }
        public DataTable GetDataFromDb(string query)
        {
            ValidateConnection();

            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            cmd.Connection = dbConnection;
            cmd.CommandText = query;

            SqlDataAdapter adap = new SqlDataAdapter();
            adap.SelectCommand = cmd;
            adap.Fill(table);

            return table;
        }

        public void InsertHusi(string fach, string deinehusi, DateTime erledigtBis)
        {
            ValidateConnection();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = dbConnection;
                cmd.CommandText = "insert tbHusiplaner(Fach, DeineHusi, ErledigtBis) values (@fach, @deinehusi, @datum)";

                cmd.Parameters.AddWithValue("@fach", fach);
                cmd.Parameters.AddWithValue("@deinehusi", deinehusi);
                cmd.Parameters.AddWithValue("@datum", erledigtBis);
                
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Die Husi konnte nicht in die Datenbank eingetragen werden." + ex.Message);
            }
        }
        private void ValidateConnection()
        {
            try
            {
                if (dbConnection.State != ConnectionState.Open)
                    dbConnection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Datenbankverbindung konnte nicht geöffnet werden: " + ex.Message);
            }
        }
    }
}

