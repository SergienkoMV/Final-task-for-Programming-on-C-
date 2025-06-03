using System;

namespace FinalTask.Game.Games
{
    class Dice : CasinoGameBase
    {
        Dice(int _quantity) : base(_quantity)
        {
            FactoryMethod(_quantity);
        }

        public override void PlayGame()
        {
            Console.WriteLine("Dice");
        }

        public override void ResultOutpu()
        {
            throw new NotImplementedException();
        }

        protected override void FactoryMethod(int _dicesQuantity)
        {
            throw new NotImplementedException();
        }

        //protected override void FactoryMethod(int _quantity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
