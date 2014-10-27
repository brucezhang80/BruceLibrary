using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BruceLibrary.Tools;

namespace BruceLibrary
{
    /// <summary>
    /// 统一调用入口
    /// </summary>
    public class Bruce
    {
        public Bruce()
        {
            
        }

        #region Utility
        public static HardwareUtility HardwareUtility
        {
            get { return HardwareUtility.Current; }
        }

        public static ProgrameUtility ProgramUtility
        {
            get { return ProgrameUtility.Current; }
        }        
        #endregion

        #region Tools

        public static AppConfigHelper AppConfig
        {
            get { return AppConfigHelper.Current; }
        }

        public static Log4NetHelper Log
        {
            get { return Log4NetHelper.Current; }
        }

        #endregion

    }
}
