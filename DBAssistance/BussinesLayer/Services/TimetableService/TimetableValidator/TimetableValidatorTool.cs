using DBAssistance.BussinesLayer.Repositories.TimetableRepository;
using DBAssistance.BussinesLayer.Services.TimetableService.TimetableKeySuggest;
using DBAssistance.BussinesLayer.Utilities.messenger.MessageMetaData;
using DBAssistance.BussinesLayer.Utilities.messenger.TimetableMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Services.TimetableService.TimetableValidator
{
    public class TimetableValidatorTool : ITimetableValidatorTool
    {
        private ITimetableKeyHelper _timetableKeyHelper;
        private readonly ITimetableRepository _timetableRepository;
        private bool _isValidTimetable = false;
        private ICollection<IInformationMetaData> _infoOperation = new List<IInformationMetaData>();
        private int _keyIdSuggest = -1;

        public TimetableValidatorTool(ITimetableRepository timetableRepository)
        {
            _timetableRepository = timetableRepository ??
                throw new ArgumentNullException(nameof(timetableRepository));

        }

        private ICollection<IInformationMetaData> addInfoOperation(
            IInformationMetaData message)
        {
            _infoOperation.Add(message);
            return _infoOperation;
        }

        private void ValidateTimeTable()
        {
            _isValidTimetable = true;
            if (!_timetableKeyHelper.PeriodValidator.IsValidTimeTable)
            {
                _isValidTimetable = false;
                _infoOperation = _timetableKeyHelper.PeriodValidator.Information();
            }

        }

        public int KeyIdSuggest
        {
            get { return _keyIdSuggest; }
        }

        public async Task<bool> ValidateKeySuggested()
        {
            if (_isValidTimetable)
            {
                _keyIdSuggest = _timetableKeyHelper.keySuggest();

                if (await _timetableRepository.TimetableKeyExistAsync(KeyIdSuggest))
                {
                    _isValidTimetable = false;
                    addInfoOperation(new KeyIdExistMessage());
                }
            }
            return true;
        }

        public async Task< (bool, ICollection<IInformationMetaData>)> IsValidPeriodAndTimeTable(IPeriodBetweenHours period)
        {

            _timetableKeyHelper = new TimetableKeyHelper(period);

            ValidateTimeTable();
            await ValidateKeySuggested();

            return (_isValidTimetable, _infoOperation);
        }






    }
}
