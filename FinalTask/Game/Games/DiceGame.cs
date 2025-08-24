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

        public DiceGame(int[] values) : base(values)
        {
            //FactoryMethod(quantity);
            _maxValue = values[1];
            _minValue = values[2];
            
        }

        public override void PlayGame()
        {
            Console.WriteLine("Dice");
            foreach (Dice dice in dices)
            {
                Console.WriteLine(dice);
            }
        }

        public override int ResultOutpu(int bank)
        {
            throw new NotImplementedException();
        }

        protected override void FactoryMethod(int[] values)
        {
            Dice[] dices = new Dice[values[0]];
            for (int i = 0; i < dices.Length; i++)
            {
                dices[i] = new Dice(values[1], values[2]);
            }
        }

        //protected override void FactoryMethod(int _quantity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
