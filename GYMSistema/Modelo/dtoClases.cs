using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMSistema.Modelo
{
    internal class dtoClases
    {
        public int IdClase { get; set; }
        public int IdSocio { get; set; }
        public string Nombre { get; set; }
        public string DiaSemana { get; set; }
        public int Hora { get; set; }
        public int CupoMaximo { get; set; }
    }
}
