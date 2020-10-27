using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace ScorpCamp
{
    public partial class MainWindow : Window
    {

        private List<Character> playerCharas;
        private List<Character> enemyCharas;
        private int playerIndex = 0;
        private int enemyIndex = 1;

        private Boolean isEnemy = false;

        public MainWindow()
        {
            rnd = new Random();

            currentSelector = 0;

            InitializeComponent();

            this.playerCharas = GetCharacters();
            this.enemyCharas = GetCharacters();

            giveCards();
            CombatantSelectionStage();
            //ResetCombat();
            //endStage(1);
        }

        public void CombatantSelectionStage()
        {
            GameArea.Children.Clear();
            ImageBrush imbrsh = new ImageBrush();
            imbrsh.ImageSource = sourceThis("Sentry.jpg");
            GameArea.Background = imbrsh;

            Button select = new Button
            {
                Content = "Next Character",
                FontSize = 30,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            select.Click += SelectCharacter;
            GameArea.Children.Add(select);

            Label name = new Label
            {
                Content = this.playerCharas[this.playerIndex].Name,
                Background = Brushes.Gray,
                BorderBrush = Brushes.Blue,
                BorderThickness = new Thickness(5),
                FontSize = 40,
                Margin = new Thickness(100),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
            };
            GameArea.Children.Add(name);

            Button thisOne = new Button
            {
                Content = "Toggle b/w player and enemy",
                FontSize = 30,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 500, 0, 0),
            };
            thisOne.Click += ToggleCharacterSelect;
            GameArea.Children.Add(thisOne);

            Button playButton = new Button
            {
                Content = "Play",
                FontSize = 30,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 550, 0, 0),
            };
            playButton.Click += PlayGame;
            GameArea.Children.Add(playButton);
            

            Label lblIndicator = new Label
            {
                Content = "^",
                FontSize = 80,
                Margin = new Thickness(150, 10, 150, 0),
                VerticalAlignment = VerticalAlignment.Bottom,
                Foreground = Brushes.Red,
            };
            if (isEnemy)
            {
                lblIndicator.HorizontalAlignment = HorizontalAlignment.Right;
            }
            else
            {
                lblIndicator.HorizontalAlignment = HorizontalAlignment.Left;
            }
            GameArea.Children.Add(lblIndicator);

            resetPlayers();

            Character combantant1 = this.playerCharas[this.playerIndex];
            Image playerImage = combantant1.GetImage;
            playerImage.FlowDirection = FlowDirection.RightToLeft;
            playerImage.HorizontalAlignment = HorizontalAlignment.Left;
            if (this.isEnemy)
            {
                playerImage.Opacity = 0.7;
            }
            else
            {
                playerImage.Opacity = 1.0;
            }

            GameArea.Children.Add(playerImage);


            Character enemyChara = this.enemyCharas[this.enemyIndex];
            Image enemyImage = enemyChara.GetImage;
            enemyImage.HorizontalAlignment = HorizontalAlignment.Right;
            if (this.isEnemy)
            {
                enemyImage.Opacity = 1.0;
            }
            else
            {
                enemyImage.Opacity = 0.7;
            }

            GameArea.Children.Add(enemyImage);

            newHand();
        }


        public void endStage(int winner)
        {
            GameArea.Children.Clear();
            ImageBrush imbrsh = new ImageBrush();
            imbrsh.ImageSource = sourceThis("Sentry.jpg");
            GameArea.Background = imbrsh;

            Label lbl = new Label
            {
                FontSize = 50,
                Foreground = Brushes.Red,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Content = string.Format("{0} Won!", Combatant.presets[players[winner - 1]].name),
            };
            GameArea.Children.Add(lbl);

            Button btn = new Button
            {
                Width = 90,
                Height = 60,
                Content = "Reset",
                Background = Brushes.Chocolate,
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(40, 40, 40, 40),
            };
            btn.Click += buttonClick;
            GameArea.Children.Add(btn);

            if (winner == 1)
            {
                unlock();
            }
        }

        public BitmapImage sourceThis(string arg)
        {
            Uri src = new Uri(arg, UriKind.Relative);
            return new BitmapImage(src);
        }


        public Image flipImage(Image arg)
        {
            arg.FlowDirection = FlowDirection.RightToLeft;
            return arg;
        }

        public Combatant newCombatant(Combatant.Preset preset, HorizontalAlignment side)
        {
            Combatant rtrn = new Combatant();

            Image img = new Image
            {
                //img.Name = name;
                HorizontalAlignment = side,
                VerticalAlignment = VerticalAlignment.Center,
                Height = preset.height,
                Source = sourceThis(preset.source),
                Margin = PLAYERMARGIN
            };

            Label lbl = new Label();
            lbl.HorizontalAlignment = side;
            //lbl.Content = name + " " + health + "/" + health;
            lbl.Name = lbl.HorizontalAlignment.ToString();
            //lbl.VerticalAlignment = VerticalAlignment.Top;
            lbl.FontSize = 20;
            lbl.Margin = new Thickness(20, 10, 20, 10);


            rtrn.Name = preset.name;
            rtrn.lbl = lbl;
            rtrn.pic = img;
            rtrn.health = new int[] { preset.health, preset.health };
            rtrn.character = preset.character;
            return rtrn;
        }
    }
}
