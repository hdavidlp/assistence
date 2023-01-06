using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Dto.Period
{
    public class PeriodForUpdateDto
    {
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public bool IsActive { get; set; }
    }
}
