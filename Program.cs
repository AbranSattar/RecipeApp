using Microsoft.Identity.Client.Extensions.Msal;
using RecipeApp.Repositories;

namespace RecipeApp
{
    public class Program
    {

        private static StorageManager storageManager;
        private static ConsoleView view;

        static void Main(string[] args)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RecipeDatabase;Integrated Security=True;Connect " +
                "Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            storageManager = new StorageManager(connectionString);
            ConsoleView view = new ConsoleView();
            string choice = view.DisplayMenu();

            switch (choice)
            {
                case "1":
                    {
                        List<Country> countries = storageManager.GetAllCountries();
                        view.DisplayCountries(countries);
                        break;
                    }
                case "2":
                    {
                        UpdateCountryName();
                        break;
                    }
                case "3":
                    {
                        //DeleteCountryName();
                        break;
                    }
                case "4":
                    {
                        //InsertCountryName();
                        break;
                    }
                case "5":
                    {
                        //exit = true;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                    }
            }
        }

        private static void UpdateCountryName()
        {
            view.DisplayMessage("Ener the CountryID to update: ");
            int countryID = ConsoleView.GetIntInput();
            view.DisplayMessage("Enter the new brand name: ");
            string countryName = ConsoleView.GetInput();
            int rowsAffected = StorageManager.UpdateCountryName(countryID, countryName);
            view.DisplayMessage($"rows Affected: {rowsAffected}");

        }
    }
}
