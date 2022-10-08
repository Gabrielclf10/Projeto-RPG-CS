using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Console_Game.Entity.Enemy
{
    public class EnemyBase
    {
        public string name { get; set; }
        public int currentHp { get; set; }
        public int maxHp { get; set; }

        Random random = new Random();

        public EnemyBase(string name,int maxHp){
            this.name = name;
            this.currentHp = maxHp;
            this.maxHp = maxHp;
        }

        public virtual int Attack()
        { 
            return 5;
        }

        public virtual bool Dodge()
        {
            if (random.Next(0, 10) > 5)
            {
                return true;
            }
            return false;
        }

        public virtual void TakeDamage(int damage)
        {
            this.currentHp -= damage;
        }

        public string returnName()
        {
            return this.name;
        }

        public int returnCurrentHp()
        {
            return this.currentHp;
        }

        public int returnMaxHp()
        {
            return this.maxHp;
        }



    }
}
