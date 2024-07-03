using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Logger
    {
        private static string desktopPath;
        private static string logFilePath;
        static Logger()
        {
            desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            logFilePath = Path.Combine(desktopPath, "Error.log");
        }
        public static void Log(Exception ex)
        {
            try
            {
                string logMessage = $"{DateTime.Now} - {ex.Message}";
                File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception logEx)
            {
                throw new BackLogException("Error al escribir en el archivo de log.", logEx);
            }
        }
    }

}
