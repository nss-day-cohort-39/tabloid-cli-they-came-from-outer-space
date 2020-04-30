using System;

namespace TabloidCLI
{
    public class MainMenuManager : IUserInterfaceManager
    {
        private const string CONNECTION_STRING = @"Data Source=localhost\SQLEXPRESS;Database=TabloidCLI;Integrated Security=True";

        public void ShowHeader()
        {
            Console.Clear();
            Console.WriteLine("Tabloid!");
            Console.WriteLine("---------------------");
            Console.WriteLine("Keeping up with all your Internet reading");
            Console.WriteLine();
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Main Menu");

            Console.WriteLine(" 1) Journal Management");
            Console.WriteLine(" 2) Blog Management");
            Console.WriteLine(" 3) Author Management");
            Console.WriteLine(" 4) Post Management");
            Console.WriteLine(" 5) Tag Management");
            Console.WriteLine(" 0) Exit");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": return new JournalManager(this, CONNECTION_STRING);
                case "2": return this;
                case "3": return this;
                case "4": return this;
                case "5": return this;
                case "0": return null;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }
    }
}
