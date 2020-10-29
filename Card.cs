namespace ScorpCamp
{
    public class Card
    {
        private string name;
        private string source;


        public string Source
        { get => this.source; }

        public string Name
        { get => this.name; }

        public Card(
            string name,
            string source
        ) {
            this.name = name;
            this.source = source;
        }

        public virtual int GetDamage()
        {
            return 0;
        }
    }

}
