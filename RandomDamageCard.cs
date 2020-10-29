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
            string name,
            string source,
            int minDamage,
            int maxDamage
        ) : base(name, source)
        {
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
        }

        public override int GetDamage()
        {
            return RNG.random.Next(minDamage, maxDamage);
        }
    }
}
