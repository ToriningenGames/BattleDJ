using System;
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
        public MainWindow()
        {
            rnd = new Random();

            currentSelector = 0;

            InitializeComponent();

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

            Button next = new Button
            {
                Content = "Next",
                FontSize = 50,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            next.Click += buttonClick;
            GameArea.Children.Add(next);

            Label name = new Label
            {
                Content = Combatant.presets[players[currentSelector]].name,
                Background = Brushes.Gray,
                BorderBrush = Brushes.Blue,
                BorderThickness = new Thickness(5),
                FontSize = 40,
                Margin = new Thickness(100),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
            };
            name.MouseDoubleClick += unlockAll;
            GameArea.Children.Add(name);

            Button thisOne = new Button
            {
                Content = "This One",
                FontSize = 30,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 500, 0, 0),
            };
            thisOne.Click += buttonClick;
            GameArea.Children.Add(thisOne);

            Button back = new Button
            {
                Content = "Back",
                FontSize = 30,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 550, 0, 0),
            };
            back.Click += buttonClick;
            if (currentSelector == 1)
            {
                GameArea.Children.Add(back);
            }

            Label lblIndicator = new Label
            {
                Content = "^",
                FontSize = 80,
                Margin = new Thickness(150, 10, 150, 0),
                VerticalAlignment = VerticalAlignment.Bottom,
                Foreground = Brushes.Red,
            };
            if (currentSelector == 0)
            {
                lblIndicator.HorizontalAlignment = HorizontalAlignment.Left;
            }
            else
            {
                lblIndicator.HorizontalAlignment = HorizontalAlignment.Right;
            }
            GameArea.Children.Add(lblIndicator);

            resetPlayers();

            Combatant cmb1 = player;
            cmb1.pic = flipImage(cmb1.pic);
            if (currentSelector == 0)
            {
                cmb1.pic.Opacity = .7;
            }

            var img = cmb1.pic;
            GameArea.Children.Add(img);

            Combatant cmb2 = enemy;
            cmb2.pic.Opacity = .7;

            img = cmb2.pic;
            GameArea.Children.Add(img);
            //resetPlayers();
            //showCombatants();

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
