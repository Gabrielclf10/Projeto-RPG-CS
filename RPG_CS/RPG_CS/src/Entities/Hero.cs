using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_CS.src.Entities
{
    public abstract class Hero
    {
        public Hero(int id,string name,string heroType)
        {
            this.id = id;
            this.name = name;
            this.level = 1;
            this.heroType = heroType;
            this.hp = hp;
            this.mana = mana;
            this.deleted = false;
        }
        public Hero() { }

        public int id { get; set; }
        public string name { get; set; }
        public int level { get; set; }
        public string heroType { get; set; }
        public int hp { get; set; }
        public int mana { get; set; }
        public bool deleted { get; set; }


        public override string ToString()
        {
            string returner = "";
            returner += "ID: " + this.id + Environment.NewLine;
            returner += "   Nome: " + this.name + Environment.NewLine;
            returner += "   Nível: " + this.level + Environment.NewLine;
            returner += "   Classe: " + this.heroType + Environment.NewLine;
            returner += "   HP: " + this.hp + Environment.NewLine;
            returner += "   Mana: " + this.mana + Environment.NewLine;
            returner += "   Excluido: " + this.deleted + Environment.NewLine;
            return returner;
        }

        public virtual string Attack()
        {
            return this.name + " Atacou!";
        }
        public virtual string Attack( int Bonus)
        {
            return this.name + " Atacou, com bonus de "+ Bonus;
        }
        public string returnName()
        {
            return this.name;
        }
        public int returnLevel()
        {
            return this.level;
        }
        public string returnHeroType()
        {
            return this.heroType;
        }
        public bool returnDeleted()
        {
            return this.deleted;
        }
        public int returnId()
        {
            return this.id;
        }
        public void DeleteThis()
        {
            this.deleted = true;
        }

    }
}
