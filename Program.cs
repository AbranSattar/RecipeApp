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
                        Register();
                        break;
                    }
                case "2":
                    {
                        Login();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Error 404 wtf");
                    }
            }
        }

        //Country CRUD operations
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
		// Role CRUD operations

		private static void UpdateRole()
		{

			view.DisplayMessage("Enter the RoleID to update: ");
			int roleID = view.GetIntInput();
			view.DisplayMessage("Enter the new Role: ");
			string role = view.GetInput();
			int rowsAffected = storageManager.UpdateRole(roleID, role);
			view.DisplayMessage($"rows Affected: {rowsAffected}");

		}
		private static void InsertRole()
		{
			view.DisplayMessage("Enter new Role: ");
			string role = view.GetInput();
			int roleID = 0;
			Role role1 = new Role(roleID, role);
			int generatedID = storageManager.InsertRole(role1);
			view.DisplayMessage($"New role inserted with id: {generatedID}");

		}

		private static void DeleteRole()
		{
			view.DisplayMessage("Enter the role to delete: ");
			string role = view.GetInput();
			int rowsAffected = storageManager.DeleteRole(role);
			view.DisplayMessage($"Rows Affected: {rowsAffected}");
		}
		// CRUD operations for Region

        private static void UpdateRegion()
		{
			view.DisplayMessage("Enter the RegionID to update: ");
			int regionID = view.GetIntInput();
			view.DisplayMessage("Enter the new Area: ");
			string area = view.GetInput();
			int rowsAffected = storageManager.UpdateRegion(regionID, area);
			view.DisplayMessage($"rows Affected: {rowsAffected}");
		}
		private static void InsertRegion()
		{
			view.DisplayMessage("Enter new Area: ");
			string area = view.GetInput();
			int regionID = 0;
			Region region1 = new Region(regionID, area);
			int generatedID = storageManager.InsertRegion(region1);
			view.DisplayMessage($"New region inserted with id: {generatedID}");
		}
		private static void DeleteRegion()
		{
			view.DisplayMessage("Enter the Area to delete: ");
			string area = view.GetInput();
			int rowsAffected = storageManager.DeleteRegion(area);
			view.DisplayMessage($"Rows Affected: {rowsAffected}");
		}

		// CRUD operations for City
		private static void UpdateCity()
		{
			view.DisplayMessage("Enter the CityID to update: ");
			int cityID = view.GetIntInput();
			view.DisplayMessage("Enter the new City: ");
			string city = view.GetInput();
			int rowsAffected = storageManager.UpdateCity(cityID, city);
			view.DisplayMessage($"rows Affected: {rowsAffected}");
		}
		private static void InsertCity()
		{
			view.DisplayMessage("Enter new City: ");
			string city = view.GetInput();
			int cityID = 0;
			City city1 = new City(cityID, city);
			int generatedID = storageManager.InsertCity(city1);
			view.DisplayMessage($"New city inserted with id: {generatedID}");
		}
		private static void DeleteCity()
		{
			view.DisplayMessage("Enter the City to delete: ");
			string city = view.GetInput();
			int rowsAffected = storageManager.DeleteCity(city);
			view.DisplayMessage($"Rows Affected: {rowsAffected}");
		}
		// CRUD operations for Suburb
		private static void UpdateSuburb()
		{
			view.DisplayMessage("Enter the SuburbID to update: ");
			int suburbID = view.GetIntInput();
			view.DisplayMessage("Enter the new Suburb: ");
			string suburb = view.GetInput();
			int rowsAffected = storageManager.UpdateSuburb(suburbID, suburb);
			view.DisplayMessage($"rows Affected: {rowsAffected}");
		}
		private static void InsertSuburb()
		{
			view.DisplayMessage("Enter new Suburb: ");
			string suburb = view.GetInput();
			int suburbID = 0;
			Suburb suburb1 = new Suburb(suburbID, suburb);
			int generatedID = storageManager.InsertSuburb(suburb1);
			view.DisplayMessage($"New suburb inserted with id: {generatedID}");
		}
		private static void DeleteSuburb()
		{
			view.DisplayMessage("Enter the Suburb to delete: ");
			string suburb = view.GetInput();
			int rowsAffected = storageManager.DeleteSuburb(suburb);
			view.DisplayMessage($"Rows Affected: {rowsAffected}");
		}
		// CRUD operations for Store
		private static void UpdateStore()
		{
			view.DisplayMessage("Enter the StoreID to update: ");
			int storeID = view.GetIntInput();
			view.DisplayMessage("Enter the new Store: ");
			string store = view.GetInput();
			int rowsAffected = storageManager.UpdateStore(storeID, store);
			view.DisplayMessage($"rows Affected: {rowsAffected}");
		}
		private static void InsertStore()
		{
			view.DisplayMessage("Enter new Store: ");
			string store = view.GetInput();
			int storeID = 0;
			Store store1 = new Store(storeID, store);
			int generatedID = storageManager.InsertStore(store1);
			view.DisplayMessage($"New store inserted with id: {generatedID}");
		}
		private static void DeleteStore()
		{
			view.DisplayMessage("Enter the Store to delete: ");
			string store = view.GetInput();
			int rowsAffected = storageManager.DeleteStore(store);
			view.DisplayMessage($"Rows Affected: {rowsAffected}");
		}
		private static void Register()
		{
			// Registration logic here
			view.DisplayMessage("Registration not implemented yet.");
		}
		private static void Login()
		{
			// Login logic here
			view.DisplayMessage("Login not implemented yet.");
		}
	}
}
