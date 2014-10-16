using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public static HardwareUtility HardwareUtility
        {
            get { return HardwareUtility.Current; }
        }

        public static ProgrameUtility ProgramUtility
        {
            get { return ProgrameUtility.Current; }
        }
    }
}
