using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using log4net;

namespace BruceLibrary.Tools
{
    public class Log4NetHelper
    {
        public static readonly Log4NetHelper Current = new Log4NetHelper();
        private ILog _log;

        private Log4NetHelper()
        {
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public string LogPosition()
        {
            try
            {
                var stackTrace = new StackTrace();
                var stackFrame = stackTrace.GetFrame(1);
                return " 位置：" + stackFrame.GetMethod().DeclaringType.Name + "[" + stackFrame.GetMethod().Name + "]\r\n";
            }
            catch
            {
                return "";
            }
        }

        public void Error(string message, Exception exception = null, bool isWirteLogPosition = false)
        {
            string logInfo = isWirteLogPosition ? (LogPosition() + message) : message;
            _log.Error(logInfo, exception);
        }
        public void Debug(string message, Exception exception = null, bool isWirteLogPosition = false)
        {
            _log.Debug(LogPosition() + message);

        }
        public void Info(string message, Exception exception = null, bool isWirteLogPosition = false)
        {
            _log.Info(message);
        }
        public void Warn(string message, Exception exception = null, bool isWirteLogPosition = false)
        {
            _log.Warn(message);
        }
    }
}
