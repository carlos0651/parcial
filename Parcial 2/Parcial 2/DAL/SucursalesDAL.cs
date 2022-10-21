using Parcial_2.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial_2.DAL
{
    public class SucursalesDAL
    {
        private Database db;
        public SucursalesDAL()
        {
            db = new Database();    
        }

        public DataTable getAllSedes()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = db.GetSqlConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM SUCURSAL";
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

        public List<SucursalesBLL> getallSedess()
        {
            List<SucursalesBLL> listSedes = new List<SucursalesBLL>();
            try
            {
                SqlConnection con = db.GetSqlConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM SUCURSAL";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            listSedes.Add(new SucursalesBLL(
                                Convert.ToInt32(reader["id_Sucursal"]),
                                Convert.ToString(reader["SUCURSAL"])
                            ));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontraron registros.");
                    }
                    con.Close();
                    return listSedes;
                }
            }
            catch
            {
                return listSedes;
            }
        }

        public bool createSedes(SucursalesBLL sede)
        {
            try
            {
                SqlConnection Con = db.GetSqlConnection();
                using (SqlCommand cmd = Con.CreateCommand())
                {
                    Con.Open();
                    cmd.CommandText = "INSERT INTO SUCURSAL (SUCURSAL) VALUES (@Suc);";
                    cmd.Parameters.AddWithValue("@Suc", sede.Sucursal);
                    cmd.ExecuteNonQuery();
                    Con.Close();

                    return true;
                }
            }

            catch
            {
                return false;
            }
        }

        public bool updateSedes(SucursalesBLL sede)
        {
            try
            {
                SqlConnection Con = db.GetSqlConnection();
                using (SqlCommand cmd = Con.CreateCommand())
                {
                    Con.Open();
                    cmd.CommandText = "UPDATE Sedes SET Sucursal = @Suc WHERE id_sucursal = @id;";
                    cmd.Parameters.AddWithValue("id_Sucursal", sede.Id_Sucursal);
                    cmd.Parameters.AddWithValue("@Suc", sede.Sucursal);
                    cmd.ExecuteNonQuery ();
                    Con.Close ();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool deleteSede(SucursalesBLL sede)
        {
            try
            {
                SqlConnection Con = db.GetSqlConnection ();
                using (SqlCommand cmd = Con.CreateCommand())
                {
                    Con.Open();
                    cmd.CommandText = "DELETE FROM Sedes WHERE id_Sucursal = @id;";
                    cmd.Parameters.AddWithValue("@id", sede.Id_Sucursal);
                    cmd.ExecuteNonQuery();
                    Con.Close();

                    return true;
                }    
            }
            catch
            {
                return false;
            }
        }
    }
}
