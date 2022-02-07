using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_CS.src.Entities
{
    class Knight : Hero
    {
        public Knight(int id,string name, string heroType)
        {
            this.id = id;
            this.name = name;
            this.level = 1;
            this.heroType = "Guerreiro";
            this.hp = 100;
            this.mana = 0;
            this.deleted = false;
        }
        public Knight() { }

        public override string Attack()
        {
            return this.name + " atacou usando sua espada!";
        }

        public override string Attack(int Bonus)
        {
            if (Bonus > 10)
            {
                return this.name + " atacou usando sua espada super efetiva, com bonus de " + Bonus;
            }
            else
            {
                return this.name + " atacou usando sua espada, com bonus de " + Bonus;
            }
        }
    }
}

