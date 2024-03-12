using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1
{
    public class DataBase
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; Port = 5432; Database = contacts; User Id = postgres; Password = assaq123;");

        public void openConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void closeConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }
        public NpgsqlConnection getConnection()
        {
            return conn;
        }
    }
}
