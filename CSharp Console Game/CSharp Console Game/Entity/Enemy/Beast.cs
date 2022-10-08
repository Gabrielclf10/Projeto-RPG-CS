using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Console_Game.Entity.Enemy
{
    public class Beast : EnemyBase
    {
        public Beast(string name, int maxHp) : base(name, maxHp)
        {
            this.name = name;
            this.currentHp = maxHp;
            this.maxHp = maxHp;
        }
        Random random = new Random();

        public override int Attack()
        {
            return base.Attack() + random.Next(0, 8);
        }


        public int AttackBite()
        {
            return base.Attack() + random.Next(5, 10);
        }

        public override bool Dodge()
        {
            if (random.Next(0, 10) > 4)
            {
                return true;
            }
            return false;       
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }

    }
}
