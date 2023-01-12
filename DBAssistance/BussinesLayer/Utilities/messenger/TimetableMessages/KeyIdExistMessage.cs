using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAssistance.BussinesLayer.Utilities.messenger.MessageMetaData;

namespace DBAssistance.BussinesLayer.Utilities.messenger.TimetableMessages
{
    public class KeyIdExistMessage : Message, IInformationMetaData
    {
        public KeyIdExistMessage() : base(
            "The Start and End time introduced already exist in your record ",
            200)
        {

        }
    }
}
