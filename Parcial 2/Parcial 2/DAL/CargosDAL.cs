using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_2.DAL
{
    public class CargosDAL
    {
        private Database db;
        public CargosDAL()
        {
            db = new Database();
        }

        public DataTable getAllCargos()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = db.GetSqlConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM CARGO";
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    con.Close();
                    return dt;
                }
            }
            catch
            {
                return dt;
            }
        }
    }
}
