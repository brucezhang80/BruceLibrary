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
        #region Init
        private ILog _log;

        public static readonly Log4NetHelper Current = new Log4NetHelper();
        private Log4NetHelper()
        {
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
        #endregion

        #region Method
        public static string LogPosition()
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
        #endregion




        public void Error(string message, Exception exception = null, bool isWirteLogPosition = false)
        {
            string logInfo = isWirteLogPosition ? (LogPosition() + message) : message;
            if (exception == null) 
                _log.Error(logInfo); 
            else 
                _log.Error(logInfo, exception);
        }
        public void Debug(string message, Exception exception = null, bool isWirteLogPosition = false)
        {
            string logInfo = isWirteLogPosition ? (LogPosition() + message) : message;
            if (exception == null)
                _log.Debug(logInfo);
            else
                _log.Debug(logInfo, exception);
        }
        public void Info(string message, Exception exception = null, bool isWirteLogPosition = false)
        {
            string logInfo = isWirteLogPosition ? (LogPosition() + message) : message;
            if (exception == null)
                _log.Info(logInfo);
            else
                _log.Info(logInfo, exception);
        }
        public void Warn(string message, Exception exception = null, bool isWirteLogPosition = false)
        {
            string logInfo = isWirteLogPosition ? (LogPosition() + message) : message;
            if (exception == null)
                _log.Warn(logInfo);
            else
                _log.Warn(logInfo, exception);
        }
    }
}
