using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Utilities.messenger
{
    public class KeyIdExistMessage : IInformationMetaData
    {
        public string Description { get; set; }
        public int Token {  get; set; }

        public KeyIdExistMessage()
        {
            Description = "The Start and End time introduced already exist in your record ";
            Token = 200;
          }


    }
}
