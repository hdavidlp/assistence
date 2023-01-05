using DBAssistance.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Dto
{
    public class GroupDto
    {
        public int GroupID { get; set; }
        public string Name { get; set; }
        public int PeriodID { get; set; }
        
    }
}
