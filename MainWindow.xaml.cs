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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        CharacterSelect characterSelection;
        public MainWindow()
        {
            InitializeComponent();
            this.characterSelection = new CharacterSelect();
            DrawCharacters();
        }

        private void DrawCharacters()
        {
            DisplayPlayer(characterSelection.Player);
            DisplayEnemy(characterSelection.Enemy);
        }

        private void DisplayPlayer(Character player)
        {
            PlayerNameLabel.Content = player.Name;
            PlayerImage.Source = player.GetImage.Source;
        }

        private void DisplayEnemy(Character enemy)
        {
            EnemyNameLabel.Content = enemy.Name;
            EnemyImage.Source = enemy.GetImage.Source;
        }

        private void PlayerSelectBack_Click(object sender, RoutedEventArgs e)
        {
            characterSelection.PlayerPrev();
            DrawCharacters();
        }

        private void PlayerSelectForward_Click(object sender, RoutedEventArgs e)
        {
            characterSelection.PlayerNext();
            DrawCharacters();
        }

        private void EnemySelectBack_Click(object sender, RoutedEventArgs e)
        {
            characterSelection.EnemyPrev();
            DrawCharacters();
        }

        private void EnemySelectForward_Click(object sender, RoutedEventArgs e)
        {
            characterSelection.EnemyNext();
            DrawCharacters();
        }

        private void PlayGameButton_Click(object sender, RoutedEventArgs e)
        {
            GameplayWindow gameplayWindow =
                new GameplayWindow(characterSelection.Player, characterSelection.Enemy);
            
            gameplayWindow.Owner = this;
            gameplayWindow.Show();
            this.characterSelection = new CharacterSelect();
            DrawCharacters();
        }
    }
}
