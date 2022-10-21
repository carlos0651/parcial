using Parcial_2.BLL;
using Parcial_2.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial_2.PL
{
    public partial class frmEmpleados : Form
    {
        SucursalesDAL sucursales;
        EmpleadosDAL empleados;
        CargosDAL cargos;
        public frmEmpleados()
        {
            InitializeComponent();
            this.sucursales = new SucursalesDAL();
            this.empleados = new EmpleadosDAL();
            this.cargos = new CargosDAL();
        }

        private void listaSedes()
        {
            cmbSedes.DataSource = sucursales.getAllSedes();
            cmbSedes.DisplayMember = "SUCURSAL";
            cmbSedes.ValueMember = "id_Sucursal";
            cmbSedes.SelectedValue = 0;
        }

        private void listCargos()
        {
            cmbCargo.DataSource = cargos.getAllCargos();
            cmbCargo.DisplayMember = "CARGO";
            cmbCargo.ValueMember = "id_Cargo";
            cmbCargo.SelectedValue = 0;
        }

        private void clearTextBox()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtFecha.Clear();
            cmbCargo.SelectedValue = 0;
            cmbSedes.SelectedValue = 0;
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            listaSedes();
            listCargos();
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombres.Text) || string.IsNullOrEmpty(txtApellidos.Text)
                || string.IsNullOrEmpty(txtFecha.Text) || string.IsNullOrEmpty(cmbSedes.Text)
                || string.IsNullOrEmpty(cmbCargo.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else
            {
                string nombres = txtNombres.Text;
                string apellidos = txtApellidos.Text;
                string fecha_de_nacimiento = txtFecha.Text;
                int idSede = Convert.ToInt32(cmbSedes.SelectedValue);
                int idCargo = Convert.ToInt32(cmbCargo.SelectedValue);
                EmpleadosBLL emp = new EmpleadosBLL(0, nombres, apellidos, fecha_de_nacimiento);
                SedesBLL sucursal = new SedesBLL(idSede);
                CargosBLL cargos = new CargosBLL(idCargo);
                if (!empleados.createEmpleados(emp, sucursal, cargos))
                {
                    return;
                }
                MessageBox.Show("Empleado registrado con exito");

                clearTextBox();
            }
        }
    }
}
