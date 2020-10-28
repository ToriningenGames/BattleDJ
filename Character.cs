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
        private Random random;
        private string name;
        private string source;
        private int health;
        
        private List<Card> deck;

        private List<Card> hand;
        public int HandSize 
        { get; set; }
        
        public int Health 
        { get => this.health; }

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
            this.random = new Random();
            this.name = name;
            this.source = source;
            this.health = health;
            this.deck = deck;
            this.MaxHealth = health;
            this.GetImage = new Image
            {
                Source = new BitmapImage(new Uri(this.source, UriKind.Relative))
            };
        }

        public void DealHand()
        {
            for (int i = 0; i < this.HandSize; i++)
            {
                this.hand.Add(this.deck[this.random.Next(0, this.deck.Count)]);
            }
        }

        public void PlayCard(int cardIndex)
        {
            this.hand.RemoveAt(cardIndex);
            if (this.hand.Count == 0)
            {
                DealHand();
            }
        }
    }
}
