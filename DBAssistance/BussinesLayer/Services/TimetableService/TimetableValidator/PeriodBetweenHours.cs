using DBAssistance.BussinesLayer.Utilities.messenger.TimetableMessages;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Services.TimetableService.TimetableValidator
{
    public class PeriodBetweenHours : IPeriodBetweenHours
    {
        private IHour24 _startTime;
        private IHour24 _endTime;

        public IHour24 StartTime
        {
            get { return _startTime; }
        }

        public IHour24 EndTime
        {
            get { return _endTime; }
        }

        public bool IsStartTimeBeforeEndTime()
        {
            return
                StartTime.ToMilitaryFormatInt() < EndTime.ToMilitaryFormatInt();
        }

        public int MilitaryFormat()
        {
            return Convert.ToInt32(
                StartTime.ToMilitaryFormatStr() +
                EndTime.ToMilitaryFormatStr()
                );
        }

        public PeriodBetweenHours(IHour24 startTime, IHour24 endTime)
        {
            _startTime = startTime;
            _endTime = endTime;
        }
    }
}
