using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BruceLibrary.Converters
{
    public class ConverterFade
    {
        #region Init
        public static ConverterFade Current = new ConverterFade();
        private ConverterFade()
        {
            
        }
        #endregion

        #region Converters
        public Json Json
        {
            get { return Json.Current; }
        }

        public Chinese Chinese
        {
            get { return Chinese.Current; }
        }

        public Currency Currency
        {
            get { return Currency.Current; }
        }

        public Csv Csv
        {
            get { return Csv.Current; }
        }
        #endregion
    }
}
