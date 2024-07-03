using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void DelegadoBacklog(Serie serie);
    public class ManejadorBackLog
    {
        public event DelegadoBacklog NuevaSerieParaVer;
        public void IniciarManejador(List<Serie> series)
        {
            Task.Run(() => MoverSeries(series));
        }

        private void MoverSeries(List<Serie> series)
        {
            while (series.Count > 0)
            {
                // Obtener índice aleatorio usando la extensión
                int indiceAleatorio = series.IndiceRandom();

                // Acceder a la serie en el índice aleatorio
                Serie serie = series[indiceAleatorio];

                // Simular actualización de la serie usando AccesoDatos
                AccesoDatos.ActualizarSerie(serie);

                // Dormir el hilo durante 1500 milisegundos (1.5 segundos)
                Thread.Sleep(1500);

                // Disparar el evento SerieParaVer si tiene suscriptores
                OnSerieParaVer(serie);

                // Remover la serie de la lista después de procesarla
                series.RemoveAt(indiceAleatorio);
            }

        }
        protected virtual void OnSerieParaVer(Serie serie)
        {
            NuevaSerieParaVer?.Invoke(serie);
        }

    }
}
