using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAssistance.BussinesLayer.Utilities.messenger.MessageMetaData;

namespace DBAssistance.BussinesLayer.Utilities.messenger.TimetableMessages
{
    public class InvalidTimeMessage : Message, IInformationMetaData
    {
        public InvalidTimeMessage(string option) :
            base($"The Time introduce ({option}) is not in format expected 24hrs ej: 10:52",
                100)
        {

        }

    }
}
