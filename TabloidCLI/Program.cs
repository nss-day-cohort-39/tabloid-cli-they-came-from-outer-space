using TabloidCLI.UserInterfaceManagers;

namespace TabloidCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenuManager mainMenu = new MainMenuManager();
            mainMenu.ShowHeader();

            // MainMenuManager implements the IUserInterfaceManager interface
            IUserInterfaceManager ui = mainMenu;
            while (ui != null)
            {
                // Each call to Execute will return the next IUserInterfaceManager we should execute
                // When it returns null, we should exit the program;
                ui = ui.Execute();
            }
        }
    }
}
