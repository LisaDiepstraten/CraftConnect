using BusinessLayer.Interfaces;
using DataAccessLibrary;
using BusinessLayer.Services;


namespace CraftConnectDeskPresent
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            IAccountRepository repo = new AccountRepository();
            IAccountService accountService = new AccountService(repo);
            IItemRepository repoitem = new ItemRepository();
            IItemService itemservice = new ItemService(repoitem);
          
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LogIn(accountService, itemservice));
        }
    }
}