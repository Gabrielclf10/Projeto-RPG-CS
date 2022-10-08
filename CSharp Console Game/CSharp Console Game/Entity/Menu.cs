using CSharp_Console_Game.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using WMPLib;

namespace CSharp_Console_Game.Entity
{
    public class Menu
    {

        CharacterRepository characterRepository = new CharacterRepository();
        Game myGame = new Game();
        WMPLib.WindowsMediaPlayer song = new WMPLib.WindowsMediaPlayer();

        public Menu()
        {
        }

        public void Run()
        {
            Inicio:

            song.controls.stop();

            if (song.playState != WMPLib.WMPPlayState.wmppsPlaying)
            {
                song.URL = @"Legend-of-Zelda-Ocarina-of-TIme.mp3";
            }
            else
            {
                song.controls.stop();

            }
            RunMainMenu();
            goto Inicio;
        }
        public void RunMainMenu()
        {        

            string[] options = { "Iniciar","Créditos", "Sair" };
            ChoiseSystem main = new ChoiseSystem(@"


   @@@@@@@   @@@@@@@@  @@@@@@@   @@@@@@@@  @@@  @@@  @@@@@@@   @@@@@@   @@@  @@@   @@@@@@@  @@@@@@@@     
   @@@@@@@@  @@@@@@@@  @@@@@@@@  @@@@@@@@  @@@@ @@@  @@@@@@@  @@@@@@@@  @@@@ @@@  @@@@@@@@  @@@@@@@@     
   @@!  @@@  @@!       @@!  @@@  @@!       @@!@!@@@    @@!    @@!  @@@  @@!@!@@@  !@@       @@!          
   !@!  @!@  !@!       !@!  @!@  !@!       !@!!@!@!    !@!    !@!  @!@  !@!!@!@!  !@!       !@!          
   @!@!!@!   @!!!:!    @!@@!@!   @!!!:!    @!@ !!@!    @!!    @!@!@!@!  @!@ !!@!  !@!       @!!!:!       
   !!@!@!    !!!!!:    !!@!!!    !!!!!:    !@!  !!!    !!!    !!!@!!!!  !@!  !!!  !!!       !!!!!:       
   !!: :!!   !!:       !!:       !!:       !!:  !!!    !!:    !!:  !!!  !!:  !!!  :!!       !!:          
   :!:  !:!  :!:       :!:       :!:       :!:  !:!    :!:    :!:  !:!  :!:  !:!  :!:       :!:          
   ::   :::   :: ::::   ::        :: ::::   ::   ::     ::    ::   :::   ::   ::   ::: :::   :: ::::     
    :   : :  : :: ::    :        : :: ::   ::    :      :      :   : :  ::    :    :: :: :  : :: ::      
             
   
   
     Use as setas do teclado para navegar entre as opções abaixo! ", options);
            int selectedIndex = main.Run();

            switch (selectedIndex)
            {
                case 0:
                    if(characterRepository.NextId() == 0) // Se não há personagens, ir direto para a criação de um novo.
                    {
                        Console.WriteLine();
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine(@" Você ainda não tem nenhum personagem..");
                        NewCharacter();
                    }
                    RunPlayMenu();
                    break;
                case 1:
                    DisplayAbout();
                    RunMainMenu();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
                default:
                    RunMainMenu();
                    break;
            }
         
        }

        public void RunPlayMenu()
        {
            string[] options = { "Jogar",
                                 "Gerenciar Personagens",
                                 "Voltar"};
            ChoiseSystem main = new ChoiseSystem(ReturnCharactersList(characterRepository), options);
            int selectedIndex = main.Run();

            switch (selectedIndex)
            {
                case 0:
                    song.controls.stop();
                    myGame.Run(CharacterSelector()); //Inicia o jogo
                    break;
                case 1:
                    CharacterCreatorMenu();
                    break;
                case 2:
                    RunMainMenu();
                    break;
                default:
                    RunPlayMenu();
                    break;
            }

        }

        public Character CharacterSelector()
        {
            Console.Clear();
            List<string> options = new List<string>();
            int i;
            var list = characterRepository.List();

            for (i = 0; i < list.Count; i++)
            {
                options.Add($@" - Nome: {list[i].returnName()} - Nível: {list[i].returnLevel()} - Hp: {list[i].returnCurrentHp()}/{list[i].returnMaxHp()}");
            }

            Console.ForegroundColor = ConsoleColor.White;
            ChoiseSystem selectCharacter = new ChoiseSystem("\n Escolha seu Personagem para jogar!", options.ToArray());
            int selectedIndex = selectCharacter.Run();

            return characterRepository.ReturnById(selectedIndex);

        }

        public void CharacterCreatorMenu()
        {
            string[] options = { "Criar Novo Personagem",
                                 "Editar Personagem",
                                 "Deletar Personagem",
                                 "Voltar"};
            ChoiseSystem main = new ChoiseSystem(ReturnCharactersList(characterRepository), options);
            int selectedIndex = main.Run();

            switch (selectedIndex)
            {
                case 0:
                    NewCharacter();
                    CharacterCreatorMenu();
                    break;
                case 1:
                    UpdateCharacter();
                    CharacterCreatorMenu();
                    break;
                case 2:
                    DeleteCharacter();
                    CharacterCreatorMenu();
                    break;
                case 3:
                    RunPlayMenu();
                    break;
                default:
                    CharacterCreatorMenu(); 
                    break;
            }

        }

        public string ReturnCharactersList(CharacterRepository characterRepository)
        {

            string allCharacters = "";
            var list = characterRepository.List();

            if (list.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                return "\n  !!! Nenhum Personagem Criado. !!!";
            }

            foreach (var character in list)
            {              
                allCharacters += ($@"
     +-----------------------------------------------
      Id:     {character.returnId()}
      Nome:   {character.returnName()}
      Nível:  {character.returnLevel()}
      Hp:     {character.returnCurrentHp()}/{character.returnMaxHp()}
     +----------------------------------------------");
            }
            return allCharacters;
        }

        public void NewCharacter()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Insira o nome do seu Novo Personagem: ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            Character character = new Character(characterRepository.NextId(),Console.ReadLine());
            characterRepository.Insert(character);
        }

        public void UpdateCharacter()
        {
            Console.Clear();
            List<string> options = new List<string>();
            int i;
            var list = characterRepository.List();

            for (i = 0; i < list.Count; i++)
            {
                options.Add($@" - Nome: {list[i].returnName()} - Nível: {list[i].returnLevel()} - Hp: {list[i].returnCurrentHp()}/{list[i].returnMaxHp()}" );
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            ChoiseSystem updateCharacter = new ChoiseSystem("\n Escolha o Personagem para atualizar!", options.ToArray());
            int selectedIndex = updateCharacter.Run();

            Console.WriteLine();
            Console.WriteLine($" Insira o novo Nome para {characterRepository.ReturnById(selectedIndex).returnName()}");
            Console.WriteLine();

            characterRepository.ReturnById(selectedIndex).name = Console.ReadLine();
            var objUpdate = characterRepository.ReturnById(selectedIndex);
            characterRepository.Update(selectedIndex, objUpdate);

        }

        public void DeleteCharacter()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($@"

     Atenção: Isso deletará o todo o progresso com o personagem que for escolhido.
     Você tem certeza? (Digite S para confirmar, ou qualquer outra tecla para cancelar)
     ");
            if (Console.ReadLine().ToUpper() == "S")
            {
                Console.Clear();
                List<string> options = new List<string>();
                int i;
                var list = characterRepository.List();

                for (i = 0; i < list.Count; i++)
                {
                    options.Add($@" - Nome: {list[i].returnName()} - Nível: {list[i].returnLevel()} - Hp: {list[i].returnCurrentHp()}/{list[i].returnMaxHp()}");
                }

                Console.ForegroundColor = ConsoleColor.Red;
                ChoiseSystem deleteCharacter = new ChoiseSystem("\n Escolha o Personagem para DELETAR!", options.ToArray());
                int selectedIndex = deleteCharacter.Run();
                characterRepository.Delete(selectedIndex);
            }

        }

        public void DisplayAbout()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"  -  Desenvolvido por mim, Gabriel Claudino.");
            Console.WriteLine($"  -  Isto é só uma demo para fins didáticos e por curiosidade.");
            Console.WriteLine($"  -  Meu Github: https://github.com/Gabrielclf10/");
            Console.WriteLine();
            WaitForKey();
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
    }
}
