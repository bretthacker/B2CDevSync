using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace B2CDevSync.Utils
{
    public static class Logging
    {
        /// <summary>
        /// Writes an error entry to the Application log, Application Source. This is a fallback error writing mechanism.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="errorType">Type of error.</param>
        /// <param name="ex">Original exception (optional)</param>
        public static string WriteToAppLog(string message, EventLogEntryType errorType, Exception ex = null)
        {
            message = GetErrorMessageString(message, ex);
            EventLog.WriteEntry("Application", message, errorType, 0);
            return message;
        }

        public static string GetErrorMessageString(string message, Exception ex = null)
        {
            if (ex != null)
            {
                message += message + " (original error: " + ex.Source + "/" + ex.Message + "\r\nStack Trace: " +
                                ex.StackTrace + ")";
                if (ex.InnerException != null)
                {
                    message += "\r\nInner Exception: " + ex.GetBaseException();
                }
            }
            return message;
        }
    }
}
