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
    internal class clsSocios
    {
        private csConexion objConexion = new csConexion();

        public bool RegistrarSocio(dtoSocios socio)
        {
            bool resultado = false;

            using (SqlConnection cn = objConexion.obtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarSocio", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", socio.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", socio.Apellido);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", socio.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Direccion", socio.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", socio.Telefono);

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

        public bool EditarSocio(dtoSocios socio)
        {
            bool resultado = false;

            using (SqlConnection cn = objConexion.obtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarSocio", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdSocio", socio.IdSocio);
                    cmd.Parameters.AddWithValue("@Nombre", socio.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", socio.Apellido);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", socio.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Direccion", socio.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", socio.Telefono);

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

        public bool EliminarSocio(int idSocio)
        {
            bool resultado = false;

            using (SqlConnection cn = objConexion.obtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_EliminarSocio", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdSocio", idSocio);

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

        public List<dtoSocios> ListarAll()
        {
            List<dtoSocios> lista = new List<dtoSocios>();

            using (SqlConnection cn = objConexion.obtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ListarSocios", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                dtoSocios socio = new dtoSocios
                                {
                                    IdSocio = dr.GetInt32(dr.GetOrdinal("IdSocio")),
                                    Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                                    Apellido = dr.GetString(dr.GetOrdinal("Apellido")),
                                    FechaNacimiento = dr.GetDateTime(dr.GetOrdinal("FechaNacimiento")),
                                    Direccion = dr.GetString(dr.GetOrdinal("Direccion")),
                                    Telefono = dr.GetString(dr.GetOrdinal("Telefono"))
                                };
                                lista.Add(socio);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lista = new List<dtoSocios>();
                    }
                }
            }

            return lista;
        }
    }
}
