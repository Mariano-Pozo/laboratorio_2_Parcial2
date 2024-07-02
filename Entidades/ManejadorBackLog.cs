using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ManejadorBackLog
    {
        public void IniciarManejador(List<Serie> series)
        {

        }

        private void MoverSeries(List<Serie> series)
        {

        }
        //como es el evento(?
        protected virtual void OnSerieParaVer(Serie serie)
        {
            SerieParaVer.Invoke(serie);
        }
    }
}
