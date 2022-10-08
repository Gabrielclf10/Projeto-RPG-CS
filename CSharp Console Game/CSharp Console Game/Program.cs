using CSharp_Console_Game.Entity;
using System;

namespace CSharp_Console_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(110,35);
            Menu myMenu = new Menu();
            myMenu.Run();
         }
    }
}
