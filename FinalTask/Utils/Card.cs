namespace FinalTask.Utils
{
    struct Card
    {
        private CardSuits _suit;
        private CardValues _value;

        public Card(CardSuits suit, CardValues value)
        {
            _suit = suit;
            _value = value;
        }

        public CardSuits Suit { get { return _suit; } }
        public CardValues Value { get { return _value; } }
        //public readonly string Suit => _suit; //readonly недоступно для C# 7.3, требуется версия не ниже 8.0
    }
}
