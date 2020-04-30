using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace TabloidCLI
{
    public class JournalManager : IUserInterfaceManager
    {
        private readonly string _connectionString;
        private readonly IUserInterfaceManager _parentUI;

        public JournalManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _connectionString = connectionString;
        }

        public IUserInterfaceManager Execute()
        {
            UICommand command = Menu();
            if (command == UICommand.ReturnToMainMenu)
            {
                return _parentUI;
            }

            return this;
        }

        public UICommand Menu()
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
                    case 1: return UICommand.List;
                    case 2: return UICommand.Add;
                    case 3: return UICommand.Delete;
                    case 0: return UICommand.ReturnToMainMenu;
                    default:
                        Console.WriteLine("Invalid Selection");
                        break;
                }
            }
        }
    }
}
