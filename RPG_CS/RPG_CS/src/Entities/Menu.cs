using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_CS.src.Entities
{
    class Menu
    {
        private int SelectedIndex;
        private string[] Options;
        private string Title;

        public Menu (string title, string[] options)
        {
            Title = title;
            Options = options;
            SelectedIndex = 0;
        }

        public void DisplayOptions()
        {
            Console.WriteLine();
            Console.WriteLine(Title);
            Console.WriteLine();
            for (int i = 0; i < Options.Length; i++)
            { 
                string currentOption = Options[i];
                string icon;

                if (i == SelectedIndex)
                {
                    icon = " >";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    icon = "  ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

               
                Console.WriteLine($"       {icon}[ {currentOption} ] ");
            }
            Console.ResetColor();
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                // Atualiza Selectedindex baseado nas Arrow keys
                if(keyPressed == ConsoleKey.UpArrow) 
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = (Options.Length) - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }

    }
}
