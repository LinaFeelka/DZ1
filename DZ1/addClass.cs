using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DZ1
{
    public class addClass
    {
        DataBase database = new DataBase();

        public addClass() { }

        public void insertContact(string name, string phone)
        {
            database.openConnection();

            var addQuery = $"insert into contact (name, phone) values ('{name}', '{phone}')";
            var comm = new NpgsqlCommand(addQuery, database.getConnection());
            comm.ExecuteNonQuery();

            database.closeConnection();
        }
    }
}
