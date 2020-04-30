using System;

namespace TabloidCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenuManager mainMenu = new MainMenuManager();
            mainMenu.ShowHeader();

            IUserInterfaceManager ui = mainMenu;
            while (ui != null)
            {
                ui = ui.Execute();
            }
        }
    }
}
