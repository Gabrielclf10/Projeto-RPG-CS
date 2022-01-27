using System;
using RPG_CS.src.Entities;

namespace RPG_CS
{
    class Program
    {
        static HeroRepository heroRepository = new HeroRepository();

        static void Main(string[] args)
        {
            Knight myKnight = new Knight();
            Wizard myWizard = new Wizard();
            Rogue myRouge = new Rogue();

            string userChoise = GetUserChoiseStart();

            static string GetUserChoiseStart()
            {
                Console.WriteLine();
                Console.WriteLine(@"
                      RPG C#
              -Repositorio dos Herois-
               
Digite qualquer tecla para continuar ou X para sair.");

                string userChoise = Console.ReadLine().ToUpper();
                return userChoise;
            }

            Console.Clear();

            while (userChoise.ToUpper() != "X")
            {
                switch (userChoise)
                {
                    case "1":
                        HeroList();
                        break;
                    case "2":
                        HeroAdd();
                        break;
                    case "3":
                        UpdateHero();
                        break;
                    case "4":
                        DeleteHero();
                        break;
                    case "5":
                        Console.WriteLine("//TODO");
                        Console.WriteLine();
                        Console.WriteLine(" Pressione qualquer tecla para continuar");
                        Console.WriteLine();
                        Console.ReadLine();
                        //PlayHero(); TODO
                        break;
                    default:
                        Console.WriteLine("Erro: Opção Inválida.");
                        break;     
                }
                userChoise = GetUserChoiseMenu();
                Console.WriteLine();
            }

            static string GetUserChoiseMenu()
            {
                Console.Clear();
                Console.WriteLine(@"
                    Informe a opção desejada
                      1 - Listar meus herois
                      2 - Criar novo heroi
                      3 - Atualizar heroi existente
                      4 - Excluir heroi
                      5 - Testar com um heroi
                      X - Voltar
                                    ");

                string getUserChoiseMenu = Console.ReadLine().ToUpper();
                return getUserChoiseMenu;
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
                    Console.WriteLine(" Pressione qualquer tecla para continuar");
                    Console.WriteLine();
                    Console.ReadLine();
                    return;
                }

                foreach (var hero in list)
                {
                    var deleted = hero.returnDeleted();

                    Console.WriteLine($@"
                    +-------
                    | ID:     {hero.returnId()}
                    | Nome:   {hero.returnName()}
                    | Nível:  {hero.returnLevel()}
                    | Classe: {hero.returnHeroType()} 
                    | Status: {(deleted ? "[Excluído]" : "Disponível")}                                                     
                    +--------                                                       ");

                }
                Console.WriteLine(" Pressione qualquer tecla para continuar");
                Console.ReadLine();
            }

            static void HeroAdd()
            {
                string getClass = "0";
                string level = " ";
                string hp = " ";
                string mana = " ";
                int getLevel = 0;
                int getHp = 0;
                int getMana = 0;

                while (getClass != "1" ^ getClass != "2" ^ getClass != "3")
                {
                    Console.Clear();
                    Console.WriteLine(@"     
                             - Criando O Novo Heroi - 
                     Escolha a Classe entre as opções abaixo:

                                1 - Knight
                                2 - Wizard
                                3 - Rogue
                                            ");
                    getClass = (Console.ReadLine());
                }                

                Console.WriteLine(" Insira o nome do seu Heroi: ");
                string getName = (Console.ReadLine());

                while (true)
                {
                    Console.WriteLine(" Insira o nível: ");
                    level = (Console.ReadLine());
                    bool parsed = int.TryParse(level, out getLevel);
                    if (parsed)
                    {
                        break;
                    }
                    else
                        Console.WriteLine("Valor Inválido");
                }

                while (true)
                {
                    Console.WriteLine(" Insira o HP total: ");
                    hp = (Console.ReadLine());
                    bool parsed = int.TryParse(hp, out getHp);
                    if (parsed)
                    {
                        break;
                    }
                    else
                        Console.WriteLine("Valor Inválido");
                }

                while (true)
                {
                    Console.WriteLine(" Insira a Mana total: ");
                    mana = (Console.ReadLine());
                    bool parsed = int.TryParse(mana, out getMana);
                    if (parsed)
                    {
                        break;
                    }
                    else
                        Console.WriteLine("Valor Inválido");
                }

                switch (getClass)
                {
                    case "1":
                        Knight myKnight = new Knight(
                        id: heroRepository.NextId(),
                        name: getName,
                        level: getLevel,
                        heroType: "Knight",
                        hp: getHp,
                        mana: getMana);

                        heroRepository.Insert(myKnight);
                        Console.WriteLine();
                        break;

                    case "2":
                        Wizard myWizard = new Wizard(
                        id: heroRepository.NextId(),
                        name: getName,
                        level: getLevel,
                        heroType: "Wizard",
                        hp: getHp,
                        mana: getMana);

                        heroRepository.Insert(myWizard);
                        Console.WriteLine();
                        break;

                    case "3":
                        Rogue myRouge = new Rogue(
                        id: heroRepository.NextId(),
                        name: getName,
                        level: getLevel,
                        heroType: "Rogue",
                        hp: getHp,
                        mana: getMana);

                        heroRepository.Insert(myRouge);
                        Console.WriteLine();
                        break;
                }
                Console.WriteLine();
            }

            static void UpdateHero()
            {
                int idHero = -1;
                string getClass = " ";
                string level = " ";
                string hp = " ";
                string mana = " ";
                int getLevel = 0;
                int getHp = 0;
                int getMana = 0;

                Console.Clear();
                Console.WriteLine(@"
                            - Atualizando Heroi -  ");

                var list = heroRepository.List();

                if (list.Count == 0)
                {
                    Console.WriteLine(" Nenhum heroi cadastrado.");
                    Console.WriteLine();
                    Console.WriteLine(" Aperte qualquer tecla para continuar");
                    Console.WriteLine();
                    Console.ReadLine();
                    return;
                }

                HeroList();
                Console.WriteLine(@"
                            - Atualizando Heroi -  ");
                Console.WriteLine(@"

                       Insira o ID do heroi a atualizar:   
                                                         ");
                idHero = int.Parse(Console.ReadLine());

                while (getClass != "1" ^ getClass != "2" ^ getClass != "3")
                {
                    Console.Clear();
                    Console.WriteLine(@"     
                  Escolha a Nova Classe entre as opções abaixo:

                                 1 - Knight
                                 2 - Wizard
                                 3 - Rogue
                                            ");
                    getClass = (Console.ReadLine());
                }

                Console.WriteLine(" Insira novo o nome do seu Heroi: ");
                string getName = (Console.ReadLine());

                while (true)
                {
                    Console.WriteLine(" Insira o nível: ");
                    level = (Console.ReadLine());
                    bool parsed = int.TryParse(level, out getLevel);
                    if (parsed)
                    {
                        break;
                    }
                    else
                        Console.WriteLine("Valor Inválido");
                }

                while (true)
                {
                    Console.WriteLine(" Insira o HP total: ");
                    hp = (Console.ReadLine());
                    bool parsed = int.TryParse(hp, out getHp);
                    if (parsed)
                    {
                        break;
                    }
                    else
                        Console.WriteLine("Valor Inválido");
                }

                while (true)
                {
                    Console.WriteLine(" Insira a Mana total: ");
                    mana = (Console.ReadLine());
                    bool parsed = int.TryParse(mana, out getMana);
                    if (parsed)
                    {
                        break;
                    }
                    else
                        Console.WriteLine("Valor Inválido");
                }

                switch (getClass)
                {
                    case "1":
                        Knight myKnight = new Knight(
                        id: heroRepository.NextId(),
                        name: getName,
                        level: getLevel,
                        heroType: "Knight",
                        hp: getHp,
                        mana: getMana);

                        heroRepository.Update(idHero, myKnight);
                        Console.WriteLine();
                        break;

                    case "2":
                        Wizard myWizard = new Wizard(
                        id: heroRepository.NextId(),
                        name: getName,
                        level: getLevel,
                        heroType: "Wizard",
                        hp: getHp,
                        mana: getMana);

                        heroRepository.Update(idHero, myWizard);
                        Console.WriteLine();
                        break;

                    case "3":
                        Rogue myRouge = new Rogue(
                        id: heroRepository.NextId(),
                        name: getName,
                        level: getLevel,
                        heroType: "Rogue",
                        hp: getHp,
                        mana: getMana);

                        heroRepository.Update(idHero, myRouge);
                        Console.WriteLine();
                        break;
                }
            }

            static void DeleteHero()
            {
                int idHero = -1;
                Console.WriteLine(@"

                        - Excluindo Heroi - 
                                                         ");

                var list = heroRepository.List();

                if (list.Count == 0)
                {
                    Console.WriteLine("Nenhum heroi cadastrado.");
                    Console.WriteLine();
                    Console.WriteLine("Pressione qualquer tecla para continuar");
                    Console.WriteLine();
                    Console.ReadLine();
                    return;
                }

                HeroList();

                Console.WriteLine(@"
                                 Digite o ID do Heroi: ");
                idHero = int.Parse(Console.ReadLine());

                heroRepository.Delete(idHero);
                Console.WriteLine();
            }
        }
    }
}