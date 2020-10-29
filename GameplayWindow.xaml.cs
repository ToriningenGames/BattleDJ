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
            Image cardImage = new Image();
            cardImage.Source = new BitmapImage(new Uri(newCard.Source, UriKind.Relative));

            Button card = CreateCardButton(cardImage);
            card.Click += OnCardSelect;
            card.Tag = cardIndex;
            PlayerCardsStackPanel.Children.Add(card);
        }

        private void AddEnemyCard(Card newCard)
        {
            Image cardImage = new Image();
            cardImage.Source = new BitmapImage(new Uri(@".\card-back-ii.jpg", UriKind.Relative));
            EnemyCardsStackPanel.Children.Add(CreateCardButton(cardImage));
        }

        private Button CreateCardButton(Image displayImage)
        {
            Button button = new Button();

            button.Content = displayImage;
            button.Width = 3 * 60;
            button.Height = 4 * 60;

            return button;
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
            string winTitle = "";
            switch (winner)
            {
                case Gameplay.WinState.WinnerPlayer :
                    winMsg = PlayerNameLabel.Content.ToString();
                    winTitle = "Player";
                    break;
                case Gameplay.WinState.WinnerEnemy:
                    winMsg = EnemyNameLabel.Content.ToString();
                    winTitle = "Enemy";
                    break;
            }
            winMsg += " won!!";
            winTitle += " is the Winner!";
            MessageBox.Show(winMsg, winTitle);
            this.Close();
        }
    }
}
