using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Utilities.messenger
{
    public class InvalidTimeMessage : IInformationMetaData
    {
        public string Description { get; set; }
        public int Token  { get; set; }

        public InvalidTimeMessage(string option)
        {
            Description = $"The Time introduce ({option}) is not in format expected 24hrs ej: 10:52";
            Token = 100;
        }
    }
}
