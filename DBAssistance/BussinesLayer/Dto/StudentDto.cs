using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Dto
{
    public  class StudentDto
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; } = "LP";
    }
}
