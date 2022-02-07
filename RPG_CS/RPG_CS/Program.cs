using System;
using RPG_CS.src.Entities;

namespace RPG_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "RPG C#";
            Game myGame = new Game();
            myGame.RunGame();
            
        }
    }
}