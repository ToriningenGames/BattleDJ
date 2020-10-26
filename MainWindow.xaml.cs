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
        public const int CARDHEIGHT = 350;
        public Thickness PLAYERMARGIN = new Thickness(50, 0, 50, 0);
        public bool turn = false;
        Random rnd;
        public int currentSelector;

        Combatant player = new Combatant();
        Combatant enemy = new Combatant();

        Card[] cards = new Card[]
        {
            new Card(CardType.Gun, "Gun", "gun_card.png"),
            new Card(CardType.Heal, "Heal", "heal_card_final.png"),
            new Card(CardType.Sword, "Sword", "SWORD_final.png"),
            new Card(CardType.Bow, "Bow", "Bow.png"),
            new Card(CardType.MilkAtk, "Milk Attack", "milk_atk.png"),
            new Card(CardType.MilkHeal, "Milk Heal", "milk_heal.png")
        };

        //<Image x:Name="goni" HorizontalAlignment="Left" Height="463" VerticalAlignment="Top" Width="228" Source="standard.png" Margin="991,85,0,0" RenderTransformOrigin="3.292,0.792" Grid.Column="1"/>





        int[] players = new int[] { 0, 0 };
       

        public bool playCard(Card c)
        {
            int h;
            switch (c.CardType)
            {
                case CardType.Gun:
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
                case CardType.Heal:
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
                case CardType.Sword:
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
                case CardType.Bow:
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
                case CardType.MilkHeal:
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
                case CardType.MilkAtk:
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

        public Card cardById(CardType arg)
        {
            //Card rtrn = new Card();
            Card rtrn = null;

            foreach (Card c in cards)
            {
                if (c.CardType == arg)
                {
                    rtrn = c;
                }
            }

            return rtrn;
        }

        public void giveCards()
        {
            foreach(Combatant.Preset p in Combatant.presets)
            {
                switch (p.character)
                {
                    case characters.DrMilk:
                        p.deck = new Card[]
                        {
                            cardById(CardType.MilkAtk),
                            cardById(CardType.MilkHeal)
                        };
                        break;
                    case characters.RatWizard:
                        p.deck = new Card[]
                        {
                            cardById(CardType.Heal),
                            cardById(CardType.Sword),
                            cardById(CardType.Bow)
                        };
                        break;
                    case characters.CrissWithAGun:
                        p.deck = new Card[]
                        {
                            cardById(CardType.Gun),
                        };
                        break;
                    case characters.TheRatMaster:
                        p.deck = new Card[]
                        {
                            cardById(CardType.Heal),
                            cardById(CardType.Bow),
                            cardById(CardType.Sword),
                        };
                        break;
                    case characters.RatGamer:
                        p.deck = new Card[]
                        {
                            cardById(CardType.Heal),
                            cardById(CardType.Sword),
                            cardById(CardType.Bow),
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

        

        public void unlockAll(object sender, EventArgs e)
        {
            foreach (Combatant.Preset p in Combatant.presets)
            {
                unlockPlayable(p.character);
                unlockFightable(p.character);
            }
        }

        public void resetPlayers()
        {
            while (!Combatant.presets[players[0]].playable)
            {
                players[0] += 1;
                if (players[0] >= Combatant.presets.Length)
                {
                    players[0] = 0;
                }
            } 
            while (!Combatant.presets[players[1]].fightable)
            {
                players[1] += 1;
                if (players[1] >= Combatant.presets.Length)
                {
                    players[1] = 0;
                }
            }

            Combatant.Preset p1 = Combatant.presets[players[0]];
            Combatant.Preset p2 = Combatant.presets[players[1]];
            player = newCombatant(p1, HorizontalAlignment.Left);
            player.pic = flipImage(player.pic);
            enemy = newCombatant(p2, HorizontalAlignment.Right);
        }

        public void unlock()
        {
            switch (Combatant.presets[players[1]].character)
            {
                case characters.TheRatMaster:
                    unlockPlayable(characters.TheRatMaster);
                    if (Combatant.presets[players[0]].character == characters.TheRatMaster)
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
            foreach(Combatant.Preset p in Combatant.presets)
            {
                if (p.character == arg)
                {
                    p.playable = true;
                }
            }
        }

        public void unlockFightable(characters arg)
        {
            foreach (Combatant.Preset p in Combatant.presets)
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

        public Combatant.Preset presetById(characters arg)
        {
            Combatant.Preset rtrn = new Combatant.Preset();

            foreach (Combatant.Preset p in Combatant.presets)
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
                Combatant.Preset p = presetById(player.character);
                player.hand[i] = p.deck[rnd.Next(p.deck.Length)];
            }

            enemy.hand = new Card[3];
            for (int i = 0; i < 3; i++)
            {
                Combatant.Preset p = presetById(enemy.character);
                enemy.hand[i] = p.deck[rnd.Next(p.deck.Length)];
            }
        }

        public void showCards()
        {
            Label cardnum = new Label
            {
                Content = string.Format("Card: {1}", player.hand[handex].Name, handex),
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
                Source = sourceThis(player.hand[handex].Source),
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
                    if (!playCard(cardById(player.hand[handex].CardType)))
                    {
                        if (!playCard(cardById(enemy.hand[0].CardType)))
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
                            if (players[currentSelector] == Combatant.presets.Length)
                            {
                                players[currentSelector] = 0;
                            }
                        } while (Combatant.presets[players[currentSelector]].playable != true);
                    }
                    else
                    {
                        do
                        {
                            players[currentSelector] += 1;
                            if (players[currentSelector] == Combatant.presets.Length)
                            {
                                players[currentSelector] = 0;
                            }
                        } while (Combatant.presets[players[currentSelector]].fightable != true);
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
    }
}
