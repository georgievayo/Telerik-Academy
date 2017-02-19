using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Specialties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyOfCreatures.Extended.Specialties
{
    public class DoubleAttackWhenAttacking : Specialty
    {
        private int rounds;
        public DoubleAttackWhenAttacking(int rounds)
        {
            if (rounds <= 0)
            {
                throw new ArgumentOutOfRangeException("rounds", "rounds should be greater than 0");
            }
            this.rounds = rounds;
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
            if (skipCreature == null)
            {
                throw new ArgumentNullException("skipCreature");
            }

            skipCreature.PermanentAttack *= 2;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.rounds);
        }
    }
}
