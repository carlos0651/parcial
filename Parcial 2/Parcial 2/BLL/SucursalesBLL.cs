using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_2.BLL
{
    public class SucursalesBLL
    {
        private int id_Sucursal;
        private string SUCURSAL;

        public SucursalesBLL(int id_Sucursal)
        {
            this.id_Sucursal = Id_Sucursal;
        }

        public SucursalesBLL (int id_Sucursal, string SUCURSAL)
        {
            this.id_Sucursal = id_Sucursal;
            this.SUCURSAL = SUCURSAL;
        }

        public int Id_Sucursal { get => id_Sucursal; set => id_Sucursal = value; }
        public string Sucursal { get => SUCURSAL; set => SUCURSAL = value; }
    }
}
