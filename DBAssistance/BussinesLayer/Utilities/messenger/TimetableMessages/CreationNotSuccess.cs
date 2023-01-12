using DBAssistance.BussinesLayer.Utilities.messenger.MessageMetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Utilities.messenger.TimetableMessages
{
    public class CreationNotSuccess: Message, IInformationMetaData
    {
        public CreationNotSuccess(): base(
            "Creation not success",
            900)
        {

        }
    }
}
