using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalTask.Utils;

namespace FinalTask.Utils
{
    class Dice
    {
        private int _min;
        private int _max;

        public Dice(int min, int max)
        {
            if (min < 1 || min > int.MaxValue)
            {
                throw new WrongDiceNumberException($"Incorrect min value: {_min}");
            } 
            else
            {
                _min = min;
                _max = max;
            }

        }

        public int Number
        {
            get 
            {
                Random random = new Random();
                return random.Next(_min, _max + 1);
            }
        }
    }
}
