using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStructure.Utils
{
    public static class Extionstion
    {
        public static string ToDateFormat(this DateTime source,string format)
        { 
            return source.ToShortDateString();
        }
    }
}
