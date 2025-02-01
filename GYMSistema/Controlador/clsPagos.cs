using GYMSistema.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMSistema.Controlador
{
    internal class clsPagos
    {
        private csConexion objConexion = new csConexion();

        public bool RegistrarPago(dtoPagos pago)
        {
            bool resultado = false;

            using (SqlConnection cn = objConexion.obtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarPago", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdSocio", pago.IdSocio);
                    cmd.Parameters.AddWithValue("@IdMembresia", pago.IdMembresia);
                    cmd.Parameters.AddWithValue("@FechaPago", pago.FechaPago);
                    cmd.Parameters.AddWithValue("@Monto", pago.Monto);

                    try
                    {
                        cn.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        resultado = (filasAfectadas > 0);
                    }
                    catch (Exception ex)
                    {
                        resultado = false;
                    }
                }
            }

            return resultado;
        }

        public bool EditarPago(dtoPagos pago)
        {
            bool resultado = false;

            using (SqlConnection cn = objConexion.obtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarPago", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPago", pago.IdPago);
                    cmd.Parameters.AddWithValue("@IdSocio", pago.IdSocio);
                    cmd.Parameters.AddWithValue("@IdMembresia", pago.IdMembresia);
                    cmd.Parameters.AddWithValue("@FechaPago", pago.FechaPago);
                    cmd.Parameters.AddWithValue("@Monto", pago.Monto);

                    try
                    {
                        cn.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        resultado = (filasAfectadas > 0);
                    }
                    catch (Exception ex)
                    {
                        resultado = false;
                    }
                }
            }

            return resultado;
        }

        public bool EliminarPago(int idPago)
        {
            bool resultado = false;

            using (SqlConnection cn = objConexion.obtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_EliminarPago", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPago", idPago);

                    try
                    {
                        cn.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        resultado = (filasAfectadas > 0);
                    }
                    catch (Exception ex)
                    {
                        resultado = false;
                    }
                }
            }

            return resultado;
        }

        public List<dtoPagos> ListarAll()
        {
            List<dtoPagos> lista = new List<dtoPagos>();

            using (SqlConnection cn = objConexion.obtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ListarPagos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                dtoPagos pago = new dtoPagos
                                {
                                    IdPago = dr.GetInt32(dr.GetOrdinal("IdPago")),
                                    IdSocio = dr.GetInt32(dr.GetOrdinal("IdSocio")),
                                    IdMembresia = dr.GetInt32(dr.GetOrdinal("IdMembresia")),
                                    FechaPago = dr.GetDateTime(dr.GetOrdinal("FechaPago")),
                                    Monto = dr.GetDecimal(dr.GetOrdinal("Monto"))
                                };
                                lista.Add(pago);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lista = new List<dtoPagos>();
                    }
                }
            }

            return lista;
        }
    }
}
