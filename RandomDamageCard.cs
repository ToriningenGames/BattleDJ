using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorpCamp
{
    class RandomDamageCard : Card
    {
        private int minDamage;

        private int maxDamage;

        public RandomDamageCard(
            CardType cardType,
            string name,
            string source,
            int minDamage,
            int maxDamage) : base(cardType, name, source)
        {
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
        }

        public override int GetDamage()
        {
            Random r = new Random();
            return r.Next(minDamage, maxDamage);
        }
    }
}
