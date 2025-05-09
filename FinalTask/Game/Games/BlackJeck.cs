using System;
using System.Collections.Generic;

namespace FinalTask.Game.Games
{
    class BlackJeck : CasinoGameBase
    {
        public BlackJeck(int cardQuantity)
        {
            FactoryMethod();
        }

        public override void PlayGame()
        {
            Console.WriteLine("BlackJeck");
        }

        protected override void FactoryMethod()
        {
            //2.	Реализация FactoryMethod. Процесс создания карт - на усмотрение разработчика. Карты сохраняются в список.
            List <string> deck = new List<string>();
        }
    }
}
