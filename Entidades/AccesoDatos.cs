using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class AccesoDatos
    {
        static string cadenaDeConexion;
        static SqlCommand comando;
        static SqlConnection conexion;

        static AccesoDatos() { }

        static void ActualizarSerie(Serie serie)
        {

        }

        static List<Serie> ObtenerBackLog() 
        {
            
        }

    }

  
}
