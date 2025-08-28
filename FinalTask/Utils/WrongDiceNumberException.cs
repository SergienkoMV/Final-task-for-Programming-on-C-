using System;

namespace FinalTask.Utils
{
    class WrongDiceNumberException : Exception
    {
        public int Value { get; }

        public WrongDiceNumberException(string message, int val) : base(message) 
        {
            Value = val;
        }
    }
}
