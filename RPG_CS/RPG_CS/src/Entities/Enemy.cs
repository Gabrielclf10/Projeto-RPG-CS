using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_CS.src.Entities
{
    class Enemy
    {
        public string name { get; set; }
        public int hp { get; set; }


        public Enemy()
        {

        }

        public Enemy (string name, int hp)
        {
            this.name = name;
            this.hp = hp;
        }

    }
}
