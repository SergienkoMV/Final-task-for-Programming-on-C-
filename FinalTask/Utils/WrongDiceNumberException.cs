using System;

namespace FinalTask.Utils
{
    class WrongDiceNumberException : Exception
    {
        public WrongDiceNumberException(string message) : base(message) 
        { 

        }
    }
}
