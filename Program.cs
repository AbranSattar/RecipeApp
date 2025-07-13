using System;
using System.Data.SqlTypes;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.IdentityModel.Tokens;
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
			string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RECIPE_DATABASE;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
			storageManager = new StorageManager(connectionString);
			view = new ConsoleView();
			while (true)
			{
				string Menu = view.DisplayMenu();
				switch (Menu)
				{
					case "1":
						string regRole = Register(); // returns "admin", "chef", "user", or null
						if (regRole == "Admin")
							AdminMenu();
						else if (regRole == "Chef")
							ChefMenu();
						else if (regRole == "User")
							UserMenu();
						break;
					case "2":
						string role = Login(); // returns "admin", "chef", "user", or null
						if (role == "Admin")
							AdminMenu();
						else if (role == "Chef")
							ChefMenu();
						else if (role == "User")
							UserMenu();
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
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Update Country----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter the Country to update: ");
				string temp = view.GetInput();
				string countryName = ValidateCountry(temp);
				if (countryName.ToUpper() == "ESC") break ;

				int countryID = storageManager.GetCountryID(countryName);

				view.DisplayMessage("Enter the new country name: ");
				string updatedCountry = view.GetInput().ToUpper();
				if (updatedCountry.IsNullOrEmpty())
				{
					view.DisplayMessage("Country name cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000); // Pause for a moment before continuing
					continue;

				}
				if (updatedCountry.ToUpper() == "ESC") break;

				int rowsAffected = storageManager.UpdateCountry(countryID, updatedCountry);
				view.DisplayMessage($"Rows affected: {rowsAffected}\n");

				view.DisplayMessage("Press any key to continue...");
				Console.ReadKey(true);
			}

			Console.Clear();
		}
		private static void InsertCountry()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Insert New Country----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter new country: ");
				string countryName = view.GetInput();
				if (countryName.IsNullOrEmpty())
				{
					view.DisplayMessage("Country name cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000); // Pause for a moment before continuing
					continue;
				}
				if (countryName.ToUpper() == "ESC")
					break;

				int countryID = 0;
				Country country1 = new Country(countryID, countryName);
				int generatedID = storageManager.InsertCountry(country1);
				view.DisplayMessage($"New country inserted with ID: {generatedID}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
			}
			Console.Clear();

		}
		private static void DeleteCountry()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Delete Country----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter the country name to delete: ");
				string countryName = view.GetInput();
				if (countryName.ToUpper() == "ESC")
					break;

				int rowsAffected = storageManager.DeleteCountry(countryName);
				view.DisplayMessage($"Rows affected: {rowsAffected}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
			}
			Console.Clear();
		}
		// Role CRUD operations

		private static void UpdateRole()
		{

			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Update Role----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter the Role to update: ");
				string rolename = view.GetInput();
				if (rolename.ToUpper() == "ESC")
					break;

				string role = ValidateRole(rolename);
				int roleID = storageManager.GetRoleIDByName(rolename);

				view.DisplayMessage("Enter the new Role: ");
				string newRole = view.GetInput();
				if (newRole.IsNullOrEmpty())
				{
					view.DisplayMessage("Role name cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000); // Pause for a moment before continuing
					continue;
				}
				if (newRole.ToUpper() == "ESC")
					break;

				int rowsAffected = storageManager.UpdateRole(roleID, newRole);
				view.DisplayMessage($"Rows affected: {rowsAffected}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
			}
			Console.Clear();

		}
		private static void InsertRole()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Insert New Role----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter new Role: ");
				string role = view.GetInput();
				if (role.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(role))
				{
					view.DisplayMessage("Role name cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000); // pause briefly
					continue; // stay in loop
				}

				int roleID = 0;
				Role role1 = new Role(roleID, role);
				int generatedID = storageManager.InsertRole(role1);
				view.DisplayMessage($"New role inserted with ID: {generatedID}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
			}
			Console.Clear();
		}
		private static void DeleteRole()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Delete Role----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter the role to delete: ");
				string temp = view.GetInput();
				if (temp.ToUpper() == "ESC")
					break;

				string role = ValidateRole(temp);
				if (string.IsNullOrEmpty(role))
				{
					view.DisplayMessage("Role name cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue; // stay in loop
				}

				int rowsAffected = storageManager.DeleteRole(role);
				view.DisplayMessage($"Rows affected: {rowsAffected}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
			}
			Console.Clear();
		}
		// CRUD operations for Region

		private static void UpdateRegion()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Update Region----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter the Region to update: ");
				string temp = view.GetInput();
				if (temp.ToUpper() == "ESC")
					break;

				string region1 = ValidateRegion(temp);
				int regionID = storageManager.GetRegionIDByName(region1);

				view.DisplayMessage("Enter the new Region: ");
				string area = view.GetInput();
				if (area.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(area))
				{
					view.DisplayMessage("Region cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000); // Pause briefly
					continue; // go back to start of loop
				}

				int rowsAffected = storageManager.UpdateRegion(regionID, area);
				view.DisplayMessage($"Rows affected: {rowsAffected}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
			}
			Console.Clear();
		}
		private static void InsertRegion()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Insert New Region----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter new Region: ");
				string area = view.GetInput();
				if (area.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(area))
				{
					view.DisplayMessage("Region cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue; // prompt again
				}

				view.DisplayMessage("Enter Country of Area: ");
				string temp = view.GetInput();
				if (temp.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(temp))
				{
					view.DisplayMessage("Country cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue; // prompt again
				}

				string country = ValidateCountry(temp);
				int countryID = storageManager.GetCountryID(country);
				int regionID = 0;

				Region region1 = new Region(regionID, countryID, area);
				int generatedID = storageManager.InsertRegion(region1);
				view.DisplayMessage($"New region inserted with ID: {generatedID}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
			}
			Console.Clear();
		}
		private static void DeleteRegion()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Delete Region----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter the Area to delete: ");
				string temp = view.GetInput();
				if (temp.ToUpper() == "ESC")
					break;

				string area = ValidateRegion(temp);
				int regionID = storageManager.GetRegionIDByName(area);

				int rowsAffected = storageManager.DeleteRegion(area);
				view.DisplayMessage($"Rows affected: {rowsAffected}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
			}
			Console.Clear();
		}

		// CRUD operations for City
		private static void UpdateCity()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Update City----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter the City to update: ");
				string temp = view.GetInput();
				if (temp.ToUpper() == "ESC")
					break;

				string city = ValidateCity(temp);
				int cityID = storageManager.GetCityIDByName(city);

				view.DisplayMessage("Enter the new City: ");
				string newCity = view.GetInput();
				if (newCity.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(newCity))
				{
					view.DisplayMessage("City name cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue;
				}

				int rowsAffected = storageManager.UpdateCity(cityID, newCity);
				view.DisplayMessage($"Rows affected: {rowsAffected}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
			}
			Console.Clear();
		}
		private static void InsertCity()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Insert New City----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter new City: ");
				string city = view.GetInput();
				if (city.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(city))
				{
					view.DisplayMessage("City name cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue;
				}

				int cityID = 0;
				City city1 = new City(cityID, city);
				int generatedID = storageManager.InsertCity(city1);
				view.DisplayMessage($"New city inserted with ID: {generatedID}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
			}
			Console.Clear();
		}
		private static void DeleteCity()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Delete City----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter the City to delete: ");
				string temp = view.GetInput();
				if (temp.ToUpper() == "ESC")
					break;

				string city = ValidateCity(temp);
				int rowsAffected = storageManager.DeleteCity(city);
				view.DisplayMessage($"Rows affected: {rowsAffected}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
			}
			Console.Clear();
		}
		// CRUD operations for Suburb
		private static void UpdateSuburb()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Update Suburb----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter the Suburb to update: ");
				string temp = view.GetInput();
				if (temp.ToUpper() == "ESC")
					break;

				string suburb = ValidateSuburb(temp);
				int suburbID = storageManager.GetSuburbIDByName(suburb);

				view.DisplayMessage("Enter the new Name: ");
				string newSuburb = view.GetInput();
				if (newSuburb.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(newSuburb))
				{
					view.DisplayMessage("Suburb name cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue;
				}

				int rowsAffected = storageManager.UpdateSuburb(suburbID, newSuburb);
				view.DisplayMessage($"Rows affected: {rowsAffected}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
			}
			Console.Clear();
		}
		private static void InsertSuburb()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Insert New Suburb----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter new Suburb: ");
				string suburb = view.GetInput();
				if (suburb.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(suburb))
				{
					view.DisplayMessage("Suburb name cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue;
				}

				view.DisplayMessage("Enter Zipcode of Suburb: ");
				int temp = view.GetIntInput();
				int zipcode = ValidateZipcode(temp.ToString());

				view.DisplayMessage("Enter City of Suburb: ");
				string tempCity = view.GetInput();
				if (tempCity.ToUpper() == "ESC")
					break;

				string city = ValidateCity(tempCity);
				int cityID = storageManager.GetCityIDByName(city);
				int suburbID = 0;

				Suburb suburb1 = new Suburb(suburbID, cityID, suburb, zipcode);
				int generatedID = storageManager.InsertSuburb(suburb1);
				view.DisplayMessage($"New suburb inserted with ID: {generatedID}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
			}
			Console.Clear();
		}
		private static void DeleteSuburb()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Delete Suburb----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter the Suburb to delete: ");
				string temp = view.GetInput();
				if (temp.ToUpper() == "ESC")
					break;

				string suburb = ValidateSuburb(temp);
				int rowsAffected = storageManager.DeleteSuburb(suburb);
				view.DisplayMessage($"Rows affected: {rowsAffected}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
			}
			Console.Clear();
		}
		// CRUD operations for Store
		private static void UpdateStore()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Update Store----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter the Store to update: ");
				string temp = view.GetInput();
				if (temp.ToUpper() == "ESC")
					break;

				string storeName = ValidateStore(temp);

				view.DisplayMessage("Enter the Store ID: ");
				int storeID = view.GetIntInput();

				view.DisplayMessage("Enter the new Store: ");
				string store = view.GetInput();
				if (store.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(store))
				{
					view.DisplayMessage("Store name cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue;
				}

				int rowsAffected = storageManager.UpdateStore(storeID, store);
				view.DisplayMessage($"Rows affected: {rowsAffected}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
			}
			Console.Clear();
		}
		private static void InsertStore()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Insert New Store----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter new Store: ");
				string store = view.GetInput();
				if (store.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(store))
				{
					view.DisplayMessage("Store name cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue;
				}

				view.DisplayMessage("Enter Suburb of Store: ");
				string temp = view.GetInput();
				if (temp.ToUpper() == "ESC")
					break;

				string suburb = ValidateSuburb(temp);
				int suburbID = storageManager.GetSuburbIDByName(suburb);
				int storeID = 0;

				Store store1 = new Store(storeID, suburbID, store);
				int generatedID = storageManager.InsertStore(store1);
				view.DisplayMessage($"New store inserted with ID: {generatedID}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
			}
			Console.Clear();
		}
		private static void DeleteStore()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Delete Store----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter the Store to delete: ");
				string store = view.GetInput();
				if (store.ToUpper() == "ESC")
					break;

				int rowsAffected = storageManager.DeleteStore(store);
				view.DisplayMessage($"Rows affected: {rowsAffected}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
			}
			Console.Clear();
		}
		//CRUD operations for User
		private static void UpdateUser()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Update User----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter the Username to update: ");
				string temp = view.GetInput();
				if (temp.ToUpper() == "ESC")
					break;

				string username = ValidateUsername(temp);
				int userID = storageManager.GetUserIDByUsername(username);

				view.DisplayMessage("Enter the new Username: ");
				string newUsername = view.GetInput();
				if (newUsername.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(newUsername))
				{
					view.DisplayMessage("Username cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue;
				}

				view.DisplayMessage("Enter the new Password: ");
				string password = view.GetInput();
				if (password.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(password))
				{
					view.DisplayMessage("Password cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue;
				}

				int rowsAffected = storageManager.UpdateUser(userID, newUsername, password);
				view.DisplayMessage($"Rows affected: {rowsAffected}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
			}
			Console.Clear();
		}
		private static void InsertUser()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Insert New User----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter new Username: ");
				string username = view.GetInput();
				if (username.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(username))
				{
					view.DisplayMessage("Username cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue;
				}

				view.DisplayMessage("Enter new Email: ");
				string email = view.GetInput();
				if (email.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(email) || !email.Contains("@"))
				{
					view.DisplayMessage("Email is invalid, please try again.");
					System.Threading.Thread.Sleep(1000);
					continue;
				}

				view.DisplayMessage("Enter new First Name: ");
				string firstName = view.GetInput();
				if (firstName.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(firstName))
				{
					view.DisplayMessage("First Name cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue;
				}

				view.DisplayMessage("Enter new Last Name: ");
				string lastName = view.GetInput();
				if (lastName.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(lastName))
				{
					view.DisplayMessage("Last Name cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue;
				}

				view.DisplayMessage("Enter new Password: ");
				string password = view.GetInput();
				if (password.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(password))
				{
					view.DisplayMessage("Password cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue;
				}

				view.DisplayMessage("Enter Role Name: ");
				string temp = view.GetInput();
				if (temp.ToUpper() == "ESC")
					break;

				string roleName = ValidateRole(temp);
				int roleID = storageManager.GetRoleIDByName(roleName);

				int userID = 0;
				User user1 = new User(userID, firstName, lastName, username, email, roleID, password);
				int generatedID = storageManager.InsertUser(user1);
				view.DisplayMessage($"New user inserted with ID: {generatedID}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
			}
			Console.Clear();
		}
		private static void DeleteUser()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Delete User----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter the Username to delete: ");
				string temp = view.GetInput();
				if (temp.ToUpper() == "ESC")
					break;

				string username = ValidateUsername(temp);
				int rowsAffected = storageManager.DeleteUser(username);
				view.DisplayMessage($"Rows affected: {rowsAffected}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
			}
			Console.Clear();
		}
		//CRUD operations for category
		private static void UpdateCategory()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Update Category----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter the Category to update: ");
				string temp = view.GetInput();
				if (temp.ToUpper() == "ESC")
					break;

				string categoryName = ValidateCategory(temp);
				int categoryID = storageManager.GetCategoryIDByName(categoryName);

				view.DisplayMessage("Enter the new Category Name: ");
				string newCategory = view.GetInput();
				if (newCategory.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(newCategory))
				{
					view.DisplayMessage("Category name cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue;
				}

				int rowsAffected = storageManager.UpdateCategory(categoryID, newCategory);
				view.DisplayMessage($"Rows affected: {rowsAffected}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
			}
			Console.Clear();
		}
		private static void InsertCategory()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Insert New Category----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter new Category Name: ");
				string categoryName = view.GetInput();
				if (categoryName.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(categoryName))
				{
					view.DisplayMessage("Category name cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue;
				}

				int categoryID = 0;
				Category category1 = new Category(categoryID, categoryName);
				int generatedID = storageManager.InsertCategory(category1);
				view.DisplayMessage($"New category inserted with ID: {generatedID}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
			}
			Console.Clear();
		}
		private static void DeleteCategory()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Delete Category----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter the Category Name to delete: ");
				string temp = view.GetInput();
				if (temp.ToUpper() == "ESC")
					break;

				string categoryName = ValidateCategory(temp);
				int rowsAffected = storageManager.DeleteCategory(categoryName);
				view.DisplayMessage($"Rows affected: {rowsAffected}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
			}
			Console.Clear();
		}
		//CRUD operations for Recipe
		private static void UpdateRecipe()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Update Recipe----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter the Recipe to update: ");
				string temp = view.GetInput();
				if (temp.ToUpper() == "ESC")
					break;

				string recipeName = ValidateRecipe(temp);
				int recipeID = storageManager.GetRecipeIDByTitle(temp);

				view.DisplayMessage("Enter the new Title: ");
				string newTitle = view.GetInput();
				if (newTitle.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(newTitle))
				{
					view.DisplayMessage("Title cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue;
				}

				view.DisplayMessage("Enter the new Method: ");
				string newMethod = view.GetInput();
				if (newMethod.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(newMethod))
				{
					view.DisplayMessage("Method cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue;
				}

				view.DisplayMessage("Enter the new Category: ");
				string categoryName = view.GetInput();
				if (categoryName.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(categoryName))
				{
					view.DisplayMessage("Category cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue;
				}

				view.DisplayMessage("Enter the New Region: ");
				string regionName = view.GetInput();
				if (regionName.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(regionName))
				{
					view.DisplayMessage("Region cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue;
				}

				int regionID = storageManager.GetRegionIDByName(regionName);
				int categoryID = storageManager.GetCategoryIDByName(categoryName);

				int rowsAffected = storageManager.UpdateRecipe(recipeID, newTitle, newMethod, categoryID, regionID);
				view.DisplayMessage($"Rows affected: {rowsAffected}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
				return;
			}
			Console.Clear();
		}
		private static void InsertRecipe()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Update Recipe----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter your username:");
				string temp = view.GetInput();
				if (temp.ToUpper() == "ESC")
					break;

				string username = ValidateUsername(temp);
				int userID = storageManager.GetUserIDByUsername(username);

				view.DisplayMessage("Enter the Title to update: ");
				string tempTitle = view.GetInput();
				if (tempTitle.ToUpper() == "ESC")
					break;

				string Title = ValidateRecipe(tempTitle);
				int recipeID = storageManager.GetRecipeIDByTitle(Title);

				view.DisplayMessage("Enter the new Title: ");
				string newTitle = view.GetInput();
				if (newTitle.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(newTitle))
				{
					view.DisplayMessage("Title cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue;
				}

				view.DisplayMessage("Enter the new Method: ");
				string method = view.GetInput();
				if (method.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(method))
				{
					view.DisplayMessage("Method cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue;
				}

				view.DisplayMessage("Enter the new Category:");
				string categoryName = view.GetInput();
				if (categoryName.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(categoryName))
				{
					view.DisplayMessage("Category cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue;
				}

				view.DisplayMessage("Enter the New Region:");
				string regionName = view.GetInput();
				if (regionName.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(regionName))
				{
					view.DisplayMessage("Region cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue;
				}

				int regionID = storageManager.GetRegionIDByName(regionName);
				int categoryID = storageManager.GetCategoryIDByName(categoryName);
				Recipe recipe1 = new Recipe(recipeID, newTitle, method, categoryID, userID, regionID);
				int generatedID = storageManager.InsertRecipe(recipe1);
				view.DisplayMessage($"New recipe inserted with id: {generatedID}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
				break; // Exit after successful update
			}
			Console.Clear();
		}
		private static void DeleteRecipe()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Delete Recipe----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter the Recipe Name to delete: ");
				string recipeName = view.GetInput();
				if (recipeName.ToUpper() == "ESC")
					break;

				int rowsAffected = storageManager.DeleteRecipe(recipeName);
				view.DisplayMessage($"Rows Affected: {rowsAffected}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
				break; // Exit after successful attempt
			}
			Console.Clear();
		}
		//CRUD operations for Ingredient
		private static void UpdateIngredient()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Update Ingredient----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter the Ingredient to update: ");
				string temp = view.GetInput();
				if (temp.ToUpper() == "ESC")
					break;

				string ingredientName = ValidateIngredient(temp);
				int ingredientID = storageManager.GetIngredientIDByName(ingredientName);

				view.DisplayMessage("Enter the new Ingredient Name: ");
				string newIngredient = view.GetInput();
				if (newIngredient.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(newIngredient))
				{
					view.DisplayMessage("Ingredient name cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue; // Allow user to retry
				}

				int rowsAffected = storageManager.UpdateIngredient(ingredientID, newIngredient);
				view.DisplayMessage($"rows Affected: {rowsAffected}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
				break; // Exit after successful update
			}
			Console.Clear();
		}
		private static void InsertIngredient()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Insert Ingredient----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter new Ingredient Name: ");
				string ingredientName = view.GetInput();
				if (ingredientName.ToUpper() == "ESC")
					break;

				if (string.IsNullOrEmpty(ingredientName))
				{
					view.DisplayMessage("Ingredient name cannot be empty. Please try again.");
					System.Threading.Thread.Sleep(1000);
					continue; // Allow user to retry
				}

				int ingredientID = 0;
				Ingredient ingredient1 = new Ingredient(ingredientID, ingredientName);
				int generatedID = storageManager.InsertIngredient(ingredient1);
				view.DisplayMessage($"New ingredient inserted with id: {generatedID}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
				break; // Exit after successful insertion
			}
			Console.Clear();
		}
		private static void DeleteIngredient()
		{
			while (true)
			{
				Console.Clear();
				view.DisplayMessage("----Delete Ingredient----\n");
				view.DisplayMessage("Type 'ESC' at any time to exit\n");

				view.DisplayMessage("Enter the Ingredient Name to delete: ");
				string ingredientName = view.GetInput();
				if (ingredientName.ToUpper() == "ESC")
					break;

				int rowsAffected = storageManager.DeleteIngredient(ingredientName);
				view.DisplayMessage($"Rows Affected: {rowsAffected}");

				view.DisplayMessage("\nPress any key to continue...");
				Console.ReadKey(true);
				break; // Exit after one attempt
			}
			Console.Clear();
		}
		// Validation methods for all tables
		private static string ValidateCountry(string input)
		{
			while (input != storageManager.ValidCountry(input))
			{
				view.DisplayMessage("Input is not a country in database, please try again: ");
				input = view.GetInput();
			}
			return input;
		}
		private static string ValidateRole(string input)
		{
			while (input != storageManager.ValidRole(input))
			{
				view.DisplayMessage("Input is not a role in database, please try again: ");
				input = view.GetInput();
			}
			return input;
		}
		private static string ValidateRegion(string input)
		{
			while (input != storageManager.ValidRegion(input))
			{
				view.DisplayMessage("Input is not a region in database, please try again: ");
				input = view.GetInput();
			}
			return input;
		}
		private static string ValidateCity(string input)
		{
			while (input != storageManager.ValidCity(input))
			{
				view.DisplayMessage("Input is not a city in database, please try again: ");
				input = view.GetInput();
			}
			return input;
		}
		private static string ValidateSuburb(string input)
		{
			while (input != storageManager.ValidSuburb(input))
			{
				view.DisplayMessage("Input is not a suburb in database, please try again: ");
				input = view.GetInput();
			}
			return input;
		}
		private static int ValidateZipcode(string input)
		{
			while (true)
			{
				if (input.IsNullOrEmpty())
				{
					Console.WriteLine("Zipcode cannot be null or empty.");
					continue;
				}

				if (input.Length != 4)
				{
					Console.WriteLine("Zipcode must be exactly 4 digits.");
					continue;
				}

				if (!input.All(char.IsDigit))
				{
					Console.WriteLine("Zipcode must contain only digits.");
					continue;
				}

				// Valid zipcode, return as int
				return int.Parse(input);
			}
		}
		private static string ValidateStore(string input)
		{
			while (input != storageManager.ValidStore(input))
			{
				view.DisplayMessage("Input is not a store in database, please try again: ");
				input = view.GetInput();
			}
			return input;
		}
		private static string ValidateUsername(string input)
		{
			while (input != storageManager.ValidUsername(input))
			{
				view.DisplayMessage("Input is not a username in database, please try again: ");
				input = view.GetInput();
			}
			return input;
		}
		private static string ValidateCategory(string input)
		{
			while (input != storageManager.ValidCategory(input))
			{
				view.DisplayMessage("Input is not a category in database, please try again: ");
				input = view.GetInput();
			}
			return input;
		}
		private static string ValidateRecipe(string input)
		{
			while (input != storageManager.ValidRecipe(input))
			{
				view.DisplayMessage("Input is not a recipe in database, please try again: ");
				input = view.GetInput();
			}
			return input;
		}
		private static string ValidateIngredient(string input)
		{
			while (input != storageManager.ValidIngredient(input))
			{
				view.DisplayMessage("Input is not an ingredient in database, please try again: ");
				input = view.GetInput();
			}
			return input;
		}
		private static string Register()
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
				return null;
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
					return null;
				}
				User newUser = new User(userID, firstName, lastName, username, email, roleID, password);
				int generatedID = storageManager.InsertUser(newUser);
				view.DisplayMessage($"Registration successful! New user inserted with id: {generatedID}");
				return roleName;
			}

		}
		private static string Login()
		{
			// Login logic here

			// Clear the console and display the login prompt
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
					Console.Clear();
					view.DisplayMessage("Login successful!\n");
					return storageManager.CheckUserRole(username);
				}
				else
				{
					Console.Clear();
					view.DisplayMessage("Invalid password. Please try again, press any key to continue.");
					Console.ReadKey();
					Console.Clear(); // Invalid password
				}
			}
			else
			{
				Console.Clear();
				view.DisplayMessage("Username not found. Please register first, Press any key to continue.");
				Console.ReadKey();
				Console.Clear();
			}
			return null;
		}
		private static void AdminMenu()
		{
			while (true)
			{

				string adminMenu = view.DisplayAdminMenu();
				switch (adminMenu)
				{
					case "1":
						Console.Clear();
						CountryMenu();
						break;
					case "2":
						Console.Clear();
						RoleMenu();
						break;
					case "3":
						Console.Clear();
						RegionMenu();
						break;
					case "4":
						Console.Clear();
						CityMenu();
						break;
					case "5":
						Console.Clear();
						SuburbMenu();
						break;
					case "6":
						Console.Clear();
						StoreMenu();
						break;
					case "7":
						Console.Clear();
						EditUserMenu();
						break;
					case "8":
						Console.Clear();
						CategoryMenu();
						break;
					case "9":
						Console.Clear();
						RecipeMenu();
						break;
					case "10":
						Console.Clear();
						IngredientMenu();
						break;
					case "11":
						Console.Clear();
						ReportMenu();
						break;
					case "0":
						Console.Clear();
						return;
					default:
						Console.Clear();
						view.DisplayMessage("Invalid option. Please try again.");
						break;
				}
			}
		}
		private static void ChefMenu()
		{
			while (true)
			{
				string chefMenu = view.DisplayChefMenu();
				switch (chefMenu)
				{
					case "1":
						Console.Clear();
						RecipeMenu();
						break;
					case "2":
						Console.Clear();
						IngredientMenu();
						break;
					case "3":
						Console.Clear();
						ReportMenu();
						break;
					case "4":
						Console.Clear();
						return;
					default:
						Console.Clear();
						view.DisplayMessage("Invalid option. Please try again.");
						break;
				}
			}
		}
		private static void UserMenu()
		{
			while (true)
			{
				string userMenu = view.DisplayUserMenu();
				switch (userMenu)
				{
					case "1":
						Console.Clear();
						ReportMenu();
						break;
					case "2":
						Console.Clear();
						return;
					default:
						Console.Clear();
						view.DisplayMessage("Invalid option. Please try again.");
						break;
				}
			}
		}
		private static void Exit()
		{
			view.DisplayMessage("Exiting the application. Goodbye!");
			Environment.Exit(0);
		}
		private static void CountryMenu()
		{
			while (true) 
			{
				string countryMenu = view.EditCountryMenu();
				switch (countryMenu)
				{
					case "1":
						Console.Clear();
						InsertCountry();
						break;
					case "2":
						Console.Clear();
						UpdateCountry();
						break;
					case "3":
						Console.Clear();
						DeleteCountry();
						break;
					case "4":
						Console.Clear();
						view.DisplayCountries(storageManager.GetAllCountries());
						break;
					case "0":
						Console.Clear();
						return;
					default:
						Console.Clear();
						view.DisplayMessage("Invalid option. Please try again.");
						break;
				}
			}
		}
		private static void RoleMenu()
		{
			while (true)
			{
				string roleMenu = view.EditRoleMenu();
				switch (roleMenu)
				{
					case "1":
						Console.Clear();
						InsertRole();
						break;
					case "2":
						Console.Clear();
						UpdateRole();
						break;
					case "3":
						Console.Clear();
						DeleteRole();
						break;
					case "4":
						Console.Clear();
						view.DisplayRoles(storageManager.GetAllRoles());
						break;
					case "0":
						Console.Clear();
						return;
					default:
						Console.Clear();
						view.DisplayMessage("Invalid option. Please try again.");
						break;
				}
			}
		}
		private static void RegionMenu()
		{
			while (true)
			{
				string regionMenu = view.EditRegionMenu();
				switch (regionMenu)
				{
					case "1":
						Console.Clear();
						InsertRegion();
						break;
					case "2":
						Console.Clear();
						UpdateRegion();
						break;
					case "3":
						Console.Clear();
						DeleteRegion();
						break;
					case "4":
						Console.Clear();
						view.DisplayRegions(storageManager.GetAllRegions());
						break;
					case "0":
						Console.Clear();
						return;
					default:
						Console.Clear();
						view.DisplayMessage("Invalid option. Please try again.");
						break;
				}
			}
		}
		private static void CityMenu()
		{
			while ( true)
			{
				string cityMenu = view.EditCityMenu();
				switch (cityMenu)
				{
					case "1":
						Console.Clear();
						InsertCity();
						break;
					case "2":
						Console.Clear();
						UpdateCity();
						break;
					case "3":
						Console.Clear();
						DeleteCity();
						break;
					case "4":
						Console.Clear();
						view.DisplayCities(storageManager.GetAllCities());
						break;
					case "0":
						Console.Clear();
						return;
					default:
						Console.Clear();
						view.DisplayMessage("Invalid option. Please try again.");
						break;
				}
			}
		}
		private static void SuburbMenu()
		{
			while (true)
			{
				string suburbMenu = view.EditSuburbMenu();
				switch (suburbMenu)
				{
					case "1":
						Console.Clear();
						InsertSuburb();
						break;
					case "2":
						Console.Clear();
						UpdateSuburb();
						break;
					case "3":
						Console.Clear();
						DeleteSuburb();
						break;
					case "4":
						Console.Clear();
						view.DisplaySuburbs(storageManager.GetAllSuburbs());
						break;
					case "0":
						Console.Clear();
						return;
					default:
						Console.Clear();
						view.DisplayMessage("Invalid option. Please try again.");
						break;
				}
			}
		}
		private static void StoreMenu()
		{
			while (true)
			{
				// Display the store menu and get the user's choice
				string storeMenu = view.EditStoreMenu();
				switch (storeMenu)
				{
					case "1":
						Console.Clear();
						InsertStore();
						break;
					case "2":
						Console.Clear();
						UpdateStore();
						break;
					case "3":
						Console.Clear();
						DeleteStore();
						break;
					case "4":
						Console.Clear();
						view.DisplayStores(storageManager.GetAllStores());
						break;
					case "0":
						Console.Clear();
						return;
					default:
						Console.Clear();
						view.DisplayMessage("Invalid option. Please try again.");
						break;
				}
			}
		}
		private static void EditUserMenu()
		{
			while (true)
			{
				string userMenu = view.EditUserMenu();
				switch (userMenu)
				{
					case "1":
						Console.Clear();
						InsertUser();
						break;
					case "2":
						Console.Clear();
						UpdateUser();
						break;
					case "3":
						Console.Clear();
						DeleteUser();
						break;
					case "4":
						Console.Clear();
						view.DisplayUsers(storageManager.GetAllUsers());
						break;
					case "0":
						Console.Clear();
						return;
					default:
						Console.Clear();
						view.DisplayMessage("Invalid option. Please try again.");
						break;
				}
			}
		}
		private static void CategoryMenu()
		{
			while (true)
			{
				// Display the category menu and get the user's choice
				string categoryMenu = view.EditCategoryMenu();
				switch (categoryMenu)
				{
					case "1":
						Console.Clear();
						InsertCategory();
						break;
					case "2":
						Console.Clear();
						UpdateCategory();
						break;
					case "3":
						Console.Clear();
						DeleteCategory();
						break;
					case "4":
						Console.Clear();
						view.DisplayCategories(storageManager.GetAllCategories());
						break;
					case "0":
						Console.Clear();
						return;
					default:
						Console.Clear();
						view.DisplayMessage("Invalid option. Please try again.");
						break;
				}
			}
		}
		private static void RecipeMenu()
		{
			while (true)
			{
				string recipeMenu = view.EditRecipeMenu();
				switch (recipeMenu)
				{
					case "1":
						Console.Clear();
						InsertRecipe();
						break;
					case "2":
						Console.Clear();
						UpdateRecipe();
						break;
					case "3":
						Console.Clear();
						DeleteRecipe();
						break;
					case "4":
						Console.Clear();
						view.DisplayRecipes(storageManager.GetAllRecipes());
						break;
					case "0":
						Console.Clear();
						return;
					default:
						Console.Clear();
						view.DisplayMessage("Invalid option. Please try again.");
						break;
				}
			}
		}
		private static void IngredientMenu()
		{
			while (true)
			{
				string ingredientMenu = view.EditIngredientMenu();
				switch (ingredientMenu)
				{
					case "1":
						Console.Clear();
						InsertIngredient();
						break;
					case "2":
						Console.Clear();
						UpdateIngredient();
						break;
					case "3":
						Console.Clear();
						DeleteIngredient();
						break;
					case "4":
						Console.Clear();
						view.DisplayIngredients(storageManager.GetAllIngredients());
						break;
					case "0":
						Console.Clear();
						return;
					default:
						Console.Clear();
						view.DisplayMessage("Invalid option. Please try again.");
						break;
				}
			}
		}
		private static void ReportMenu()
		{
			while (true)
			{
				string viewReports = view.viewReportsMenu();
				switch (viewReports)
				{
					case "1":
						Console.Clear();
						view.UserReport(storageManager.GetAllUsers());
						break;
					case "2":
						Console.Clear();
						view.CityReport(storageManager.CityReport());
						break;
					case "3":
						Console.Clear();
						view.CountryReport(storageManager.CountryReport());
						break;
					case "4":
						Console.Clear();
						view.RecipeReport(storageManager.GetAllRecipes());
						break;
					case "5":
						Console.Clear();
						view.SuburbReport(storageManager.SuburbReport());
						break;
					case "6":
						Console.Clear();
						view.IngredientsInRecipe(storageManager.IngredientsInRecipe());
						break;
					case "7":
						Console.Clear();
						view.IngredientsPerStore(storageManager.IngredientsPerStore());
						break;
					case "8":
						Console.Clear();
						view.CitiesWithMostStores(storageManager.CitiesWithMostStores());
						break;
					case "9":
						Console.Clear();
						view.NumOfRecipesByRegion(storageManager.NumOfRecipePerRegion());
						break;
					case "10":
						Console.Clear();
						view.MostIngredientsByStore(storageManager.MostIngredientsByStore());
						break;
					case "11":
						Console.Clear();
						view.ChefRecipeRegion(storageManager.ChefRecipeRegion());
						break;
					case "12":
						Console.Clear();
						view.RecipeCategoryIngredients(storageManager.RecipeCategoryIngredients());
						break;
					case "13":
						Console.Clear();
						view.RecipeRegionCountry(storageManager.RecipeRegionCountry());
						break;
					case "14":
						Console.Clear();
						view.RecipesUseGarlic(storageManager.RecipesUseGarlic());
						break;
					case "15":
						Console.Clear();
						view.StoreContainChicken(storageManager.StoreContainChicken());
						break;
					case "0":
					Console.Clear();
					return;
				default:
					Console.Clear();
					view.DisplayMessage("Invalid option. Please try again.");
					break;
				}
			}
		}
	}
}



