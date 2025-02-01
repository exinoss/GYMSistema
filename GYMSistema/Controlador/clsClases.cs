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
    internal class clsClases
    {
        private csConexion objConexion = new csConexion();

        public bool RegistrarClase(dtoClases clase)
        {
            bool resultado = false;

            // Usamos la conexión que proviene de csConexion
            using (SqlConnection cn = objConexion.obtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarClase", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdSocio", clase.IdSocio);
                    cmd.Parameters.AddWithValue("@Nombre", clase.Nombre);
                    cmd.Parameters.AddWithValue("@DiaSemana", clase.DiaSemana);
                    cmd.Parameters.AddWithValue("@Hora", clase.Hora);
                    cmd.Parameters.AddWithValue("@CupoMaximo", clase.CupoMaximo);

                    try
                    {
                        cn.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        resultado = (filasAfectadas > 0);
                    }
                    catch (Exception ex)
                    {
                        // Manejo de la excepción (log o como prefieras).
                        resultado = false;
                    }
                }
            }

            return resultado;
        }

        public bool EditarClase(dtoClases clase)
        {
            bool resultado = false;

            using (SqlConnection cn = objConexion.obtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarClase", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdClase", clase.IdClase);
                    cmd.Parameters.AddWithValue("@IdSocio", clase.IdSocio);
                    cmd.Parameters.AddWithValue("@Nombre", clase.Nombre);
                    cmd.Parameters.AddWithValue("@DiaSemana", clase.DiaSemana);
                    cmd.Parameters.AddWithValue("@Hora", clase.Hora);
                    cmd.Parameters.AddWithValue("@CupoMaximo", clase.CupoMaximo);

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

        public bool EliminarClase(int idClase)
        {
            bool resultado = false;

            using (SqlConnection cn = objConexion.obtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_EliminarClase", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdClase", idClase);

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

        public List<dtoClases> ListarAll()
        {
            List<dtoClases> lista = new List<dtoClases>();

            using (SqlConnection cn = objConexion.obtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ListarClases", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                dtoClases clase = new dtoClases
                                {
                                    IdClase = dr.GetInt32(dr.GetOrdinal("IdClase")),
                                    IdSocio = dr.GetInt32(dr.GetOrdinal("IdSocio")),
                                    Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                                    DiaSemana = dr.GetString(dr.GetOrdinal("DiaSemana")),
                                    Hora = dr.GetInt32(dr.GetOrdinal("Hora")),
                                    CupoMaximo = dr.GetInt32(dr.GetOrdinal("CupoMaximo"))
                                };
                                lista.Add(clase);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejo de la excepción
                        lista = new List<dtoClases>();
                    }
                }
            }

            return lista;
        }
    }
}
