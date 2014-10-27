using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BruceLibrary.Converters
{
    interface IConverter
    {
        object Convert(object objSource);
        List<T> Convert(List<T> objSource);
    }
}
