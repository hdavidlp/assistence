
using AutoMapper;
using DBAssistance.BussinesLayer.Dto;
using DBAssistance.BussinesLayer.Dto.Course;
using DBAssistance.BussinesLayer.Dto.Period;
using DBAssistance.DataLayer.Entities;


namespace DBAssistance.BussinesLayer.Utilities
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Period, PeriodDto>();
            CreateMap<PeriodForCreation, Period>();
            CreateMap<Period, PeriodForCreation>();
            CreateMap<PeriodForUpdateDto, Period>();


            CreateMap<Course, CourseDto>();
            CreateMap<CourseForCreation, Course>();
            CreateMap<Course, CourseForCreation>();
            CreateMap<CourseForUpdateDto, Course>();


            CreateMap<Student, StudentDto>();
            CreateMap<Group, GroupDto>();
            CreateMap<Group, GroupAndStudentsDto>();
        }
    }
}
