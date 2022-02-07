using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_CS.src.Entities
{
    class Wizard : Hero
    {
        public Wizard(int id,string name, string heroType)
        {
            this.id = id;
            this.name = name;
            this.level = 1;
            this.heroType = "Mago";
            this.hp = 70;
            this.mana = 200;
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
