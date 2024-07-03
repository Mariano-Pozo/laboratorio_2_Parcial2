using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ExtensoraRandom
    {
        public static double CalcularDiferenciaEnSegundos(this DateTime inicio, DateTime fin)
        {
            return (fin - inicio).TotalSeconds;
        }
        public static int IndiceRandom(this List<Serie> series)
        {
            if (series == null || series.Count == 0)
            {
                throw new ArgumentException("La lista de series no puede estar vacía o nula.");
            }

            Random random = new Random();
            return random.Next(0, series.Count);
        }
    }
}
