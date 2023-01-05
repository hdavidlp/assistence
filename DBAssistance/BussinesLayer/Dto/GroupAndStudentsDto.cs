using DBAssistance.BussinesLayer.Dto.Course;
using DBAssistance.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Dto
{
    public  class GroupAndStudentsDto:GroupDto
    {
        public virtual ICollection<CourseDto> Courses { get; set; }
    }
}
