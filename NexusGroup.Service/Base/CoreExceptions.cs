using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Base
{
    public class LogConfiguration
    {
        public static string LogDirectory => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LOGS");
        private static void LogException(Exception ex, string LogType, string causeOrAction)
        {
            if (LogType != "LOGDATABASE" && LogType != "LOGSERVER")
            {
                throw new ArgumentException("Tipo de Log Incorrecto.", nameof(LogType));
            }
            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
            }
            string dateTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string logFilePath = Path.Combine(LogDirectory, $"{LogType}_{dateTime}.txt");
            string logMessage = $"----------------------------{Environment.NewLine}" +
                                $"Fecha: {dateTime}{Environment.NewLine}" +
                                $"Tipo de Error: {LogType}{Environment.NewLine}" +
                                $"Accion/Causa: {causeOrAction}{Environment.NewLine}" +
                                $"Mensaje: {ex.Message}{Environment.NewLine}" +
                                $"Stack Trace: {ex.StackTrace}{Environment.NewLine}";
            File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
        }
        public class ExceptionSQL : Exception
        {
            public ExceptionSQL(string accion, Exception inner = null): base(accion, inner)
            {
                LogException(inner, "LOGDATABASE", accion);
            }
        }
        public class ExceptionServer : Exception
        {
            public ExceptionServer(string accion, Exception inner = null) : base(accion, inner)
            {
                LogException(inner, "LOGSERVER", accion);
            }
        }

    }
}
