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
        private int height;
        private List<Card> defaultCards;

        public Label GetLabel
        { get;  }

        public Image GetImage
        { get; }

        public string Name
        { get => this.name; }

        public Character(
            string name,
            string source,
            int health,
            int height,
            List<Card> defaultCards)
        {
            this.name = name;
            this.source = source;
            this.health = health;
            this.height = height;
            this.defaultCards = defaultCards;

            this.GetImage = new Image
            {
                VerticalAlignment = VerticalAlignment.Center,
                Height = this.height,
                Source = new BitmapImage(new Uri(this.source, UriKind.Relative)),
                Margin = new Thickness(50, 0, 50, 0)
            };

            this.GetLabel = new Label();
            this.GetLabel.FontSize = 20;
            this.GetLabel.Margin = new Thickness(20, 10, 20, 10);
            this.GetLabel.VerticalAlignment = VerticalAlignment.Top;

        }
    }
}
