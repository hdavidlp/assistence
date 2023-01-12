using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Services.TimetableService.TimetableValidator
{
    public class Hour24 :  IHour24
    {
        private bool _isValidTime = false;
        private string _timeProposed = "";

        public Hour24(string time)
        {
            _timeProposed = time;
            _isValidTime = test24FormatHour(time);
        }

        public bool IsValidTime
        {
            get { return _isValidTime; }
        }

        public string TimeProposed
        {
            get { return _timeProposed; }
        }


        public string Description
        {
            get
            {
                return $"{_timeProposed} is {(IsValidTime ? "" : "not")} valid";
            }
        }

        public string Hour24Format
        {
            get { return _timeProposed; }
        }

        public string ToMilitaryFormatStr()
        {
            return new MilitaryHour(
                new Hour24(TimeProposed)).ToMilitaryFormatStr();
        }

        public int ToMilitaryFormatInt()
        {
            return new MilitaryHour(
                new Hour24(TimeProposed)).ToMilitaryFormatInt;
            
        }

        private bool testMatch(string data, string pattern)
        {
            return Regex.IsMatch(data, pattern);
        }

        private bool test24FormatHour(string data)
        {
            return testMatch(data, @"^([01]?[0-9]|2[0-3]):[0-5][0-9]");
        }
    }
}
