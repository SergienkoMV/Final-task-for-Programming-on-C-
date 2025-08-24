using System;
using FinalTask.Utils;

namespace FinalTask.Game.Games
{
    class DiceGame : CasinoGameBase
    {
        private int _maxValue;
        private int _minValue;
        public int MaxValue => _maxValue;
        public int MinValue => _minValue;
        //public int _dicesQuantity;
        Dice[] dices;

        public DiceGame(int quantity, int minValue, int maxValue) : base(quantity)
        {
            //FactoryMethod(quantity);
            _maxValue = minValue;
            _minValue = maxValue;
            
        }

        public override void PlayGame()
        {
            Console.WriteLine("Dice");
            foreach (Dice dice in dices)
            {
                Console.WriteLine(dice);
            }
        }

        public override void ResultOutpu()
        {
            throw new NotImplementedException();
        }

        protected override void FactoryMethod(int _dicesQuantity)
        {
            Dice[] dices = new Dice[_dicesQuantity];
            for (int i = 0; i < _dicesQuantity; i++)
            {
                dices[i] = new Dice(MinValue, MaxValue);
            }
        }

        //protected override void FactoryMethod(int _quantity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
