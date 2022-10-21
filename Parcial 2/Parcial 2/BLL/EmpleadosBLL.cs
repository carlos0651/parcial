using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_2.BLL
{
    public class EmpleadosBLL
    {
        private int id;
        private string nombres;
        private string apellidos;
        private string fecha_de_nacimiento;


        public EmpleadosBLL(int id)
        {
            this.id = id;
        }

        public EmpleadosBLL(int id, string nombres, string apellidos, string fecha_de_nacimiento) : this(id)
        {
        }

        public EmpleadosBLL(int id, string nombres, string apellidos, string fecha_de_nacimiento, int cargo, int sucursal)
        {
            this.id = id;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.fecha_de_nacimiento = fecha_de_nacimiento;

        }

        public int Id { get => id; set => id = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Fecha_de_nacimiento { get => fecha_de_nacimiento; set => fecha_de_nacimiento = value; }

    }
}
