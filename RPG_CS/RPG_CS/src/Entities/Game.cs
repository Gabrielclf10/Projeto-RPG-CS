using System;
using System.Collections.Generic;
using System.Text;
using RPG_CS.src.Entities;

namespace RPG_CS.src.Entities
{

    public class Game
    {
        static HeroRepository heroRepository = new HeroRepository();

        Knight myKnight = new Knight();
        Wizard myWizard = new Wizard();
        Rogue myRouge = new Rogue();

        Item Sword = new Item("Espada",1,10);
        Item Staff = new Item("Cajado", 1, 15);
        Item Dagger = new Item("Adaga", 2, 7);


        public Game()
        {}

        public void RunGame()
        {
            int Index = 0;
            int selectedIndex = RunTitleMenu(Index);

            static int RunTitleMenu(int Index)
            {
                Console.ResetColor();
                string title = @"                                                          

                                 ▄▀▀▄▀▀▀▄  ▄▀▀▄▀▀▀▄  ▄▀▀▀▀▄   
                                █   █   █ █   █   █ █         
                                ▐  █▀▀█▀  ▐  █▀▀▀▀  █    ▀▄▄  
                                 ▄▀    █     █      █     █ █ 
                                █     █    ▄▀       ▐▀▄▄▄▄▀ ▐ 
                                ▐     ▐   █         ▐         
                                          ▐                   
                                                                    
                    Bem-vindo(a) - Use as Setas para navegar entre as opções abaixo! ";
                string[] options = { "Jogar", "Creditos", "Sair" };
                Menu titleMenu = new Menu(title, options);
                int selectedIndex = titleMenu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        RunMainMenu();
                        break;
                    case 1:
                        DisplayAbout();
                        RunTitleMenu(0);
                        break;
                    case 2:
                        ExitGame();
                        break;
                }
                return selectedIndex;
            }

            static void RunMainMenu()
            {
                string title = @"                                                          
                    Use as Setas para navegar entre as opções abaixo! ";
                string[] options = { "Novo Jogo", "Continuar", "Voltar" };
                Menu mainMenu = new Menu(title, options);
                int selectedIndex = mainMenu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        RunNewGameMenu();
                        break;
                    case 1:
                        RunMainMenu();
                        //TODO Carregar jogo salvo
                        break;
                    case 2:
                        RunTitleMenu(0);
                        break;
                }
            }

            static void RunNewGameMenu()
            {
                string title = @"                                                          
                    Use as Setas para navegar entre as opções abaixo! ";
                string[] options = { "Iniciar", "Editar Heroi", "Ver meus Herois", "Deletar Heroi" };
                Menu newGameMenu = new Menu(title, options);
                int selectedIndex = newGameMenu.Run();
           
                switch (selectedIndex)
                {
                    case 0:
                        AddHero(); // TODO Depois daqui, Iniciar o jogo
                        RunNewGameMenu();
                        break;
                    case 1:
                        UpdateHero();
                        RunNewGameMenu();
                        break;
                    case 2:
                        ListHero();
                        RunNewGameMenu();
                        break;
                    case 3:
                        DeleteHero();
                        RunNewGameMenu();
                        break;
                    default:
                        Console.WriteLine("Erro: Opção Inválida.");
                        break;
                }
            }

            static void DisplayAbout()
            {
                Console.Clear();
                Console.WriteLine($"  -  Esse jogo está sendo desenvolvido por Gabriel Claudino");
                Console.WriteLine($"  -  Isto é só uma demo...");
                Console.WriteLine($"  -  Github: https://github.com/Gabrielclf10/");
                Console.WriteLine();
                WaitForKey();
            }

            static void ListHero()
            {
                Console.Clear();
                Console.WriteLine(@"
                                - Seus Herois -");

                var list = heroRepository.List();

                if (list.Count == 0)
                {
                    Console.WriteLine(@" 
                        !!! Nenhum heroi cadastrado. !!!");
                    Console.WriteLine();
                    WaitForKey();
                    return;
                }

                foreach (var hero in list)
                {

                    var deleted = hero.returnDeleted();
                    if(deleted == true)
                    {
                        continue;
                    }

                    Console.WriteLine($@"
                    +
                    | ID:     {hero.returnId()}
                    | Nome:   {hero.returnName()}
                    | Nível:  {hero.returnLevel()}
                    | Classe: {hero.returnHeroType()} 
                    | Status: {(deleted ? "X[Excluído]X" : "Disponível")}                                                     
                    +                                                       ");

                }
                WaitForKey();
            }

            static void AddHero()
            {
                int getClass = 0;

                string title = @"                                                          
                    Escolha a Classe do seu Herói! - (Não é possível alterar depois)";
                string[] options = { "Guerreiro", "Mago", "Ladino" };
                Menu heroAddClassMenu = new Menu(title, options);
                int selectedIndex = heroAddClassMenu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        getClass = 1;
                        break;
                    case 1:
                        getClass = 2;
                        break;
                    case 2:
                        getClass = 3;
                        break;
                    default:
                        Console.WriteLine(" - Erro: Opção Inválida.");
                        break;
                }

                Console.Clear();
                Console.WriteLine(" - Digite o nome do seu Heroi - (Você pode alterar mais tarde)");
                string getName = (Console.ReadLine());
                Console.WriteLine();

                switch (getClass)
                {
                    case 1:
                        Knight myKnight = new Knight(
                        id: heroRepository.NextId(),
                        name: getName,
                        heroType: "Guerreiro");

                        heroRepository.Insert(myKnight);
                        Console.WriteLine();
                        break;

                    case 2:
                        Wizard myWizard = new Wizard(
                        id: heroRepository.NextId(),
                        name: getName,
                        heroType: "Mago");

                        heroRepository.Insert(myWizard);
                        Console.WriteLine();
                        break;

                    case 3:
                        Rogue myRouge = new Rogue(
                        id: heroRepository.NextId(),
                        name: getName,
                        heroType: "Ladino");

                        heroRepository.Insert(myRouge);
                        Console.WriteLine();
                        break;
                }
                Console.WriteLine();
            }

            static void UpdateHero()
            {
                int idHero = -1;
                bool validation = false;

                Console.Clear();
                Console.WriteLine(@"
                            - Atualizando Herói -   ");

                var list = heroRepository.List();

                if (list.Count == 0)
                {
                    Console.WriteLine(@"
                        !!! Nenhum herói cadastrado. !!!");
                    Console.WriteLine();
                    WaitForKey();
                    return;
                }

                ListHero();
                Console.WriteLine(@"
                            - Atualizando Heroi -  ");

                do
                {
                    Console.WriteLine(@"
                        Insira o ID do herói a atualizar: ");

                    if (Int32.TryParse(Console.ReadLine(), out idHero))
                    {
                        validation = true;
                    }
                } while (validation == false);

                    Console.Clear();

                Console.WriteLine();
                Console.WriteLine(@"
                        Insira novo o nome do seu Heroi: ");
                string getName = (Console.ReadLine());

                heroRepository.UpdateName(idHero, getName);
            
            }

            static void DeleteHero()
            {
                int idHero = -1;
                bool validation = false;

                Console.WriteLine(@"
                            - Excluindo Heroi -");

                var list = heroRepository.List();

                if (list.Count == 0)
                {
                    Console.WriteLine(@"
                        !!! Nenhum heroi cadastrado. !!!");
                    WaitForKey();
                    return;
                }

                ListHero();
                do
                {
                    Console.WriteLine(@"
                        Insira o ID do herói a deletar: ");

                    if (Int32.TryParse(Console.ReadLine(), out idHero))
                    {
                        validation = true;
                    }
                } while (validation == false);

                heroRepository.Delete(idHero);
                Console.WriteLine();
            }

            static void LevelUp(Hero hero)
            {           
                hero.level += 1;
            }

            static void WaitForKey()
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(@"
                       - V -  Pressione qualquer tecla para continuar...");
                Console.WriteLine();
                Console.ReadKey(true);
                Console.ResetColor();
            }

            static void ExitGame()
            {
                Environment.Exit(0);
            }
        }
        
    }
}
