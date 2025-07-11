using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeApp.Models;

namespace RecipeApp.Repositories
{
    internal class ConsoleView
    {
        public string DisplayMenu()
        {
            Console.WriteLine("--- RECIPE DATABASE ---\n");
            Console.WriteLine("MENU:\n");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
			Console.WriteLine("3. Exit");

			return Console.ReadLine();
        }
		public string DisplayAdminMenu()
		{
			Console.WriteLine("====ADMIN MENU====\n");
			Console.WriteLine("1. Edit Country");
			Console.WriteLine("2. Edit Role");
			Console.WriteLine("3. Edit Region");
			Console.WriteLine("4. Edit City");
			Console.WriteLine("5. Edit Suburb");
			Console.WriteLine("6. Edit Store");
			Console.WriteLine("7. Edit User");
			Console.WriteLine("8. Edit Categories");
			Console.WriteLine("9. Edit Recipes");
			Console.WriteLine("10. Edit Ingredients");
			Console.WriteLine("11. view all Reports");
			Console.WriteLine("0. Exit");
			return Console.ReadLine();
		}
		public string DisplayChefMenu()
		{
			Console.WriteLine("====CHEF MENU====\n");
			Console.WriteLine("1. Edit Recipes");
			Console.WriteLine("2. Edit Ingredients");
			Console.WriteLine("3. View Reports");
			Console.WriteLine("4. Exit");
			return Console.ReadLine();
		}
		public string DisplayUserMenu()
		{
			Console.WriteLine("====USER MENU====\n");
			Console.WriteLine("1. view Reports");
			Console.WriteLine("2. Exit");
			return Console.ReadLine();
		}
		public string EditCountryMenu()
		{
			Console.WriteLine("====EDIT COUNTRY====");
			Console.WriteLine("1. Add Country");
			Console.WriteLine("2. Update Country");
			Console.WriteLine("3. Delete Country");
			Console.WriteLine("4. View Countries");
			Console.WriteLine("0. Exit");
			return Console.ReadLine();
		}
		public string EditRoleMenu()
		{
			Console.WriteLine("====EDIT ROLE====");
			Console.WriteLine("1. Add Role");
			Console.WriteLine("2. Update Role");
			Console.WriteLine("3. Delete Role");
			Console.WriteLine("4. View Roles");
			Console.WriteLine("0. Exit");
			return Console.ReadLine();
		}
		public string EditRegionMenu()
		{
			Console.WriteLine("====EDIT REGION====");
			Console.WriteLine("1. Add Region");
			Console.WriteLine("2. Update Region");
			Console.WriteLine("3. Delete Region");
			Console.WriteLine("4. View Regions");
			Console.WriteLine("0. Exit");
			return Console.ReadLine();
		}
		public string EditCityMenu()
		{
			Console.WriteLine("====EDIT CITY====");
			Console.WriteLine("1. Add City");
			Console.WriteLine("2. Update City");
			Console.WriteLine("3. Delete City");
			Console.WriteLine("4. View Cities");
			Console.WriteLine("0. Exit");
			return Console.ReadLine();
		}
		public string EditSuburbMenu()
		{
			Console.WriteLine("====EDIT SUBURB====");
			Console.WriteLine("1. Add Suburb");
			Console.WriteLine("2. Update Suburb");
			Console.WriteLine("3. Delete Suburb");
			Console.WriteLine("4. View Suburbs");
			Console.WriteLine("0. Exit");
			return Console.ReadLine();
		}
		public string EditStoreMenu()
		{
			Console.WriteLine("====EDIT STORE====");
			Console.WriteLine("1. Add Store");
			Console.WriteLine("2. Update Store");
			Console.WriteLine("3. Delete Store");
			Console.WriteLine("4. View Stores");
			Console.WriteLine("0. Exit");
			return Console.ReadLine();
		}
		public string EditUserMenu()
		{
			Console.WriteLine("====EDIT USER====");
			Console.WriteLine("1. Add User");
			Console.WriteLine("2. Update User");
			Console.WriteLine("3. Delete User");
			Console.WriteLine("4. View Users");
			Console.WriteLine("0. Exit");
			return Console.ReadLine();
		}
		public string EditCategoryMenu()
		{
			Console.WriteLine("====EDIT CATEGORY====");
			Console.WriteLine("1. Add Category");
			Console.WriteLine("2. Update Category");
			Console.WriteLine("3. Delete Category");
			Console.WriteLine("4. View Categories");
			Console.WriteLine("0. Exit");
			return Console.ReadLine();
		}
		public string EditRecipeMenu()
		{
			Console.WriteLine("====EDIT RECIPE====");
			Console.WriteLine("1. Add Recipe");
			Console.WriteLine("2. Update Recipe");
			Console.WriteLine("3. Delete Recipe");
			Console.WriteLine("4. View Recipes");
			Console.WriteLine("0. Exit");
			return Console.ReadLine();
		}
		public string EditIngredientMenu()
		{
			Console.WriteLine("====EDIT INGREDIENT====");
			Console.WriteLine("1. Add Ingredient");
			Console.WriteLine("2. Update Ingredient");
			Console.WriteLine("3. Delete Ingredient");
			Console.WriteLine("4. View Ingredients");
			Console.WriteLine("0. Exit");
			return Console.ReadLine();
		}
		public void DisplayCountries(List<Country> countries, string message = "")
		{
			if (!string.IsNullOrEmpty(message))
			{
				Console.WriteLine(message);
			}
			Console.WriteLine("--- COUNTRIES ---");
			Console.WriteLine("countryID, countryName");
			foreach (Country country in countries)
			{
				Console.WriteLine($"{country.countryID}, {country.countryName}");
			}
		}
		public void DisplayCountries(List<Country> countries)
        {

            foreach (Country country in countries)
            {
                Console.WriteLine($"{country.countryID}, {country.countryName}");
            }
        }
		public void DisplayRoles(List<Role> roles)
		{
			foreach (Role role in roles)
			{
				Console.WriteLine($"{role.roleID}, {role.role}");
			}
		}
		public void DisplayRegions(List<Region> regions)
		{
			foreach (Region region in regions)
			{
				Console.WriteLine($"{region.regionID}, {region.Area},");
			}
		}
		public void DisplayCities(List<City> cities)
		{
			foreach (City city in cities)
			{
				Console.WriteLine($"{city.cityID}, {city.city}");
			}
		}
		public void DisplaySuburbs(List<Suburb> suburbs)
		{
			foreach (Suburb suburb in suburbs)
			{
				Console.WriteLine($"{suburb.suburbID}, {suburb.suburb}");
			}
		}
		public void DisplayStores(List<Store> stores)
		{
			foreach (Store store in stores)
			{
				Console.WriteLine($"{store.storeID}, {store.store}");
			}
		}
		public void DisplayUsers(List<User> users)
		{
			foreach (User user in users)
			{
				Console.WriteLine($"{user.userID}, {user.UserName}");
			}
		}
		public void DisplayCategories(List<Category> categories)
		{
			foreach (Category category in categories)
			{
				Console.WriteLine($"{category.CategoryID}, {category.CategoryName}");
			}
		}
		public void DisplayRecipes(List<Recipe> recipes)
		{
			foreach (Recipe recipe in recipes)
			{
				Console.WriteLine($"{recipe.RecipeID}, {recipe.Title}");
			}
		}
		public void DisplayIngredients(List<Ingredient> ingredients)
		{
			foreach (Ingredient ingredient in ingredients)
			{
				Console.WriteLine($"{ingredient.IngredientID}, {ingredient.IngredientName}");
			}
		}
		public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
        public string GetInput()
        {
            return Console.ReadLine();
        }
        public int GetIntInput()
        {
            return int.Parse(Console.ReadLine());
        }
    }
}
