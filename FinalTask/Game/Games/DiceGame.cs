using System;
using FinalTask.Utils;

namespace FinalTask.Game.Games
{
    class DiceGame : CasinoGameBase
    {
        public override event Action OnWin;
        public override event Action OnLoose;
        public override event Action OnDraw;

        private int _diceQuantity;
        private int _maxValue;
        private int _minValue;
        public int MaxValue => _maxValue;
        public int MinValue => _minValue;
        Dice[] dices;
        int[] PlayerResult;
        int[] CasinoResult;

        public DiceGame(int diceQuantity, int minValue, int maxValue)
        {
            _diceQuantity = diceQuantity;
            _minValue = minValue;
            _maxValue = maxValue;
            FactoryMethod();
        }

        protected override void FactoryMethod()
        {
            dices = new Dice[_diceQuantity];
            for (int i = 0; i < dices.Length; i++)
            {
                try
                {
                    dices[i] = new Dice(_minValue, _maxValue);
                }
                finally
                {
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
                OnWin?.Invoke();
                //OnWinInvoke();
            }
            else if (playerScore < casinoScore)
            {
                OnLoose?.Invoke();
                //OnLooseInvoke();
            }
            else
            {
                OnDraw?.Invoke();
                //OnDrawInvoke();
            }
        }
    }
}
