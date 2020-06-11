using System;
using System.Collections.Generic;
using System.Text;

namespace TabloidCLI.UserInterfaceManagers
{
    public class ColorManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;

        public ColorManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
        }

        public ColorManager()
        {
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Color Menu");
            Console.WriteLine(" 1) Dark Space");
            Console.WriteLine(" 2) China");
            Console.WriteLine(" 3) Gaia");
            Console.WriteLine(" 4) Cosmic Cyan");
            Console.WriteLine(" 5) Tactical");
            Console.WriteLine(" 6) Boring (Default)");
            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    return this;
                case "2":
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    return this;
                case "3":
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    return this;
                case "4":
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    return this;
                case "5":
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    return this;
                case "6":
                    Console.ResetColor();
                    return this;
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }
    }
}