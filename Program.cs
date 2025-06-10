using System;
using Microsoft.Identity.Client.Extensions.Msal;
using RecipeApp.Models;
using RecipeApp.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RecipeApp
{
    public class Program
    {

        private static StorageManager storageManager;
        private static ConsoleView view;
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\ac148776\\OneDrive - Avondale College\\TPI 11\\12 TPI SQL DATABASE\\RecipeApp\\DBFile\\RecipeDatabase.mdf\";Integrated Security=True;Connect Timeout=30";
            storageManager = new StorageManager(connectionString);
            view = new ConsoleView();
            string Menu = view.DisplayMenu();

            switch (Menu)
            {
                case "1":
                    {
                        UserRegister();
                    }
                case "2":
                    {
                        UserLogin();
                    }
                default:
                    {
                        Console.WriteLine("Error 404 wtf");
                    }
            }
            /*
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
                        UpdateCountry();
                        break;
                    }
                case "3":
                    {
                        InsertCountry();
                        break;
                    }
                case "4":
                    {
                        DeleteCountry();
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
            }*/
        }

        private static void UpdateCountry()
        {

            view.DisplayMessage("Enter the CountryID to update: ");
            int countryID = view.GetIntInput();
            view.DisplayMessage("Enter the new brand name: ");
            string countryName = view.GetInput();
            int rowsAffected = storageManager.UpdateCountry(countryID, countryName);
            view.DisplayMessage($"rows Affected: {rowsAffected}");

        }
        private static void InsertCountry()
        {
            view.DisplayMessage("Enter new country: ");
            string countryName = view.GetInput();
            int countryID = 0;
            Country country1 = new Country(countryID, countryName);
            int generatedID = storageManager.InsertCountry(country1);
            view.DisplayMessage($"New country inserted with id: {generatedID}");

        }

        private static void DeleteCountry()
        {
            view.DisplayMessage("Enter the country name to delete: ");
            string countryName = view.GetInput();
            int rowsAffected = storageManager.DeleteCountry(countryName);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }
    }
}
