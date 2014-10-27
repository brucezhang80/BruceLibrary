﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BruceLibrary.Converters
{
    class Converter
    {
        #region Init
        public static Converter Current = new Converter();
        private Converter()
        {
            
        }
        #endregion

        #region Converters
                public static Log4NetHelper Log
        {
            get { return Log4NetHelper.Current; }
        }
        #endregion
    }
}
