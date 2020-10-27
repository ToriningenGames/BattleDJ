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
            string name,
            string source,
            int damage
        ) : base(name, source)
        {
            this.damage = damage;
        }

        public override int GetDamage()
        {
            return damage;
        }
    }
}
