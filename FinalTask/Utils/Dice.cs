using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Utils
{
    class Dice
    {
        private int _min;
        private int _max;

        public Dice(int min, int max)
        {
            _min = min;
            _max = max;
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
