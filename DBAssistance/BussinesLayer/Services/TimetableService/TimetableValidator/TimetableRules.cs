using DBAssistance.BussinesLayer.Utilities.messenger.MessageMetaData;
using DBAssistance.BussinesLayer.Utilities.messenger.TimetableMessages;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Services.TimetableService.TimetableValidator
{
    public class TimetableRules : ITimetableRules
    {
        private IPeriodBetweenHours _period;
        private ICollection <IInformationMetaData> _information;

        public IPeriodBetweenHours PeriodBetweenHours
        {
            get { return _period; }
        }

        public ICollection<IInformationMetaData> Information()
        {
            return _information;
        }



        private bool IsValidStartTime()
        {
            bool isValid = true;

            if (!PeriodBetweenHours.StartTime.IsValidTime)
            {
                _information.Add(new InvalidTimeMessage(PeriodBetweenHours.StartTime.TimeProposed));
                isValid = false;
            }

            return isValid;
        }

        private bool IsValidEndTime()
        {
            bool isValid = true;

            if (!PeriodBetweenHours.EndTime.IsValidTime)
            {
                _information.Add(new InvalidTimeMessage(PeriodBetweenHours.EndTime.TimeProposed));
                isValid = false;
            }

            return isValid;
        }

        private bool IsValidPeriodTime()
        {
            bool isValid = true;

            if (!PeriodBetweenHours.IsStartTimeBeforeEndTime())
            {
                _information.Add(new InvalidPeriodMessage());
                isValid = false;
            }

            return isValid;
            
        }

        public bool IsValidTimeTable
        {
            get
            {
                return
                    (IsValidStartTime() & IsValidEndTime()) &&
                    IsValidPeriodTime();
            }
        }

        public TimetableRules(IPeriodBetweenHours period)
        {
            _period = period;
            _information =  new List<IInformationMetaData>();
        }
    }
}
