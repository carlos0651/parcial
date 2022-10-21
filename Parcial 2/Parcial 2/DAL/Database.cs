using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parcial_2.Properties;

namespace Parcial_2.DAL
{
    public class Database
    {
        public static string getStrConnection()
        {
            return Settings.Default.TIENDAConnectionString;
        }

        public SqlConnection GetSqlConnection()
        {
            SqlConnection Con = new SqlConnection(getStrConnection());
            return Con;
        }

        public bool testConection()
        {
            SqlConnection Con = this.GetSqlConnection();
            Con.Open();
            if (Con.State == System.Data.ConnectionState.Open)
            {
                Con.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
