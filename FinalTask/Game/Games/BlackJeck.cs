using System;
using System.Collections.Generic;
using FinalTask.Utils;

namespace FinalTask.Game.Games
{
    class BlackJeck : CasinoGameBase
    {

        List<Card> deck = new List<Card>(); //Карты сохраняются в список
        List<Card> copyDeck = new List<Card>();
        Stack<Card> gameDeck = new Stack<Card>();
        Queue<Card> playerHand = new Queue<Card>();
        Queue<Card> casinoHand = new Queue<Card>();
        private Queue<Card> _deck; //по ТЗ должно быть Deck, но в соответствии с нотацией, должно быть _deck, так как поле приватное.

        public BlackJeck(int _quantity) : base(_quantity)
        {
            FactoryMethod(_quantity);
        }

        public override void PlayGame()
        {
            Console.WriteLine("We are plaing in BlackJeck.");
            Console.WriteLine("Take cards please.");
            Random rundom = new Random();


            //Создадим список с числами от 1 до _quantity
            copyDeck = deck;
            for (int i = 0; i < deck.Count; i++)
            {
                int value = rundom.Next(0, copyDeck.Count);
                gameDeck.Push(copyDeck[value]);
                copyDeck.Remove(copyDeck[value]);
            }
            //Получаем значение по случайному индексу и удаляем его из списка, далее по данному значению берем карту из колоды и добавляем ее в игровую колоду.
            //Таким образом получаем перемешанную колоду.

            playerHand.Enqueue(gameDeck.Pop());
            playerHand.Enqueue(gameDeck.Pop());
            casinoHand.Enqueue(gameDeck.Pop());
            casinoHand.Enqueue(gameDeck.Pop());

            //Card[] playerHand = new Card[2];
            //for (int i = 0; i < 2; i++)
            //{
                //перед добавлением нужно проверить, чтобы не было дубля карты. Если есть, не добавлять и уменьшить индекс на 1, для еще одной итерации.
                //Вероятно надо все же создать колоду в виде стека, со случайным порядком и убирать оттуда карты взятые в руку. При новой игре должен формироваться новый стек.

                //playerHand[i] = deck[rundom.Next(0, deck.Count)];
                //playerHand[i] = gameDeck.Pop();
            //}

            //Card[] casinoHand = new Card[2];
            //for (int i = 0; i < 2; i++)
            //{
                //перед добавлением нужно проверить, чтобы не было дубля карты. Если есть, не добавлять и уменьшить индекс на 1, для еще одной итерации.
                //Вероятно надо все же создать колоду в виде стека, со случайным порядком и убирать оттуда карты взятые в руку. При новой игре должен формироваться новый стек.

                //playerHand[i] = deck[rundom.Next(0, deck.Count)];
                //casinoHand[i] = gameDeck.Pop();
            //}

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
            //Раздаем по две карты игроку и казино 
            //playerHand = deckGame.Pop();
            //casinoHand = deckGame.Pop();
            //Сравниваем результат
            //Объявляем победителя
            //ResultOutpu();
            //Если игрок победил добавляем сумму из банка

        }



        protected override void FactoryMethod(int cardsQuantity)
        {
            //2.	Реализация FactoryMethod. Процесс создания карт - на усмотрение разработчика. Карты сохраняются в список.
            //int count = 0;
            for (int i = 0; i < Enum.GetNames(typeof(CardSuits)).Length; i++)
            {
                for (int j = 0; j < Enum.GetNames(typeof(CardValues)).Length; j++)
                {
                    var iSuit = (CardSuits)Enum.GetValues(typeof(CardSuits)).GetValue(i);
                    var jValue = (CardValues)Enum.GetValues(typeof(CardValues)).GetValue(j);

                    deck.Add(new Card(iSuit, jValue));                    
                    if (deck.Count > cardsQuantity)
                    {
                        break;
                    }
                }
            }
            
            for(int i = 0; i < deck.Count; i++)
            {
                Console.WriteLine(deck[i].Suit + " " +  deck[i].Value);
            }
        }

        //public override void MakeBet()
        //{
        //    throw new NotImplementedException();
        //}

        public override void ResultOutpu()
        {
            int playerScore = 0;
            while (playerHand.Count > 0)
            {
                var card = playerHand.Dequeue();
                playerScore += (int)card.Value;                
            }
            Console.WriteLine("Player's score: {0}", playerScore);

            int casinoScore = 0;
            while (casinoHand.Count > 0)
            {
                var card = casinoHand.Dequeue();
                casinoScore += (int)card.Value;
            }
            Console.WriteLine("Casino's score: {0}", casinoScore);

            if (playerScore > casinoScore)
            {
                Console.WriteLine(" *** Player win ***");
            }
            else if(playerScore < casinoScore)
            {
                Console.WriteLine(" *** Casino win ***");
            }
            else
            {
                Console.WriteLine(" *** There is no winner ***");
            }
            //throw new NotImplementedException();
        }
    }
}
