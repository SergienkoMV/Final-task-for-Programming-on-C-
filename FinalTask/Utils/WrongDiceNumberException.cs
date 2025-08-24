using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Utils
{
    class WrongDiceNumberException : Exception
    {
        public WrongDiceNumberException(string message) : base(message) 
        { 

        }
    }
}
