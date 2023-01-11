using DBAssistance.BussinesLayer.Repositories.TimetableRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Services.TimetableService
{
    internal class KeyBuilderForTimeTable
    {

        private string _startTime;
        private string _endTime;
        private bool _isValidStarTime = false;
        private bool _isValidEndTime = false;
        //private bool _keyIdExist = false;

        
        public string StartTime
        {
            get { return _startTime; }
        }

        public string EndTime
        {
            get { return _endTime; }
        }
        
        public bool IsValidStarTime
        {
            get { return _isValidStarTime;}
        }

        public bool IsValidEndTime
        {
            get { return _isValidEndTime; }
        }

        private bool IsStartTimeBeforeEndTime
        {
            get { 
                return Convert.ToInt32(HourToStr(_startTime)) 
                          < Convert.ToInt32(HourToStr(_endTime)); 
            }
        }

        public bool IsValidTimeTable
        {
            get { return _isValidStarTime && _isValidEndTime && IsStartTimeBeforeEndTime; }
        }

        

        private string HourToStr(string hour)
        {
            string hh = hour.Substring(0, hour.IndexOf(":"));
            string mm = hour.Substring(hour.IndexOf(":") + 1, 2);

            return hh + mm;
        }

        public int keySuggest
        {
            get {
                if (!this.IsValidTimeTable) return -1;

                string start = HourToStr(_startTime);
                string end = HourToStr(_endTime);

                return Convert.ToInt32(start+end);
            }
        }

        //public async Task<bool> IsNewKeySugess()
        //{
        //    return await _timetableRepository.TimetableKeyExistAsync(keySuggest);
        //}

        

        public KeyBuilderForTimeTable(string startTime, string endTime)
        {
            _startTime = startTime;
            _endTime = endTime;

            _isValidStarTime = TimetableValidator.test24FormatHour(_startTime);
            _isValidEndTime= TimetableValidator.test24FormatHour(_endTime);
        }

    }
}
