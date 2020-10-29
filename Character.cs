using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ScorpCamp
{
    public class Character
    {
        private string name;
        private string source;
        private int health;
        
        private List<Card> deck;

        private List<Card> hand;
        public int damageBuff
        { get; set; }

        public List<Card> Hand
        { get => this.hand; }

        public int HandSize 
        { get; set; }
        
        public int Health 
        { get => this.health; set => this.health = value;  }

        public Image GetImage
        { get; }

        public string Name
        { get => this.name; }

        public int MaxHealth { get; }

        public Character(
            string name,
            string source,
            int health,
            List<Card> deck
            )
        {
            this.name = name;
            this.source = source;
            this.health = health;
            this.deck = deck;
            this.damageBuff = 0;
            this.MaxHealth = health;
            this.hand = new List<Card>();
            this.GetImage = new Image
            {
                Source = new BitmapImage(new Uri(this.source, UriKind.Relative))
            };
            DealHand();
        }

        public void DealHand()
        {
            for (int i = 0; i < this.HandSize; i++)
            {
                this.hand.Add(this.deck[RNG.random.Next(0, this.deck.Count)]);
            }
        }

        public Card PlayCard(int cardIndex)
        {
            Card playedCard = this.hand[cardIndex];
            this.hand.RemoveAt(cardIndex);
            if (this.hand.Count == 0)
            {
                DealHand();
            }
            return playedCard;
        }
    }
}
