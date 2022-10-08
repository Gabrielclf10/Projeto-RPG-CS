using CSharp_Console_Game.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Console_Game.Entity
{
    public abstract class Item
    {
        public string name { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }

        public Item (string name, string description, int quantity)
        {
            this.name = name;
            this.description = description;
            this.quantity = quantity;
        }


    }
            
}
