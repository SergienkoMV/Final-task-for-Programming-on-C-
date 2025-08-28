using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalTask.Utils;

namespace FinalTask.Utils
{
    struct Dice
    {
        private int _min;
        private int _max;

        public Dice(int min, int max)
        {
            if (min < 1 || min > int.MaxValue)
            {
                throw new WrongDiceNumberException($"Incorrect min value:", min);
            } 
            else
            {
                _min = min;
                _max = max;
            }

        }

        //public readonly string Suit => _suit; //readonly недоступно для C# 7.3, требуется версия не ниже 8.0
        public int Number
        {
            get 
            {
                Random random = new Random();
                var value = random.Next(_min, _max + 1);
                return value;
            }
        }
    }
}
