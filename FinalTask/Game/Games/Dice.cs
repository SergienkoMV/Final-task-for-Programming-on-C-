using System;

namespace FinalTask.Game.Games
{
    class Dice : CasinoGameBase
    {
        Dice()
        {
            FactoryMethod();
        }

        public override void PlayGame()
        {
            Console.WriteLine("Dice");
        }

        protected override void FactoryMethod()
        {
            throw new NotImplementedException();
        }
    }
}
