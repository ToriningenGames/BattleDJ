namespace ScorpCamp
{
    public enum CardType
    {
        Gun,
        Heal,
        Sword,
        Bow,
        MilkAtk,
        MilkHeal
    }

    public class Card
    {
        private CardType cardType;
        private string name;
        private string source;

        public CardType CardType
        { get => this.cardType; }

        public string Source
        { get => this.source; }
        
        public string Name
        { get => this.name; }

        public Card(
            CardType cardType,
            string name,
            string source)
        {
            this.cardType = cardType;
            this.name = name;
            this.source = source;
        }
    }

}
