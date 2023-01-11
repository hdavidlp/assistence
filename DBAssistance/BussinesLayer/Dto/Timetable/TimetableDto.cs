using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Dto.Timetable
{
    public class TimetableDto
    {
        
        public int idTimeTable { get; set; }
        public string startTime { get; set; } 
        public string endTime { get; set; }
        public string longDescription { get; set; } = "long description here";
    }
}
