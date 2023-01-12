using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Services.TimetableService.TimetableValidator
{
    public class MilitaryHour
    {
        private IHour24 _hourProposed;

        public string Hour24Format
        { 
            get { return _hourProposed.TimeProposed; } 
        }

        public string ToMilitaryFormatStr()
        {
            
            string hh = _hourProposed.TimeProposed
                .Substring(0, _hourProposed.TimeProposed.IndexOf(":"));
            string mm = _hourProposed.TimeProposed
                .Substring(_hourProposed.TimeProposed.IndexOf(":") + 1, 2);

            return hh + mm;
            
        }

        public int ToMilitaryFormatInt
        {
            get
            {
                return Convert.ToInt32(ToMilitaryFormatStr());
            }
        }

        public MilitaryHour(IHour24 hour)
        {
            _hourProposed = hour;
        }
    }
}
