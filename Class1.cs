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
    public class Card
    {
        public CardName cn;
        public string name;
        public string source;

        public enum CardName
        {
            Gun,
            Heal,
            Sword,
            Bow,
            MilkAtk,
            MilkHeal
        }
    }

}
