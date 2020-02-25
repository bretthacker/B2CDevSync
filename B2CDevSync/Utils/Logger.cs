using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using B2CDevSync.Utils;

namespace B2CDevSync.Utils
{
    public class Logger: IDisposable
    {
        public event EventHandler<LoggerEventArgs> LoggerMessage;
        protected virtual void OnLoggerEvent(LoggerEventArgs e)
        {
            LoggerMessage?.Invoke(this, e);
        }

        private readonly string _logPath;

        public Logger()
        {
            _logPath = Path.GetTempFileName();
        }

        public void Write(FileCopyEventArgs arg)
        {
            var s = String.Format("{0}: ({1}) {2}{3}", DateTime.Now.ToShortTimeString(), arg.Action, arg.FilePath, Environment.NewLine);
            File.AppendAllText(_logPath, s);
            OnLoggerEvent(new LoggerEventArgs
            {
                Message = s
            });
        }

        public void Write(PolicyErrorArgs arg)
        {
            var s = String.Format("{0}: ({1}) {2}{3}", DateTime.Now.ToShortTimeString(), arg.Error.Error.Code, arg.Error.Error.Message, Environment.NewLine);
            File.AppendAllText(_logPath, s);
            OnLoggerEvent(new LoggerEventArgs
            {
                Message = s
            });
        }

        public string Read()
        {
            return File.ReadAllText(_logPath);
        }

        public void Clear()
        {
            File.WriteAllText(_logPath, "");
        }

        public void Dispose()
        {
            File.Delete(_logPath);
        }
    }
    public class LoggerEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
