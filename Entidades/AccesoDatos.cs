using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class AccesoDatos
    {
        //static string cadenaDeConexion;
        static SqlCommand comando;
        static SqlConnection conexion;

        static AccesoDatos() 
        {
            conexion = new SqlConnection("Server=.;Database=20240701-SP;Trusted_Connection=True;"); 
            comando = new SqlCommand();
            comando.Connection = conexion;
        }

        public static void ActualizarSerie(Serie serie)
        {
            try
            {   string query = "UPDATE series SET alumno = @nombreAlumno WHERE nombre = @nombreSerie";
                comando.CommandText = query;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nombreAlumno", "NombreDelAlumno");
                comando.Parameters.AddWithValue("@nombreSerie", serie.Nombre);

                AbrirConexion();
                comando.ExecuteNonQuery();
            }
            catch (BackLogException ex)
            {
                Console.WriteLine($"Error al actualizar la serie: {ex.Message}"); //este va?
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al actualizar la serie: {ex.Message}");
                throw;
            }
            finally
            {
                CerrarConexion();
            }

        }

        public static List<Serie> ObtenerBackLog()
        {
            List<Serie> backlog = new List<Serie>();

            try
            {
                string query = "SELECT nombre, genero FROM series";
                comando.CommandText = query;

                AbrirConexion();
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    string nombre = reader["nombre"].ToString();
                    string genero = reader["genero"].ToString();
                    Serie serie = new Serie(nombre, genero);
                    backlog.Add(serie);
                }

                reader.Close();
            }
            catch (BackLogException ex)
            {
                Console.WriteLine($"Error personalizado al obtener el backlog: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el backlog: {ex.Message}");
                throw;
            }
            finally
            {
                CerrarConexion();
            }
            return backlog;
        }
        /// <summary>
        /// Abre la conexion a la base de datos si no esta abierta
        /// </summary>
        private static void AbrirConexion()
        {
            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }
        }
        /// <summary>
        /// cierrar la conexion a la base de datos si no esta cerrada
        /// </summary>
        private static void CerrarConexion()
        {
            if (conexion.State != ConnectionState.Closed)
            {
                conexion.Close();
            }
        }
    }

  
}
