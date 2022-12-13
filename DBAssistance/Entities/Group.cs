using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.Entities
{
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  GroupID { get; set; }
        public string Name { get; set; }

        [ForeignKey("PeriodID")]
        public int PeriodID { get; set; }
        public Period Period { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
