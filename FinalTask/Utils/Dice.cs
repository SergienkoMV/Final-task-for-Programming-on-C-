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
            if (_min < 1 || _min > _max)
            {
                //throw new WrongDiceNumberException();
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
