using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Utilities.messenger
{
    public class TimetableCreatedMessage : IInformationMetaData
    {
        public string Description { get; set; }
        public int Token { get; set; }

        public TimetableCreatedMessage()
        {
            Description = "Timetable detail succesful insert";
            Token = 0;
        }
    }
}
