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
    internal class clsMembresia
    {
        private csConexion objConexion = new csConexion();

        public bool RegistrarMembresia(dtoMembresia membresia)
        {
            bool resultado = false;

            using (SqlConnection cn = objConexion.obtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarMembresia", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Tipo", membresia.Tipo);
                    cmd.Parameters.AddWithValue("@DuracionMeses", membresia.DuracionMeses);
                    cmd.Parameters.AddWithValue("@Precio", membresia.Precio);
                    cmd.Parameters.AddWithValue("@Activa", membresia.Activa);

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

        public bool EditarMembresia(dtoMembresia membresia)
        {
            bool resultado = false;

            using (SqlConnection cn = objConexion.obtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarMembresia", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdMembresia", membresia.IdMembresia);
                    cmd.Parameters.AddWithValue("@Tipo", membresia.Tipo);
                    cmd.Parameters.AddWithValue("@DuracionMeses", membresia.DuracionMeses);
                    cmd.Parameters.AddWithValue("@Precio", membresia.Precio);
                    cmd.Parameters.AddWithValue("@Activa", membresia.Activa);

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

        public bool EliminarMembresia(int idMembresia)
        {
            bool resultado = false;

            using (SqlConnection cn = objConexion.obtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_EliminarMembresia", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdMembresia", idMembresia);

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

        public List<dtoMembresia> ListarAll()
        {
            List<dtoMembresia> lista = new List<dtoMembresia>();

            using (SqlConnection cn = objConexion.obtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ListarMembresias", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                dtoMembresia membresia = new dtoMembresia
                                {
                                    IdMembresia = dr.GetInt32(dr.GetOrdinal("IdMembresia")),
                                    Tipo = dr.GetString(dr.GetOrdinal("Tipo")),
                                    DuracionMeses = dr.GetInt32(dr.GetOrdinal("DuracionMeses")),
                                    Precio = dr.GetDecimal(dr.GetOrdinal("Precio")),
                                    Activa = dr.GetBoolean(dr.GetOrdinal("Activa"))
                                };
                                lista.Add(membresia);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lista = new List<dtoMembresia>();
                    }
                }
            }

            return lista;
        }
    }
}
