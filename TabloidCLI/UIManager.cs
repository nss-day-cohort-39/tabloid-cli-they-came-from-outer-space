using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TabloidCLI
{
    public enum UICommand
    {
        JournalMainMenu,
        JournalList,
        JournalAdd,
        JournalEdit,
        JournalDelete,

        BlogMainMenu,

        AuthorMainMenu,

        PostMainMenu,

        TagMainMenu,

        ReturnToMainMenu,
        ExitProgram,
    }

    public class UIManager
    {
        public void ShowHeader()
        {
            Console.Clear();
            Console.WriteLine("Tabloid!");
            Console.WriteLine("---------------------");
            Console.WriteLine("Keeping up with all your Internet reading");
            Console.WriteLine();
        }

        public UICommand MainMenu()
        {
            Console.WriteLine("Main Menu");

            while (true)
            {
                Console.WriteLine(" 1) Journal Management");
                Console.WriteLine(" 2) Blog Management");
                Console.WriteLine(" 3) Author Management");
                Console.WriteLine(" 4) Post Management");
                Console.WriteLine(" 5) Tag Management");
                Console.WriteLine(" 0) Exit");

                Console.Write("> ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out var choice))
                {
                    Console.WriteLine("Invalid Selection");
                    continue;
                }

                switch (choice)
                {
                    case 1: return UICommand.JournalMainMenu;
                    case 2: return UICommand.BlogMainMenu;
                    case 3: return UICommand.AuthorMainMenu;
                    case 4: return UICommand.PostMainMenu;
                    case 5: return UICommand.TagMainMenu;
                    case 0: return UICommand.ExitProgram;
                    default:
                        Console.WriteLine("Invalid Selection");
                        break;
                }
            }
        }

        public UICommand JournalMenu()
        {
            Console.WriteLine("Journal Menu");

            while (true)
            {
                Console.WriteLine(" 1) List Entires");
                Console.WriteLine(" 2) Add Entry");
                Console.WriteLine(" 3) Delete Entry");
                Console.WriteLine(" 0) Return to Main Menu");

                Console.Write("> ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out var choice))
                {
                    Console.WriteLine("Invalid Selection");
                    continue;
                }

                switch (choice)
                {
                    case 1: return UICommand.JournalList;
                    case 2: return UICommand.JournalAdd;
                    case 3: return UICommand.JournalDelete;
                    case 0: return UICommand.ReturnToMainMenu;
                    default:
                        Console.WriteLine("Invalid Selection");
                        break;
                }
            }
            
        }
    }
}
