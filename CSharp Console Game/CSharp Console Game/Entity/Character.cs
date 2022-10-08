using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Console_Game.Entity
{
    public class Character
    {
        public int id { get; set; }
        public string name { get; set; }
        public int level { get; set; } // que fase ele ta
        public int currentHp { get; set; }
        public int maxHp { get; set; }
        public Item item { get; set; } //incerto

        public Character(int id,string name){
            this.id = id;
            this.name = name;
            this.level = 1;
            this.maxHp = 100;
            this.currentHp = maxHp;
        }

        Random random = new Random();

        public void levelUp()
        {
            this.level++;    
            this.maxHp += 10;
            this.currentHp = maxHp;
        }

        public bool Dodge()
        {
            random.Next(0, 1);
            if(random.Next(0, 10) > 5)
            {
                return true;
            }
            return false;
        }

        public int AttackPunch()
        {
            return 2 + (random.Next(0, 10));
        }

        public int AttackKick()
        {
            return 5 + (random.Next(5, 10));
        }

        public void TakeDamage(int damage)
        {
            this.currentHp -= damage;
        }

        public int returnId()
        {
            return this.id;
        }

        public string returnName()
        {
            return this.name;
        }

        public int returnLevel()
        {
            return this.level;
        }

        public int returnCurrentHp()
        {
            return this.currentHp;
        }

        public int returnMaxHp()
        {
            return this.maxHp;
        }

        public Item returnItem()
        {
            return this.item;
        }

    }
}
