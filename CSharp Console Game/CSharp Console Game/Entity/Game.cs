using CSharp_Console_Game.Entity.Enemy;
using CSharp_Console_Game.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Console_Game.Entity
{
    class Game
    {       
        Random random = new Random();
        WMPLib.WindowsMediaPlayer song = new WMPLib.WindowsMediaPlayer();


        public void Run(Character player)
        {
            if (song.playState != WMPLib.WMPPlayState.wmppsPlaying)
            {
                song.URL = @"Super-Castlevania-IV-OST-Stage-3.mp3";
            }
            else
            {
                song.controls.stop();

            }

            RunGame(player);
        }

        public void RunGame(Character player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine();
            Console.WriteLine(@$"  
    Entre árvores secas de uma floresta, numa chuvosa noite, você desperta sujo e com frio, sem se 
lembrar de nada...");                                                                                                
            WaitForKey();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@$"  
    Logo ao se levantar do chão de terra, você percebe das sombras uma pequena criatura, rosnando, 
correndo em tua direção...");
            WaitForKey();

            //Primeria batalha
            Beast goblin = new Beast("Goblin", 26);
            song.controls.stop();
            Encounter1(player, goblin);

            // Pós primeira batalha
            song.URL = @"Super-Castlevania-IV-OST-Stage-3.mp3";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine();

            if(player.returnCurrentHp() > 80)
            {
                Console.WriteLine(@$"  
    A criatura não era forte, mas te deixou com arranhões pelos antebraços...");
            }
            else if (player.returnCurrentHp() > 40)
            {
                Console.WriteLine(@$"  
    Depois da luta nas sombras, você ficou com arranhões pelo abdômem e cortes abertos pelos antebraços...");
            }
            else if (player.returnCurrentHp() > 20)
            {
                Console.WriteLine(@$"  
    Foi um desepero, mas você ainda está em pé. Percebe cortes pelo corpo todo causados pelas garras da 
 criatura, é melhor cuidar disso logo...");
            }
            else
            {
                Console.WriteLine(@$"  
    Você ainda está em choque pelo susto e ter que lutar por sua vida, você mal consegue ficar em pé. Percebe 
 cortes abertos pelo corpo todo causados pelas garras da criatura, as presas fizeram um grande estrago em sua
 perna esquerda, é melhor cuidar disso logo...");
            }

            Console.WriteLine(@$"  
    No pescoço do cadáver, você observa um pingente azul brilhante...");
            WaitForKey();



            song.controls.stop();
        }

        public void Encounter1(Character player, Beast enemy)
        {
            song.URL = @"TLoZ-Ocarina-of-Time-Boss-Battle.mp3";
            do
            {
                Console.WriteLine();
                string title = ($@"   
     Você:    {player.returnName()}             
     HP[{player.returnCurrentHp()}/{player.returnMaxHp()}]

     Inimigo: {enemy.returnName()}             
     HP[{enemy.returnCurrentHp()}/{enemy.returnMaxHp()}]
     ");                           
                Console.WriteLine();

                string[] options = { "Socar",
                                     "Chutar"};
                ChoiseSystem action = new ChoiseSystem(title, options);
                int selectedIndex = action.Run();

                switch (selectedIndex)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"    {player.returnName()} tentou socar {enemy.returnName()}!");
                        if (!enemy.Dodge())
                        {
                            enemy.TakeDamage(player.AttackPunch());
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"    {enemy.returnName()} desviou do seu ataque!");
                            Console.WriteLine($"    {enemy.returnName()} tentou te morder!");
                            if (!player.Dodge())
                            {
                                player.TakeDamage(enemy.AttackBite());
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"    Você desviou!");
                            }
                        }
                        WaitForKey();
                        break;

                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"    {player.returnName()} tentou dar um chute em {enemy.returnName()}!");
                        if (!enemy.Dodge())
                        {
                            enemy.TakeDamage(player.AttackKick());
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($@"    {enemy.returnName()} desviou do seu ataque!");
                            Console.WriteLine($@"    {enemy.returnName()} avançou para cima de você com as garras!");
                            if (!player.Dodge())
                            {
                                player.TakeDamage(enemy.Attack());
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($@"    Você desviou!");
                            }
                        }
                        WaitForKey();
                        break;

                    default:
                        WaitForKey();
                        break;
                }
            } while (player.returnCurrentHp() > 0 && enemy.returnCurrentHp() > 0);

            if(player.returnCurrentHp() <= 0)
            {
                GameOver();      
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"    {enemy.returnName()} fica desorientado, e cai morto diante de ti.");
                Console.WriteLine();
                WaitForKey();
                song.controls.stop();
            }
        }

        public void WaitForKey()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(@"
                       - V -  Pressione qualquer tecla para continuar...");
            Console.WriteLine();
            Console.ReadKey(true);
            Console.ResetColor();
        }

        public void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"       
                                                                                 
                                                                                 
  @@@@@@@   @@@@@@  @@@@@@@@@@  @@@@@@@@       @@@@@@  @@@  @@@ @@@@@@@@ @@@@@@@ 
 !@@       @@!  @@@ @@! @@! @@! @@!           @@!  @@@ @@!  @@@ @@!      @@!  @@@
 !@! @!@!@ @!@!@!@! @!! !!@ @!@ @!!!:!        @!@  !@! @!@  !@! @!!!:!   @!@!!@! 
 :!!   !!: !!:  !!! !!:     !!: !!:           !!:  !!!  !: .:!  !!:      !!: :!! 
  :: :: :   :   : :  :      :   : :: :::       : :. :     ::    : :: :::  :   : :
                                                            
                             Você morreu.   ");
            Console.WriteLine();
            Console.ResetColor();
            song.controls.stop();
        }

    }
}

