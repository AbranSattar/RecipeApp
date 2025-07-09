using System;
using System.Data.SqlTypes;
using System.Transactions;
using Microsoft.Data.SqlClient;
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
			while (true)
			{
				string Menu = view.DisplayMenu();
				switch (Menu)
				{
					case "1":
						Register();
						break;
					case "2":
						Login();
						break;
					case "3":
						Exit();
						break;
					default:
						Console.Clear();
						view.DisplayMessage("Invalid option. Please try again.");
						break;
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
			private static void GetRoleByID()
			{
				
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
				view.DisplayMessage("Enter Country of Area: ");
				string country = view.GetInput();
				int countryID = storageManager.GetCountryIDByName(country);
				int regionID = 0;
				Region region1 = new Region(regionID, countryID, area);
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
				view.DisplayMessage("Enter the new Name: ");
				string suburb = view.GetInput();
				int rowsAffected = storageManager.UpdateSuburb(suburbID, suburb);
				view.DisplayMessage($"rows Affected: {rowsAffected}");
			}
			private static void InsertSuburb()
			{
				view.DisplayMessage("Enter new Suburb: ");
				string suburb = view.GetInput();
				view.DisplayMessage("Enter Zipcode of Suburb: ");
				int zipcode = view.GetIntInput();
				view.DisplayMessage("Enter City of Suburb: ");
				string city = view.GetInput();
				int cityID = storageManager.GetCityIDByName(city);
				int suburbID = 0;
				Suburb suburb1 = new Suburb(suburbID, cityID, suburb, zipcode);
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
				view.DisplayMessage("Enter Suburb of Store: ");
				string suburb = view.GetInput();
				int suburbID = storageManager.GetSuburbIDByName(suburb);
				int storeID = 0;
				Store store1 = new Store(storeID, suburbID, store);
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
			//CRUD operations for User
			private static void UpdateUser()
			{
				view.DisplayMessage("Enter the UserID to update: ");
				int userID = view.GetIntInput();
				view.DisplayMessage("Enter the new Username: ");
				string username = view.GetInput();
				view.DisplayMessage("Enter the new Password: ");
				string password = view.GetInput();
				int rowsAffected = storageManager.UpdateUser(userID, username, password);
				view.DisplayMessage($"rows Affected: {rowsAffected}");
			}
			private static void InsertUser()
			{
				view.DisplayMessage("Enter new Username: ");
				string username = view.GetInput();
				view.DisplayMessage("Enter new Email: ");
				string email = view.GetInput();
				view.DisplayMessage("Enter new First Name: ");
				string firstName = view.GetInput();
				view.DisplayMessage("Enter new Last Name: ");
				string lastName = view.GetInput();
				view.DisplayMessage("Enter new Password: ");
				string password = view.GetInput();
				view.DisplayMessage("Enter Role Name: ");
				string roleName = view.GetInput();

				int roleID = storageManager.GetRoleIDByName(roleName);
				if (roleID == -1)
				{
					view.DisplayMessage("Role not found. Please enter a valid role.");
					return;
				}

				int userID = 0;
			
				User user1 = new User(userID, firstName, lastName, username,email, roleID, password);
				int generatedID = storageManager.InsertUser(user1);
				view.DisplayMessage($"New user inserted with id: {generatedID}");
			}
			private static void DeleteUser()
			{
				view.DisplayMessage("Enter the Username to delete: ");
				string username = view.GetInput();
				int rowsAffected = storageManager.DeleteUser(username);
				view.DisplayMessage($"Rows Affected: {rowsAffected}");
			}
		//CRUD operations for category
			private static void UpdateCategory()
			{
				view.DisplayMessage("Enter the CategoryID to update: ");
				int categoryID = view.GetIntInput();
				view.DisplayMessage("Enter the new Category Name: ");
				string categoryName = view.GetInput();
				int rowsAffected = storageManager.UpdateCategory(categoryID, categoryName);
				view.DisplayMessage($"rows Affected: {rowsAffected}");
			}
			private static void InsertCategory()
			{
				view.DisplayMessage("Enter new Category Name: ");
				string categoryName = view.GetInput();
				int categoryID = 0;
				Category category1 = new Category(categoryID, categoryName);
				int generatedID = storageManager.InsertCategory(category1);
				view.DisplayMessage($"New category inserted with id: {generatedID}");
			}
			private static void DeleteCategory()
			{
				view.DisplayMessage("Enter the Category Name to delete: ");
				string categoryName = view.GetInput();
				int rowsAffected = storageManager.DeleteCategory(categoryName);
				view.DisplayMessage($"Rows Affected: {rowsAffected}");
			}
		//CRUD operations for Recipe
		private static void UpdateRecipe()
		{
			view.DisplayMessage("Enter the RecipeID to update: ");
			int recipeID = view.GetIntInput();
			view.DisplayMessage("Enter the new Recipe Name: ");
			string recipeName = view.GetInput();
			view.DisplayMessage("Enter the new Method: ");
			string method = view.GetInput();
			view.DisplayMessage("Enter the new Category:");
			string categoryName = view.GetInput();
			view.DisplayMessage("Enter the New Region");
			string regionName = view.GetInput();
			int regionID = storageManager.GetRegionIDByName(regionName);
			int categoryID = storageManager.GetCategoryIDByName(categoryName);
			int rowsAffected = storageManager.UpdateRecipe(recipeID, recipeName, method, categoryID, regionID);
			view.DisplayMessage($"rows Affected: {rowsAffected}");
		}
		private static void InsertRecipe()
		{
			view.DisplayMessage("----Insert Recipe----\n");
			view.DisplayMessage("Enter your username:");
			string username = view.GetInput();
			int userID = storageManager.GetUserIDByUsername(username);
			view.DisplayMessage("Enter the RecipeID to update: ");
			int recipeID = view.GetIntInput();
			view.DisplayMessage("Enter the new Recipe Name: ");
			string recipeName = view.GetInput();
			view.DisplayMessage("Enter the new Method: ");
			string method = view.GetInput();
			view.DisplayMessage("Enter the new Category:");
			string categoryName = view.GetInput();
			view.DisplayMessage("Enter the New Region");
			string regionName = view.GetInput();
			int regionID = storageManager.GetRegionIDByName(regionName);
			int categoryID = storageManager.GetCategoryIDByName(categoryName);
			Recipe recipe1 = new Recipe(recipeID, recipeName, method, categoryID, userID, regionID);
			int generatedID = storageManager.InsertRecipe(recipe1);
			view.DisplayMessage($"New recipe inserted with id: {generatedID}");
		}
		private static void DeleteRecipe()
		{
			view.DisplayMessage("Enter the Recipe Name to delete: ");
			string recipeName = view.GetInput();
			int rowsAffected = storageManager.DeleteRecipe(recipeName);
			view.DisplayMessage($"Rows Affected: {rowsAffected}");
		}
		private static void Register()
		{
			// Registration logic here
			Console.Clear();
			view.DisplayMessage("----Registration Page----\n");
			view.DisplayMessage("Enter your username: ");
			string username = view.GetInput();
			view.DisplayMessage("Enter your password: ");
			string password = view.GetInput();
			//checks if username exits
			if (storageManager.CheckIfUserExists(username))
			{
				view.DisplayMessage("Username already exists. Please choose a different username.");
			}
			else
			{
				// Insert user into the database
				int userID = 0; // Assuming userID is auto-generated
				view.DisplayMessage("Enter your email: ");
				string email = view.GetInput();
				view.DisplayMessage("Enter your first name: ");
				string firstName = view.GetInput();
				view.DisplayMessage("Enter your last name: ");
				string lastName = view.GetInput();
				view.DisplayMessage("Enter your role (e.g., Admin, User): ");
				string roleName = view.GetInput();
				int roleID = storageManager.GetRoleIDByName(roleName);
				if (roleID == -1)
				{
					view.DisplayMessage("Role not found. Please enter a valid role.");
					return;
				}
				User newUser = new User(userID, firstName, lastName, username, email, roleID, password);
				int generatedID = storageManager.InsertUser(newUser);
				view.DisplayMessage($"Registration successful! New user inserted with id: {generatedID}");
			}
			
		}
		private static void Login()
		{
			// Login logic here
			Console.Clear();
			view.DisplayMessage("----Login Page----\n");
			view.DisplayMessage("Enter your username: ");
			string username = view.GetInput();
			// Check if the user exists and the password matches
			if (storageManager.CheckIfUserExists(username))
			{
				view.DisplayMessage("Enter your password: ");
				string password = view.GetInput();
				if (storageManager.CheckPassword(username, password))
				{
					view.DisplayMessage("Login successful!");
					
				}
				else
				{
					view.DisplayMessage("Invalid password. Please try again.");
				}
			}
			else
			{
				view.DisplayMessage("Username not found. Please register first.");
				Console.Clear();
				view.DisplayMenu();
			}
		}
			
		private static void Exit()
		{
			view.DisplayMessage("Exiting the application. Goodbye!");
			Environment.Exit(0);
		}
	} 
}



