using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_CS.src.Entities
{
    class Wizard : Hero
    {
        public Wizard(int id,string name, int level, string heroType, int hp, int mana)
        {
            this.id = id;
            this.name = name;
            this.level = level;
            this.heroType = "Wizard";
            this.hp = hp;
            this.mana = mana;
            this.deleted = false;
        }
        public Wizard() { }

        public override string Attack()
        {
            return this.name + " atacou usando magia!";
        }
        public override string Attack(int Bonus)
        {
            if (Bonus > 10)
            {
                return this.name + " atacou usando magia super efetiva, com bonus de " + Bonus;
            }   
            else
            {
                return this.name + " atacou usando magia, com bonus de " + Bonus;
            }
        }
    }
}
