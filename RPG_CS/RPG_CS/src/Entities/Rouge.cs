using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_CS.src.Entities
{
    class Rogue : Hero
    {
        public Rogue(int id,string name, int level, string heroType, int hp,int mana)
        {
            this.id = id;
            this.name = name;
            this.level = level;
            this.heroType = "Rouge";
            this.hp = hp;
            this.mana = mana;
            this.deleted = false;
        }
        public Rogue() { }

        public override string Attack()
        {
            return this.name + " atacou usando sua adaga!";
        }

        public override string Attack(int Bonus)
        {
            if (Bonus > 10)
            {
                return this.name + " atacou usando sua adaga super efetiva, com bonus de " + Bonus;
            }
            else
            {
                return this.name + " atacou usando sua adaga, com bonus de " + Bonus;
            }
        }
    }
}
