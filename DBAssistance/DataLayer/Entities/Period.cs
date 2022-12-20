using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBAssistance.DataLayer.Entities
{
    public class Period
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PeriodID { get; set; }   
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public bool IsActive { get; set; }  
    }
}
