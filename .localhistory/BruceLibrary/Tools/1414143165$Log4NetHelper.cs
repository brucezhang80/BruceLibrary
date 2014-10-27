/*****************************************************************
 * 创建人：布鲁斯张
 * 时  间：2014-10-17
 * 描  述：日志记录类，扩展log4net
 *****************************************************************/
using System;
using System.Diagnostics;
using System.Reflection;
using log4net;

namespace BruceLibrary.Tools
{
    public class Log4NetHelper
    {
        #region Fields
        private ILog _log;
        #endregion

        #region Init
        public static readonly Log4NetHelper Current = new Log4NetHelper();
        private Log4NetHelper()
        {
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
        #endregion

        #region PrivateMethod
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string LogPosition()
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

        #region PublicMethod
        
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

        public void Fatal(string message, Exception exception = null, bool isWirteLogPosition = false)
        {
            string logInfo = isWirteLogPosition ? (LogPosition() + message) : message;
            if (exception == null)
                _log.Fatal(logInfo);
            else
                _log.Fatal(logInfo, exception);
        }
        #endregion
    }
}
