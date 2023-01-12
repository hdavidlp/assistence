using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Utilities.messenger.MessageMetaData
{
    public class Message
    {
        public int Token { get; set; }
        public string Description { get; set; }

        public Message(string description, int token)
        {
            Description = description;
            Token = token;
        }
    }
}
