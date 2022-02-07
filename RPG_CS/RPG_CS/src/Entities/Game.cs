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

        public Game()
        {}

        public void RunGame()
        {
            int Index = 0;
            int selectedIndex = RunTitleMenu(Index);

            static int RunTitleMenu(int Index)
            {
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
                        RunNewGame();
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

            static void RunNewGame()
            {
                string title = @"                                                          
                    Use as Setas para navegar entre as opções abaixo! ";
                string[] options = { "Iniciar", "Editar Heroi", "Ver meus Herois", "Deletar Heroi" };
                Menu newGameMenu = new Menu(title, options);
                int selectedIndex = newGameMenu.Run();
           
                switch (selectedIndex)
                {
                    case 0:
                        HeroAdd(); // TODO Depois daqui, Iniciar o jogo
                        RunNewGame();
                        break;
                    case 1:
                        UpdateHero();
                        RunNewGame();
                        break;
                    case 2:
                        HeroList();
                        RunNewGame();
                        break;
                    case 3:
                        DeleteHero();
                        RunNewGame();
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

            static void HeroList()
            {
                Console.Clear();
                Console.WriteLine(@"
                                - Seus Herois -");

                var list = heroRepository.List();

                if (list.Count == 0)
                {
                    Console.WriteLine(" Nenhum heroi cadastrado.");
                    Console.WriteLine();
                    WaitForKey();
                    return;
                }

                foreach (var hero in list)
                {

                    var deleted = hero.returnDeleted();

                    Console.WriteLine($@"
                    +
                    | ID:     {hero.returnId()}
                    | Nome:   {hero.returnName()}
                    | Nível:  {hero.returnLevel()}
                    | Classe: {hero.returnHeroType()} 
                    | Status: {(deleted ? "[Excluído]" : "Disponível")}                                                     
                    +                                                       ");

                }
                WaitForKey();
            }

            static void HeroAdd()
            {
                int getClass = 0;

                string title = @"                                                          
                    Escolha a Classe do seu Herói! ";
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
                        Console.WriteLine("Erro: Opção Inválida.");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine(" - Digite o nome do seu Heroi: ");
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
                int getClass = 0;

                Console.Clear();
                Console.WriteLine(@"
                            - Atualizando Herói -  
                                                    ");

                var list = heroRepository.List();

                if (list.Count == 0)
                {
                    Console.WriteLine("!!! Nenhum herói cadastrado. !!!");
                    Console.WriteLine();
                    WaitForKey();
                    return;
                }

                HeroList();
                Console.WriteLine(@"
                            - Atualizando Heroi -  ");
                Console.WriteLine(@"
                       Insira o ID do herói a atualizar: ");
                idHero = int.Parse(Console.ReadLine());

                Console.Clear();

                string title = @"                                                          
                    Escolha a nova Classe do seu Herói! ";
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
                        Console.WriteLine("Erro: Opção Inválida.");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine(" Insira novo o nome do seu Heroi: ");
                string getName = (Console.ReadLine());

                switch (getClass)
                {
                    case 1:
                        Knight myKnight = new Knight(
                        id: heroRepository.NextId(),
                        name: getName,
                        heroType: "Guerreiro");

                        heroRepository.Update(idHero, myKnight);
                        Console.WriteLine();
                        break;

                    case 2:
                        Wizard myWizard = new Wizard(
                        id: heroRepository.NextId(),
                        name: getName,
                        heroType: "Mago");

                        heroRepository.Update(idHero, myWizard);
                        Console.WriteLine();
                        break;

                    case 3:
                        Rogue myRouge = new Rogue(
                        id: heroRepository.NextId(),
                        name: getName,
                        heroType: "Ladino");

                        heroRepository.Update(idHero, myRouge);
                        Console.WriteLine();
                        break;
                }             
            }

            static void DeleteHero()
            {
                int idHero = -1;
                Console.WriteLine(@"
                        - Excluindo Heroi -");

                var list = heroRepository.List();

                if (list.Count == 0)
                {
                    Console.WriteLine("!!! Nenhum heroi cadastrado. !!!");
                    Console.WriteLine();
                    Console.WriteLine(" Pressione qualquer tecla para continuar...");
                    Console.WriteLine();
                    Console.ReadLine();
                    return;
                }

                HeroList();

                Console.WriteLine(@"
                Digite o ID do Heroi a ser excluido: ");
                idHero = int.Parse(Console.ReadLine());

                heroRepository.Delete(idHero);
                Console.WriteLine();
            }

            static void LevelUp(Hero hero)
            {           
                hero.level += 1;
            }

            static void WaitForKey()
            {
                Console.WriteLine(" Pressione qualquer tecla para continuar...\n");
                Console.WriteLine();
                Console.ReadKey(true);
            }

            static void ExitGame()
            {
                Environment.Exit(0);
            }
        }
        
    }
}
