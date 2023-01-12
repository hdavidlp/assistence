using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAssistance.BussinesLayer.Services.TimetableService.TimetableValidator;

namespace DBAssistance.BussinesLayer.Services.TimetableService.TimetableKeySuggest
{
    public class TimetableKeyHelper : ITimetableKeyHelper
    {
        private ITimetableRules _timetableRules;
        private int _keySuggested = -1;

        public ITimetableRules PeriodValidator
        {
            get { return _timetableRules; }
        }

        private IPeriodBetweenHours PeriodDefined
        {
            get { return _timetableRules.PeriodBetweenHours; }
        }

        public int keySuggest()
        {
            return _keySuggested;
        }

        private void PrepareKeySuggest()
        {
            _keySuggested = -1;
            if (PeriodValidator.IsValidTimeTable) 
                _keySuggested = PeriodDefined.MilitaryFormat();
        }

        public TimetableKeyHelper(IPeriodBetweenHours period)
        {
            _timetableRules = new TimetableRules(period);
            PrepareKeySuggest();
        }

    }
}
