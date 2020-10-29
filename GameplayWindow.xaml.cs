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
            this.DisplayAllStatus();
            this.DrawPlayerCards();
            this.DrawEnemyCards();
        }

        private void DisplayAllStatus()
        {
            this.PlayerStatusLabel.Content = gameplay.GetPlayerStatus();
            this.EnemyStatusLabel.Content = gameplay.GetEnemyStatus();
        }

        private void DrawPlayerCards()
        {
            this.PlayerCardsStackPanel.Children.Clear();
            List<Card> hand = gameplay.GetPlayerHand();
            for (int i = 0; i < hand.Count; i++)
            {
                this.AddPlayerCard(hand[i], i);
            }
        }

        private void DrawEnemyCards()
        {
            this.EnemyCardsStackPanel.Children.Clear();
            List<Card> hand = gameplay.GetEnemyHand();
            foreach (Card card in hand)
            {
                this.AddEnemyCard(card);
            }
        }

        private void AddPlayerCard(Card newCard, int cardIndex)
        {
            Button card1 = new Button();
            Image cardImage = new Image();
            cardImage.Source = new BitmapImage(new Uri(newCard.Source, UriKind.Relative));
            card1.Content = cardImage;
            card1.Width = 3 * 60;
            card1.Height = 4 * 60;
            card1.Click += OnCardSelect;
            card1.Tag = cardIndex;
            PlayerCardsStackPanel.Children.Add(card1);
        }

        private void AddEnemyCard(Card newCard)
        {
            Button card1 = new Button();
            Image cardImage = new Image();
            cardImage.Source = new BitmapImage(new Uri(@".\card-back-ii.jpg", UriKind.Relative));
            card1.Content = cardImage;
            card1.Width = 3 * 60;
            card1.Height = 4 * 60;
            EnemyCardsStackPanel.Children.Add(card1);
        }

        private void OnCardSelect(object sender, EventArgs e)
        {
            Button cardButton = (Button)sender;
            int cardIndex = (int)cardButton.Tag;
            Gameplay.WinState result = gameplay.PlayCard(cardIndex);
            if (result != Gameplay.WinState.WinnerNone)
            {
                GameOver(result);
            }
            PlayerCardsStackPanel.Children.Remove(cardButton);
            this.DisplayAllStatus();
            this.DrawPlayerCards();
            this.DrawEnemyCards();
        }

        private void GameOver(Gameplay.WinState winner)
        {
            string winMsg = "";
            switch (winner)
            {
                case Gameplay.WinState.WinnerPlayer :
                    winMsg = PlayerNameLabel.Content.ToString();
                    break;
                case Gameplay.WinState.WinnerEnemy:
                    winMsg = EnemyNameLabel.Content.ToString();
                    break;
            }
            winMsg += " won!!";
            MessageBox.Show(winMsg, "Winner!");
            this.Close();
        }
    }
}
