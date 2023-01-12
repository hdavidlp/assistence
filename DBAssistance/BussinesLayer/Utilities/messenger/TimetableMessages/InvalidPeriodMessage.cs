using DBAssistance.BussinesLayer.Utilities.messenger.MessageMetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Utilities.messenger.TimetableMessages
{
    internal class InvalidPeriodMessage :Message, IInformationMetaData
    {
        public InvalidPeriodMessage()
            :base(
                 "The period beteen hours is not correct",
                 300)
        {

        }
        
    }
}
