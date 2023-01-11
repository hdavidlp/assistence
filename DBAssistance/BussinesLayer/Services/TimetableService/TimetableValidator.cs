using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Services.TimetableService
{
    public static  class TimetableValidator
    {
        public static bool testMatch(string data, string pattern)
        {
            return Regex.IsMatch(data, pattern);
        }

        public static bool test24FormatHour(string data)
        {
            return testMatch(data, @"^([01]?[0-9]|2[0-3]):[0-5][0-9]");
        }
    }
}
