
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAssistance.BussinesLayer.Repositories.PeriodRepository;
using DBAssistance.BussinesLayer.Dto;
using DBAssistance.DataLayer.Entities;


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

        public IEnumerable<DataLayer.Entities.Period> Get()
        {
            return _periodRepository.Get();
        }

        public IEnumerable<PeriodDto> extra()
        {
            var periods = _periodRepository.Get();
            return _mapper.Map<IEnumerable<PeriodDto>>(periods);
        }
    }
}
