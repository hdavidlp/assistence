
using AutoMapper;
using DBAssistance.BussinesLayer.Dto;
using DBAssistance.DataLayer.Entities;


namespace DBAssistance.BussinesLayer.Utilities
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Period, PeriodDto>();
            CreateMap<PeriodDto,Period>();
        }
    }
}
