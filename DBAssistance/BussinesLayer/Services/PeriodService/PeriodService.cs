﻿
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAssistance.BussinesLayer.Repositories.PeriodRepository;
using DBAssistance.DataLayer.Entities;
using DBAssistance.BussinesLayer.Dto.Period;

namespace DBAssistance.BussinesLayer.Services.PeriodService
{
    public class PeriodService : IPeriodService
    {
        private readonly IPeriodRepository _periodRepository;
        private readonly IMapper _mapper;
        public PeriodService(IPeriodRepository periodRepository, IMapper mapper)
        {
            _periodRepository = periodRepository;
            _mapper = mapper;   
        }

        public IEnumerable<Period> GetPeriods()
        {
            return _periodRepository.GetPeriods();
        }

        public IEnumerable<PeriodDto> GetPeriodsShortInfo()
        {
            var periods = _periodRepository.GetPeriods();
            return _mapper.Map<IEnumerable<PeriodDto>>(periods);
        }

        public PeriodDto GetPeriod(int periodId)
        {
            return _mapper.Map<PeriodDto>(_periodRepository.GetPeriodAsync(periodId));
        }

        public async Task<Period> GetPeriodAsync(int id)
        {
            return await _periodRepository.GetPeriodAsync(id);
        }

        public async Task<bool> AddPeriod(Period period)
        {
            return await _periodRepository.AddPeriod(period);
        }

        public async Task<bool> UpdatePeriod(int id, PeriodForUpdateDto period)
        {
            if (!(await _periodRepository.PeriodExistAsync(id))) return false;

            var selectedPeriod = await _periodRepository.GetPeriodAsync(id);

            _mapper.Map(period, selectedPeriod);
            return await _periodRepository.UpdatePeriod();

        }

        public async Task<bool> DeletePeriod(Period period)
        {
            return await _periodRepository.DeletePeriod(period);
        }

    }
}
