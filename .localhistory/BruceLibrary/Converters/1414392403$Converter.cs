using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BruceLibrary.Converters
{
    public class Converter
    {
        #region Init
        public static Converter Current = new Converter();
        private Converter()
        {
            
        }
        #endregion

        #region Converters
        public Json Json
        {
            get { return Json; }
        }
        #endregion
    }
}
