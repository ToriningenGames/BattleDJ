using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ScorpCamp
{
    /// <summary>
    /// Interaction logic for GameplayWindow.xaml
    /// </summary>
    public partial class GameplayWindow : Window
    {
        private Gameplay gameplay;


        private GameplayWindow()
        {

        }

        public GameplayWindow(
            Character player,
            Character enemy
        ) {
            InitializeComponent();
            this.gameplay = new Gameplay(player, enemy);
            this.PlayerNameLabel.Content = player.Name;
            this.EnemyNameLabel.Content = enemy.Name;
            this.PlayerImage.Source = player.GetImage.Source;
            this.EnemyImage.Source = enemy.GetImage.Source;
            this.PlayerStatusLabel.Content = gameplay.GetPlayerStatus();
            this.EnemyStatusLabel.Content = gameplay.GetEnemyStatus();
            this.AddPlayerCards();
            this.AddPlayerCards();
            this.AddPlayerCards();
            this.AddEnemyCards();
            this.AddEnemyCards();
            this.AddEnemyCards();
        }

        private void AddPlayerCards()
        {
            Button card1 = new Button();
            Image cardImage = new Image();
            cardImage.Source = new BitmapImage(new Uri(@"C:\Users\Tasslefoot\Desktop\New folder\BattleDJ\gun_card.png"));
            card1.Content = cardImage;
            //card1.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\Tasslefoot\Desktop\New folder\BattleDJ\gun_card.png")));
            card1.Width = 3 * 60;
            card1.Height = 4 * 60;
            card1.MouseEnter += OnMouseOver;
            PlayerCardsStackPanel.Children.Add(card1);
        }

        private void AddEnemyCards()
        {
            Button card1 = new Button();
            Image cardImage = new Image();
            cardImage.Source = new BitmapImage(new Uri(@"C:\Users\Tasslefoot\Desktop\New folder\BattleDJ\gun_card.png"));
            card1.Content = cardImage;
            //card1.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\Tasslefoot\Desktop\New folder\BattleDJ\gun_card.png")));
            card1.Width = 3 * 60;
            card1.Height = 4 * 60;
            card1.MouseEnter += OnMouseOver;
            EnemyCardsStackPanel.Children.Add(card1);
        }

        private void OnMouseOver(Object sender, EventArgs e)
        {
            Button button = (Button)sender;
            //button.Height = 150;
        }
    }
}
