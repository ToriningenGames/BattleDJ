using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorpCamp
{
    class StaticDamageCard : Card
    {
        private int damage;

        public StaticDamageCard(
            CardType cardType,
            string name,
            string source,
            int damage) : base(cardType, name, source)
        {
            this.damage = damage;
        }

        public override int GetDamage()
        {
            return damage;
        }
    }
}
