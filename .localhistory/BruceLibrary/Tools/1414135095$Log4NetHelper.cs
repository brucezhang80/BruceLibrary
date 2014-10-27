using System;
using System.Collections.Generic;
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

        //public ILog Entity
        //{
        //    get { return _log; }
        //}

    }
}
