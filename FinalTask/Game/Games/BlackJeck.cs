using System;
using System.Collections.Generic;
using FinalTask.Utils;

namespace FinalTask.Game.Games
{
    class BlackJeck : CasinoGameBase
    {
        public event Action OnWin;
        public event Action OnLoose;
        public event Action OnDraw;
        
        int playerScore = 0;
        int casinoScore = 0;

        private Stack<Card> _deck = new Stack<Card>();
        List<Card> deckList = new List<Card>();
        List<Card> copyDeck = new List<Card>();
        Queue<Card> playerHand = new Queue<Card>();
        Queue<Card> casinoHand = new Queue<Card>();


        public BlackJeck(int[] values) : base(values)
        {

        }

        public override void PlayGame()
        {
            Console.WriteLine("We are plaing in BlackJeck.");
            Console.WriteLine("Shuffling cards.");
            Shuffle();
            Console.WriteLine("Take cards please.");

            playerHand.Enqueue(_deck.Pop());
            playerHand.Enqueue(_deck.Pop());
            casinoHand.Enqueue(_deck.Pop());
            casinoHand.Enqueue(_deck.Pop());

            Console.WriteLine("Player's cards:");
            foreach (Card card in playerHand)
            {
                Console.WriteLine(" * {0} {1}", card.Suit, card.Value);
            }

            Console.WriteLine("Casino's cards:");
            foreach (Card card in casinoHand)
            {
                Console.WriteLine(" * {0} {1}", card.Suit, card.Value);
            }
        }

        protected override void FactoryMethod(int[] cardsQuantity)
        {
            for (int i = 0; i < Enum.GetNames(typeof(CardSuits)).Length; i++)
            {
                for (int j = 0; j < Enum.GetNames(typeof(CardValues)).Length; j++)
                {
                    var iSuit = (CardSuits)Enum.GetValues(typeof(CardSuits)).GetValue(i);
                    var jValue = (CardValues)Enum.GetValues(typeof(CardValues)).GetValue(j);

                    deckList.Add(new Card(iSuit, jValue));                    
                    if (deckList.Count > cardsQuantity[0])
                    {
                        break;
                    }
                }
            }
        }

        private void Shuffle()
        {
            Random rundom = new Random();
            foreach(Card card in deckList)
            {
                copyDeck.Add(card);
            }

            for (int i = 0; i < deckList.Count; i++)
            {
                int value = rundom.Next(0, copyDeck.Count);
                _deck.Push(copyDeck[value]);
                copyDeck.Remove(copyDeck[value]);
            }
        }

        public override void ResultOutpu()
        {
            int summ = 0;
            playerScore = 0;
            casinoScore = 0;

            do
            {
                while (playerHand.Count > 0)
                {
                    var card = playerHand.Dequeue();
                    playerScore += (int)card.Value;                
                }
                Console.WriteLine("Player's score: {0}", playerScore);

                while (casinoHand.Count > 0)
                {
                    var card = casinoHand.Dequeue();
                    casinoScore += (int)card.Value;
                }
                Console.WriteLine("Casino's score: {0}", casinoScore);

                if (playerScore <= 21 && (casinoScore > 21 || playerScore > casinoScore))
                {
                    OnWinInvoke();
                    break;
                }
                else if (casinoScore <= 21 && (playerScore > 21 || playerScore < casinoScore))
                {
                    OnLooseInvoke();
                    break;
                }
                else if (playerScore >= 21 && casinoScore >= 21)
                {
                    OnDrawInvoke();
                    break;
                }
                else
                {
                    Console.WriteLine("Extra cards:");
                    playerHand.Enqueue(_deck.Pop());
                    casinoHand.Enqueue(_deck.Pop());
                }
            } while (true);
        }
    }
}
