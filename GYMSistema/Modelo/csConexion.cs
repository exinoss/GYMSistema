using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMSistema.Modelo
{
    internal class csConexion
    {
        private readonly string cadenaConexion =
            "Server=(local);database=GYMBD;uid=sa;pwd=123456";

        public SqlConnection obtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
