using System;

namespace TabloidCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            UIManager ui = new UIManager();
            ui.ShowHeader();

            UICommand command = ui.MainMenu();
            while (command != UICommand.ExitProgram)
            {
                switch (command)
                {
                    case UICommand.JournalMainMenu:
                        command = ui.JournalMenu();
                        break;
                }

                command = ui.MainMenu();
            }
        }
    }
}
