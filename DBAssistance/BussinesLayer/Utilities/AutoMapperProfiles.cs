
using AutoMapper;
using DBAssistance.BussinesLayer.Dto;
using DBAssistance.BussinesLayer.Dto.Period;
using DBAssistance.DataLayer.Entities;


namespace DBAssistance.BussinesLayer.Utilities
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Period, PeriodDto>();
            CreateMap<Course, CourseDto>();
            CreateMap<Student, StudentDto>();
            CreateMap<Group, GroupDto>();
            CreateMap<Group, GroupAndStudentsDto>();
        }
    }
}
