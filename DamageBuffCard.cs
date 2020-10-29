using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorpCamp
{
    class DamageBuffCard : Card
    {
        private int damage;

        public DamageBuffCard(
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
