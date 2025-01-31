using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMSistema.Modelo
{
    internal class dtoPagos
    {
        public int IdPago { get; set; }
        public int IdSocio { get; set; }
        public int IdMembresia { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
    }
}
