using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMSistema.Modelo
{
    internal class dtoMembresia
    {
        public int IdMembresia { get; set; }
        public string Tipo { get; set; }
        public int DuracionMeses { get; set; }
        public decimal Precio { get; set; }
        public bool Activa { get; set; }
    }
}
