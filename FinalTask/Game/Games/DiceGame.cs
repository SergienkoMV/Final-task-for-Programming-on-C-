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
        Dice[] dices;
        int[] PlayerResult;
        int[] CasinoResult;

        public DiceGame(int[] values) : base(values)
        {

        }

        protected override void FactoryMethod(int[] values)
        {
            dices = new Dice[values[0]];
            for (int i = 0; i < dices.Length; i++)
            {
                try
                {
                    dices[i] = new Dice(values[1], values[2]);
                }
                catch (WrongDiceNumberException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public override void PlayGame()
        {
            Console.WriteLine("Player try");
            PlayerResult = new int[dices.Length];
            for (int i = 0; i < dices.Length; i++)
            {
                PlayerResult[i] = dices[i].Number;
                Console.WriteLine(PlayerResult[i]);
            }

            Console.WriteLine("Casino try");
            CasinoResult = new int[dices.Length];
            for (int i = 0; i < dices.Length; i++)
            {
                CasinoResult[i] = dices[i].Number;
                Console.WriteLine(CasinoResult[i]);
            }
        }

        public override void ResultOutpu()
        {
            int playerScore = 0;
            foreach (int dice in PlayerResult)
            {
                playerScore += dice;
            }
            Console.WriteLine($"Player score is: {playerScore}");

            int casinoScore = 0;
            foreach (int dice in CasinoResult)
            {
                casinoScore += dice;
            }
            Console.WriteLine($"Casino score is: {casinoScore}");

            if (playerScore > casinoScore)
            {
                OnWinInvoke();
            }
            else if (playerScore < casinoScore)
            {
                OnLooseInvoke();
            }
            else
            {
                OnDrawInvoke();
            }
        }
    }
}
