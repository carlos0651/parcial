using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_2.BLL
{
    public class CargosBLL
    {
        private int id_Cargo;
        private double salario;

        public CargosBLL(int id_Cargo)
        {
            this.id_Cargo = id_Cargo;
        }

        public  CargosBLL(int id_Cargo, string CARGO, double salario)
        {
            this.id_Cargo = id_Cargo;
            this.Cargo = CARGO;
            this.salario = salario;
        }

        public int Id_Cargo
        {
            get => id_Cargo; set => id_Cargo = value;
        }
        public string Cargo { get; set; }
        public double Salario { get => salario; set => salario = value; }

    }
}
