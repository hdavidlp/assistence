using AutoMapper;
using DBAssistance.BussinesLayer.Dto;
using DBAssistance.BussinesLayer.Repositories.StudentRepository;
using DBAssistance.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository ??
                throw new ArgumentNullException(nameof(studentRepository));
            _mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<Student> GetStudents()
        {
            return _studentRepository.GetStudents();
        }

        public IEnumerable<StudentDto> GetStudentsDto()
        {
            var students = _studentRepository.GetStudents();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public StudentDto GetStudentDto(int id)
        {
            var studentSelected = _studentRepository.GetStudent(id);
            return _mapper.Map<StudentDto>(studentSelected);    
        }
    }
}
