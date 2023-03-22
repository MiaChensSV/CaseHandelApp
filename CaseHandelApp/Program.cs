using CaseHandelApp.Services;

namespace CaseHandelApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var menu = new MenuService();
            while (true)
            {
                await menu.MainMenu();
            }

        }
    }
}