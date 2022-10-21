using Parcial_2;
using Parcial_2.BLL;
using Parcial_2.PL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_2.DAL
{
    internal class EmpleadosDAL
    {
        private Database db;
        public EmpleadosDAL()
        {
            db = new Database();
        }

        public DataTable getAllEmpleados()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = db.GetSqlConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Empleados";
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
        public bool createEmpleados(EmpleadosBLL emp, SucursalesBLL sucursal, CargosBLL cargos)
        {
            try
            {
                SqlConnection Con = db.GetSqlConnection();
                using (SqlCommand cmd = Con.CreateCommand())
                {
                    Con.Open();
                    cmd.CommandText = "INSERT INTO Empleados (Nombres, Apellidos; fecha_de_nacimiento id_sucursal, id_cargo) VALUES (@nom, @ap, @nac, @idS, @idC);";
                    cmd.Parameters.AddWithValue("@nom", emp.Nombres);
                    cmd.Parameters.AddWithValue("@ap", emp.Apellidos);
                    cmd.Parameters.AddWithValue("@nac", emp.Fecha_de_nacimiento);
                    cmd.Parameters.AddWithValue("@idS", sucursal.Id_Sucursal);
                    cmd.Parameters.AddWithValue("@idC", cargos.Id_Cargo);
                    cmd.ExecuteNonQuery();
                    Con.Close();

                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.GetBaseException());
                return false;
            }
        }

        public bool updateEmpleados(EmpleadosBLL emp, SucursalesBLL sucursales, CargosBLL cargos)
        {
            try
            {
                SqlConnection con = db.GetSqlConnection();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = "UPDATE Empleados SET nombres = @nom, apellidos = @ap, Fecha_de_naciemiento = @nac, id_sucursal = @idS, id_cargo = idC WHERE id = @id; ";
                    cmd.Parameters.AddWithValue("@id", emp.Id);
                    cmd.Parameters.AddWithValue("@nom", emp.Nombres);
                    cmd.Parameters.AddWithValue("@ap", emp.Apellidos);
                    cmd.Parameters.AddWithValue("@nac", emp.Fecha_de_nacimiento);
                    cmd.Parameters.AddWithValue("@idS", sucursales.Id_Sucursal);
                    cmd.Parameters.AddWithValue("@idC", cargos.Id_Cargo);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    return true;

                }
            }
            catch
            {
                return false;
            }

        }

        

        public bool deleteEmpleados(EmpleadosBLL emp)
        {
            try
            {
                SqlConnection Con = db.GetSqlConnection();
                using (SqlCommand cmd = Con.CreateCommand())
                {
                    Con.Open();
                    cmd.CommandText = "DELETE FROM Empleados Where id = @id";
                    cmd.Parameters.AddWithValue("@id", emp.Id);
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
