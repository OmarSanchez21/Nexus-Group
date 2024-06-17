using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Core
{
    internal static class ExcetionLogs
    {
        private static void LogError(Exception ex, string errorType)
        {
            string solutionPATH = AppDomain.CurrentDomain.BaseDirectory;
            string logDirectory = Path.Combine(solutionPATH, "..", "..", "LOGS");
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
            string currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            string logFilePath = Path.Combine(logDirectory, $"error_log_{errorType}_{currentDate}.text");

            string errorMesage = $"{DateTime.Now}: {ex.GetType().Name} - {ex.Message}\n{ex.StackTrace}\n";

            File.AppendAllText(logFilePath, errorMesage);
        }

        public static void LogSQLError(SqlException ex) 
        {
            LogError(ex, "SQL");
        }
        public static void LogInternalError(Exception ex)
        {
            LogError(ex, "Internal");
        }
    }
}
