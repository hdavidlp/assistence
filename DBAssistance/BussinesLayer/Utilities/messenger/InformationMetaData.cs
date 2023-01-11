using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Utilities.messenger
{
    public class InformationMetaData : IInformationMetaData
    {
        public int Token { get; set; }
        public string Description { get; set; }

        public InformationMetaData(int token, string description)
        {
            Token = token;
            Description = description;
        }

    }
}
