using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAssistance.BussinesLayer.Utilities.messenger.MessageMetaData;

namespace DBAssistance.BussinesLayer.Utilities.messenger.TimetableMessages
{
    public class TimetableCreatedMessage : Message, IInformationMetaData
    {
        public TimetableCreatedMessage() : base(
            "Timetable detail succesful insert",
            0)
        {
        }
    }
}
