using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorpCamp
{
    class Card
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

        Card[] cards = new Card[]
        {
            new Card
            {
                cn = Card.CardName.Gun,
                name = "Gun",
                source = "gun_card.png",
            },
            new Card
            {
                cn = Card.CardName.Heal,
                name = "Heal",
                source = "heal_card_final.png",
            },
            new Card
            {
                cn = Card.CardName.Sword,
                name = "Sword",
                source = "SWORD_final.png",
            },
            new Card
            {
                cn = Card.CardName.Bow,
                name = "Bow",
                source = "Bow.png",
            },
            new Card
            {
                cn = Card.CardName.MilkAtk,
                name = "Milk Attack",
                source = "milk_atk.png",
            },new Card
            {
                cn = Card.CardName.MilkHeal,
                name = "Milk Heal",
                source = "milk_heal.png",
            },
        };
    }

}
