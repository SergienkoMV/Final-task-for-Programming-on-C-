using System;
using System.Collections.Generic;
using FinalTask.Utils;

namespace FinalTask.Game.Games
{
    //public delegate int Result(int sum);
    //public delegate int OnLoose(int sum);
    //public delegate int OnDraw(int sum);

    class BlackJeck : CasinoGameBase
    {
        public event Result OnWin;
        public event Result OnLoose;
        public event Result OnDraw;


        List<Card> deckList = new List<Card>(); //Карты сохраняются в список
        List<Card> copyDeck = new List<Card>();
        Stack<Card> deck = new Stack<Card>(); //3.	Приватное поле типа Queue<Card> с названием Deck.
        Queue<Card> playerHand = new Queue<Card>();
        Queue<Card> casinoHand = new Queue<Card>();
        //private Queue<Card> _deck; //по ТЗ должно быть Deck, но в соответствии с нотацией, должно быть _deck, так как поле приватное.
        int playerScore = 0;
        int casinoScore = 0;

        //public void OutResult(int param1)
        //{
        //    if (OnWin != null)
        //    {
        //        Console.WriteLine(OnWin.Invoke(param1));
        //    }
        //    else if(OnLoose != null)
        //    {
        //        Console.WriteLine(OnLoose.Invoke(param1));
        //    }
        //    else if (OnDraw != null)
        //    {
        //        Console.WriteLine(OnDraw.Invoke(param1));
        //    }
        //}

        public BlackJeck(int _quantity) : base(_quantity)
        {
            //FactoryMethod(_quantity); //уже вызывается в наследуемом классе через base.
        }

        public override void PlayGame()
        {
            Console.WriteLine("We are plaing in BlackJeck.");
            Console.WriteLine("Shuffling cards.");
            Shuffle();
            Console.WriteLine("Take cards please.");

            //Получаем значение по случайному индексу и удаляем его из списка, далее по данному значению берем карту из колоды и добавляем ее в игровую колоду.
            //Таким образом получаем перемешанную колоду.

            //5.	Реализация механики должна быть максимально простой: сначала выдаётся две карты пользователя, затем две карты компьютера
            playerHand.Enqueue(deck.Pop());
            playerHand.Enqueue(deck.Pop());
            casinoHand.Enqueue(deck.Pop());
            casinoHand.Enqueue(deck.Pop());

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

            //Сравниваем результат
            //Объявляем победителя
            //ResultOutpu();

            //while (OnWin == null && OnLoose == null && OnDraw == null)
            //{
            //    playerHand.Enqueue(gameDeck.Pop());
            //    casinoHand.Enqueue(gameDeck.Pop());

            //}
            //Если игрок победил добавляем сумму из банка

        }

        //protected override void OnWinInvoke(int param)
        //{
        //    Console.WriteLine(" *** Player win ***");
        //    if (OnWin)
        //    OutResult(param);
        //}

        //protected override void OnLooseInvoke(int param)
        //{
        //    Console.WriteLine(" *** Casino win ***");
        //}

        //protected override void OnDrawInvoke(int param)
        //{
        //    Console.WriteLine(" *** There is no winner ***");
        //}

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

                    deckList.Add(new Card(iSuit, jValue));                    
                    if (deckList.Count > cardsQuantity)
                    {
                        break;
                    }
                }
            }
            
            for(int i = 0; i < deckList.Count; i++)
            {
                Console.WriteLine(deckList[i].Suit + " " +  deckList[i].Value);
            }
        }

        //public override void MakeBet()
        //{
        //    throw new NotImplementedException();
        //}

        //4.	Приватный метод Shuffle. Перетасовывает карты в случайном порядке и добавляет их в очередь.
        private void Shuffle()
        {
            Random rundom = new Random();
            //Создадим список с числами от 1 до _quantity
            //copyDeck = deckList;
            foreach(Card card in deckList)
            {
                copyDeck.Add(card);
            }

            for (int i = 0; i < deckList.Count; i++)
            {
                int value = rundom.Next(0, copyDeck.Count);
                deck.Push(copyDeck[value]);
                copyDeck.Remove(copyDeck[value]);
            }
        }

        //6.	Должна быть реализация вывода результатов игры в консоль.
        public override void ResultOutpu()
        {
            int summ = 0;
            playerScore = 0;
            casinoScore = 0;

            //Подсчёт очков - такой же, как в классическом блэкджеке.
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

                    //base.OnWin += PlayerWin;
                    //summ = bank/2;
                    break;
                }
                else if (casinoScore <= 21 && (playerScore > 21 || playerScore < casinoScore))
                {
                    OnLooseInvoke();
                    //base.OnLoose += CasinoWin;
                    //summ = -bank/2;
                    break;
                }
                else if ((playerScore >= 21 && casinoScore >= 21) /*|| ((playerScore == casinoScore) && playerScore > 15)*/)
                {
                    OnDrawInvoke();
                    //base.OnDraw += NoWinner;
                    //summ = 0;
                    break;
                }
                else //a.	Количество очков одинаковое и меньше 21 - ещё по одной карте
                {
                    Console.WriteLine("Extra cards:");
                    playerHand.Enqueue(deck.Pop());
                    casinoHand.Enqueue(deck.Pop());
                }
            } while (true);


            //base.OnWin -= PlayerWin;
            //base.OnLoose -= CasinoWin;
            //base.OnDraw -= NoWinner;

            //return summ;

            //else if(playerScore == 21)
            //{
            //    Console.WriteLine(" *** There is no winner ***");
            //    OnDrawInvoke();
            //}
            //else
            //{
            //    do
            //    {
            //        //реализовать раздачу карт, если у игроков одинаковое количество очков и не превышает 15 (так как если 16 + 6 (минимальное значение в колоде, то будет >21)
            //    } while (true);
            //}
            //throw new NotImplementedException();
        }
        //сделать нормальный вовд результата по событию



        //public void PlayerWin(int param)
        //{
        //    Console.WriteLine(" *** Player win ***");
        //    Console.WriteLine(" *** Player get bank: {0}$ ***", param);
        //}
        //public static void CasinoWin(int param)
        //{
        //    Console.WriteLine(" *** Casino win ***");
        //    Console.WriteLine(" *** Player loose bet: {0}$ ***", param/2);
        //}
        //public static void NoWinner(int param)
        //{
        //    Console.WriteLine(" *** No winner ***");
        //    Console.WriteLine(" *** Player return bet: {0}$ ***", param / 2);
        //}
    }
}
