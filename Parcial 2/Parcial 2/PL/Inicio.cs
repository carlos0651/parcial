using Parcial_2.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial_2
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            frmEmpleados fe = new frmEmpleados();
            fe.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            frmProductos fe = new frmProductos();
            fe.Show();
        }
    }
}
