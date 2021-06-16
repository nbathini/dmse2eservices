using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2EDashboard.Utility
{
    public static class LogHelper
    {
        public static void LogFile(LogType logType, string subject)
        {
            LogHelper.LogFile(logType, subject, string.Empty, string.Empty);
        }

        public static void LogFile(LogType logType, string subject, Exception ex)
        {
            LogHelper.LogFile(logType, subject, ex.Message, ex.StackTrace);
        }

        private static void LogFile(LogType logType, string subject, string description, string exception)
        {
            try
            {
                StringBuilder sbContent = new StringBuilder();

                if (subject != string.Empty)
                    sbContent.AppendFormat("{0} {1}: {2}\r\n", DateTime.Now.ToUniversalTime().ToString(), logType.ToString(), subject);

                if (description != string.Empty)
                    sbContent.AppendFormat("{0} {1}\r\n", DateTime.Now.ToUniversalTime().ToString(), description);

                if (exception != string.Empty)
                    sbContent.AppendFormat("{0} {1} \r\n", DateTime.Now.ToUniversalTime().ToString(), exception);

                sbContent.AppendLine();

                LogIntoFile(logType, sbContent.ToString());
            }
            catch
            {

            }
        }

        private static void LogIntoFile(LogType logType, string message)
        {
            StreamWriter eventFile = null;
            try
            {
                DateTime now = DateTime.Now.ToUniversalTime();

                string logFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log", now.ToString("yyyy-MM").ToString());

                if (!Directory.Exists(logFolder))
                {
                    Directory.CreateDirectory(logFolder);
                }

                string logSuffix = (logType == LogType.Error ? "_debug.txt" : "_action.txt");
                string logPath = Path.Combine(logFolder, now.ToString("yyyyMMdd").ToString() + logSuffix);

                eventFile = new StreamWriter(logPath, true);
                eventFile.Write(message);
                eventFile.Flush();
            }
            catch
            {
            }
            finally
            {
                if (eventFile != null) { eventFile.Close(); eventFile = null; }
            }
        }
    }

    public enum LogType
    {
        Info,
        Warning,
        Error,
        Record,
    }
}
