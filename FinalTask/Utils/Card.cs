namespace FinalTask.Utils
{
    struct Card
    {
        private CardSuits _suit;
        private CardValues _value;

        public Card(CardSuits suit, CardValues value) //Исправить. 3.	Реализовать структуру Card, содержащую readonly свойства с мастью и величиной. Значения задаются через конструктор.
        {
            _suit = suit;
            _value = value;
        }

        public CardSuits Suit => _suit;
        public CardValues Value => _value;

        //public readonly string Suit => _suit; //readonly недоступно для C# 7.3, требуется версия не ниже 8.0
    }
}
