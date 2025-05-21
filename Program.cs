using Microsoft.Identity.Client.Extensions.Msal;
using RecipeApp.Repositories;

namespace RecipeApp
{
    internal class Program
    {
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
                        List<Country> countries = StorageManager.GetAllCountries();
                        view.DisplayCountries(countries);
                    }
                case "2":
                    {
                        UpdateCountryName();
                        break;
                    }
                case "3":
                    {
                        DeleteCountryName();
                        break;
                    }
                case "4":
                    {
                        InsertCountryName();
                        break;
                    }
                case "5":
                    {
                        exit = true;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                    }
                default:
            }
        }
    }
}
