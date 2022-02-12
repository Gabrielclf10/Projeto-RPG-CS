using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_CS.src.Entities
{
    class Item
    {
        public string name { get; set; }
        public int quantity { get; set; }
        public int damage { get; set; }

        public Item()
        {

        }

        public Item (string name, int quantity, int damage)
        {
            this.name = name;
            this.quantity = quantity;
            this.damage = damage;
        }




    }
}
