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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const int HUMANHEIGHT = 500;
        public const int CARDHEIGHT = 350;
        public Thickness PLAYERMARGIN = new Thickness(50, 0, 50, 0);
        public bool turn = false;
        Random rnd;
        public int currentSelector;

        //<Image x:Name="goni" HorizontalAlignment="Left" Height="463" VerticalAlignment="Top" Width="228" Source="standard.png" Margin="991,85,0,0" RenderTransformOrigin="3.292,0.792" Grid.Column="1"/>
        public class Combatant
        {
            public Image pic;
            public Label lbl;
            public string Name;
            public int[] health;
            public Card[] hand;
            public characters character;
        }

        public class Preset
        {
            public string name;
            public string source;
            public string backgroundSource;
            public int health;
            public int height;
            public Card[] deck;
            public bool playable;
            public bool fightable;
            public characters character;
        }

        Combatant player = new Combatant();
        Combatant enemy = new Combatant();

        Preset[] presets = new Preset[]
        {
            new Preset
            {
                character = characters.DrMilk,
                name = "Dr. Milk",
                source = "DrMilk.png",
                health = 50,
                height = HUMANHEIGHT-1,
                playable = true,
                fightable = false,
            },
            new Preset
            {
                character = characters.TheRatMaster,
                name = "The Rat Master",
                source = "standard.png",
                health = 55,
                height = HUMANHEIGHT,
                playable = false,
                fightable = false,
            },
            new Preset
            {
                character = characters.CrissWithAGun,
                name = "Criss With a Gun",
                source = "crisswithagun.png",
                health = 1000,
                height = HUMANHEIGHT,
                playable = false,
                fightable = false,
            },
            new Preset
            {
                character = characters.RatWizard,
                name = "Rat Wizard",
                source = "rat_wiz.png",
                health = 40,
                height = 250,
                playable = false,
                fightable = false,
            },
            new Preset
            {
                character = characters.RatGamer,
                name = "Rat Gamer",
                source = "Rat_Gamer.png",
                backgroundSource = "Library.jpg",
                health = 35,
                height = 300,
                playable = false,
                fightable = true,
            }
        };
        
        public enum characters
        {
            CrissWithAGun,
            TheRatMaster,
            DrMilk,
            RatWizard,
            RatGamer
        };

        int[] players = new int[] { 0, 0 };
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

        public bool playCard(Card c)
        {
            int h;
            switch (c.cn)
            {
                case Card.CardName.Gun:
                    h = 0;
                    if (!turn)
                    {
                        enemy.health[0] = h;
                    }
                    else
                    {
                        player.health[0] = h;
                    }
                    break;
                case Card.CardName.Heal:
                    h = 7;
                    if (!turn)
                    {
                        player.health[0] += h;
                    }
                    else
                    {
                        enemy.health[0] += h;
                    }
                    break;
                case Card.CardName.Sword:
                    h = 0 - rnd.Next(3, 8);
                    if (turn)
                    {
                        player.health[0] += h;
                    }
                    else
                    {
                        enemy.health[0] += h;
                    }
                    break;
                case Card.CardName.Bow:
                    for (int i = 0; i < 2; i += 1)
                    {
                        h = 0 - rnd.Next(2, 4);
                        if (turn)
                        {
                            player.health[0] += h;
                        }
                        else
                        {
                            enemy.health[0] += h;
                        }
                    }
                    break;
                case Card.CardName.MilkHeal:
                    h = rnd.Next(5, 11);
                    if (!turn)
                    {
                        player.health[0] += h;
                    }
                    else
                    {
                        enemy.health[0] += h;
                    }
                    break;
                case Card.CardName.MilkAtk:
                    h = 0 - rnd.Next(5, 11);
                    if (turn)
                    {
                        player.health[0] += h;
                    }
                    else
                    {
                        enemy.health[0] += h;
                    }
                    break;
            }

            var rtrn = false;

            if (enemy.health[0] <= 0)
            {
                endStage(1);
                rtrn = true;
            }
            if (player.health[0] <= 0)
            {
                endStage(2);
                rtrn = true;
            }

            return rtrn;
        }

        public Card cardById(Card.CardName arg)
        {
            Card rtrn = new Card();

            foreach (Card c in cards)
            {
                if (c.cn == arg)
                {
                    rtrn = c;
                }
            }

            return rtrn;
        }

        public void giveCards()
        {
            foreach(Preset p in presets)
            {
                switch (p.character)
                {
                    case characters.DrMilk:
                        p.deck = new Card[]
                        {
                            cardById(Card.CardName.MilkAtk),
                            cardById(Card.CardName.MilkHeal)
                        };
                        break;
                    case characters.RatWizard:
                        p.deck = new Card[]
                        {
                            cardById(Card.CardName.Heal),
                            cardById(Card.CardName.Sword),
                            cardById(Card.CardName.Bow)
                        };
                        break;
                    case characters.CrissWithAGun:
                        p.deck = new Card[]
                        {
                            cardById(Card.CardName.Gun),
                        };
                        break;
                    case characters.TheRatMaster:
                        p.deck = new Card[]
                        {
                            cardById(Card.CardName.Heal),
                            cardById(Card.CardName.Bow),
                            cardById(Card.CardName.Sword),
                        };
                        break;
                    case characters.RatGamer:
                        p.deck = new Card[]
                        {
                            cardById(Card.CardName.Heal),
                            cardById(Card.CardName.Sword),
                            cardById(Card.CardName.Bow),
                        };
                        break;
                }
            }
        }

        public void ResetCombat()
        {
            resetPlayers();
            newHand();
            battleStage();
        }

        public void attack(bool turn, int damage)
        {
            bool gameover = false;

            if (!turn)
            {
                enemy.health[0] -= damage;

                if (enemy.health[0] <= 0)
                {
                    gameover = true;
                }
            }
            else
            {
                //player.health[0] -= damage;

                if (player.health[0] <= 0)
                {
                    gameover = true;
                }
            }

            if (!gameover)
            {
                battleStage();
            }
            else
            {
                endStage(Convert.ToInt32(turn) + 1);
            }
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
                Content = presets[players[currentSelector]].name,
                Background = Brushes.Gray,
                BorderBrush = Brushes.Blue,
                BorderThickness = new Thickness(5),
                FontSize = 40,
                Margin = new Thickness(100),
                HorizontalAlignment =  HorizontalAlignment.Center,
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

        public void unlockAll(object sender, EventArgs e)
        {
            foreach (Preset p in presets)
            {
                unlockPlayable(p.character);
                unlockFightable(p.character);
            }
        }

        public void resetPlayers()
        {
            while (!presets[players[0]].playable)
            {
                players[0] += 1;
                if (players[0] >= presets.Length)
                {
                    players[0] = 0;
                }
            } 
            while (!presets[players[1]].fightable)
            {
                players[1] += 1;
                if (players[1] >= presets.Length)
                {
                    players[1] = 0;
                }
            }

            Preset p1 = presets[players[0]];
            Preset p2 = presets[players[1]];
            player = newCombatant(p1, HorizontalAlignment.Left);
            player.pic = flipImage(player.pic);
            enemy = newCombatant(p2, HorizontalAlignment.Right);
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
                Content = string.Format("{0} Won!", presets[players[winner - 1]].name),
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

        public void unlock()
        {
            switch (presets[players[1]].character)
            {
                case characters.TheRatMaster:
                    unlockPlayable(characters.TheRatMaster);
                    if (presets[players[0]].character == characters.TheRatMaster)
                    {
                        unlockPlayable(characters.CrissWithAGun);
                    }
                    break;
                case characters.RatWizard:
                    unlockFightable(characters.TheRatMaster);
                    break;
                case characters.RatGamer:
                    unlockFightable(characters.RatWizard);
                    break;
            }
        }

        public void unlockPlayable(characters arg)
        {
            foreach(Preset p in presets)
            {
                if (p.character == arg)
                {
                    p.playable = true;
                }
            }
        }

        public void unlockFightable(characters arg)
        {
            foreach (Preset p in presets)
            {
                if (p.character == arg)
                {
                    p.fightable = true;
                }
            }
        }

        public void showCombatants()
        {
            string labelFormat = "{0}\n{1}/{2}";

            Combatant cmb1 = player;
            cmb1.pic = flipImage(cmb1.pic);

            var img = cmb1.pic;
            GameArea.Children.Add(img);

            var lbl = cmb1.lbl;
            lbl.Background = Brushes.Gray;
            lbl.Content = string.Format(labelFormat, cmb1.Name, cmb1.health[0], cmb1.health[1]);
            lbl.HorizontalContentAlignment = HorizontalAlignment.Center;
            lbl.VerticalAlignment = VerticalAlignment.Top;
            GameArea.Children.Add(lbl);

            Combatant cmb2 = enemy;

            img = cmb2.pic;
            GameArea.Children.Add(img);

            lbl = cmb2.lbl;
            lbl.Background = Brushes.Gray;
            lbl.Content = string.Format(labelFormat, cmb2.Name, cmb2.health[0], cmb2.health[1]);
            lbl.HorizontalContentAlignment = HorizontalAlignment.Center;
            lbl.VerticalAlignment = VerticalAlignment.Top;
            GameArea.Children.Add(lbl);
        }

        public Preset presetById(characters arg)
        {
            Preset rtrn = new Preset();

            foreach (Preset p in presets)
            {
                if (p.character == arg)
                {
                    rtrn = p;
                }
            }

            return rtrn;
        }

        public int handex = 0;

        public void newHand()
        {
            player.hand = new Card[3];
            for (int i = 0; i < 3; i++)
            {
                Preset p = presetById(player.character);
                player.hand[i] = p.deck[rnd.Next(p.deck.Length)];
            }

            enemy.hand = new Card[3];
            for (int i = 0; i < 3; i++)
            {
                Preset p = presetById(enemy.character);
                enemy.hand[i] = p.deck[rnd.Next(p.deck.Length)];
            }
        }

        public void showCards()
        {
            Label cardnum = new Label
            {
                Content = string.Format("Card: {1}", player.hand[handex].name, handex),
                Background = Brushes.Gray,
                BorderBrush = Brushes.Blue,
                BorderThickness = new Thickness(5),
                FontSize = 40,
                Margin = new Thickness(60),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
            };
            GameArea.Children.Add(cardnum);

            Image card = new Image
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Source = sourceThis(player.hand[handex].source),
                Height = CARDHEIGHT,
                Margin = new Thickness(0, 150, 0, 0),
            };
            GameArea.Children.Add(card);

            Button nextCard = new Button
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(100),
                Content = "Next Card",
                FontSize = 30,
            };
            nextCard.Click += buttonClick;
            GameArea.Children.Add(nextCard);

            Button play = new Button
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(20),
                Content = "Play",
                FontSize = 40,
            };
            play.Click += buttonClick;
            GameArea.Children.Add(play);
        }

        public void battleStage()
        {
            GameArea.Children.Clear();
            ImageBrush imbrsh = new ImageBrush();
            //imbrsh.ImageSource = sourceThis("Sentry.jpg");
            GameArea.Background = imbrsh;

            showCombatants();
            showCards();
        }

        void buttonClick(object sender, RoutedEventArgs e)
        {
            Button s = (Button)sender;
            switch (s.Content)
            {
                case "Back":
                    currentSelector = 0;
                    CombatantSelectionStage();
                    break;
                case "Play":
                    if (!playCard(cardById(player.hand[handex].cn)))
                    {
                        if (!playCard(cardById(enemy.hand[0].cn)))
                        {
                            handex = 0;
                            newHand();
                            battleStage();
                        }   
                    }
                    
                    break;
                case "Next Card":
                    handex += 1;
                    if (handex == 3)
                    {
                        handex = 0;
                    }
                    battleStage();
                    break;
                case "Reset":
                    currentSelector = 0;
                    CombatantSelectionStage();
                    break;
                case "Next":
                    if (currentSelector == 0)
                    {
                        do
                        {
                            players[currentSelector] += 1;
                            if (players[currentSelector] == presets.Length)
                            {
                                players[currentSelector] = 0;
                            }
                        } while (presets[players[currentSelector]].playable != true);
                    }
                    else
                    {
                        do
                        {
                            players[currentSelector] += 1;
                            if (players[currentSelector] == presets.Length)
                            {
                                players[currentSelector] = 0;
                            }
                        } while (presets[players[currentSelector]].fightable != true);
                    }


                    CombatantSelectionStage();
                    break;
                case "This One":
                    currentSelector += 1;
                    if (currentSelector == 1)
                    {
                        CombatantSelectionStage();
                    }
                    else
                    {
                        ResetCombat();
                    }
                    break;
            }
        }

        public Image flipImage(Image arg)
        {
            arg.FlowDirection = FlowDirection.RightToLeft;
            return arg;
        }

        public Combatant newCombatant(Preset preset, HorizontalAlignment side)
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

        public BitmapImage sourceThis(string arg)
        {
            Uri src = new Uri(arg, UriKind.Relative);
            return new BitmapImage(src);
        }
    }
}
