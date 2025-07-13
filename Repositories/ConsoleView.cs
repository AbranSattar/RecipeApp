using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using RecipeApp.Models;

namespace RecipeApp.Repositories
{
    internal class ConsoleView
    {
		// Menus
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
			Console.WriteLine("0. Return");
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
		public string viewReportsMenu()	
		{
			Console.WriteLine("==== ALL REPORTS ====\n");
			Console.WriteLine("1. user report");
			Console.WriteLine("2. city report");
			Console.WriteLine("3. country report");
			Console.WriteLine("4. recipe report");
			Console.WriteLine("5. suburb report");
			Console.WriteLine("6. ingredients in recipe report");
			Console.WriteLine("7. ingredients per store report");
			Console.WriteLine("8. cities with most stores report");
			Console.WriteLine("9. most ingredients by store report");
			Console.WriteLine("10. number of recipes by region report");
			Console.WriteLine("11. chef recipe region report");
			Console.WriteLine("12. recipe category ingredients report");
			Console.WriteLine("13. recipe region country report");
			Console.WriteLine("14. recipes that use garlic report");
			Console.WriteLine("15. stores that contain chicken report");
			Console.WriteLine("0. Exit");
			return Console.ReadLine();
		}
		//simple query reports
		public void UserReport(List<User> users)
		{
			Console.WriteLine("User Report:\n");
			foreach (User user in users)
			{
				Console.WriteLine($"ID: {user.userID}, Name: {user.FirstName} {user.LastName}, Username: {user.UserName}, Email: {user.Email}, Role ID: {user.roleID}");
			}
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
		}
		public void CityReport(List<City> cities)
		{
			Console.WriteLine("City Report:\n");
			foreach (City city in cities)
			{
				Console.WriteLine($"ID: {city.cityID}, City Name: {city.city}");
			}
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
		}
		public void CountryReport(List<Country> countries)
		{
			Console.WriteLine("Country Report:\n");
			foreach (Country country in countries)
			{
				Console.WriteLine($"ID: {country.countryID}, Country Name: {country.countryName}");
			}
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
		}
		public void RecipeReport(List<Recipe> recipes)
		{
			Console.WriteLine("Recipe Report:\n");
			foreach (Recipe recipe in recipes)
			{
				Console.WriteLine($"ID: {recipe.RecipeID}, Title: {recipe.Title}");
			}
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
		}
		public void SuburbReport(List<Suburb> suburbs)
		{
			Console.WriteLine("Suburb Report:\n");
			foreach (Suburb suburb in suburbs)
			{
				Console.WriteLine($"suburb: {suburb.suburb}, city: {suburb.cityID}, zip: {suburb.Zipcode}");
			}
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
		}
		//complex query reports
		public void IngredientsInRecipe(List<ComplexQry1> complexQry1s)
		{
			Console.WriteLine("Ingredients in Recipe Report:\n");
			foreach (ComplexQry1 complexQry1 in complexQry1s)
			{
				Console.WriteLine($"Title: {complexQry1.Title}, Method: {complexQry1.Method}, Ingredients: {complexQry1.Ingredients}");
			}
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
		}
		public void IngredientsPerStore(List<ComplexQry2> complexQry2s)
		{
			Console.WriteLine("Ingredients per Store Report:\n");
			foreach (ComplexQry2 complexQry2 in complexQry2s)
			{
				Console.WriteLine($"StoreID: {complexQry2.StoreID}, Store: {complexQry2.Store}, NumberOfIngredients: {complexQry2.IngredientID}");
			}
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
		}
		public void CitiesWithMostStores(List<ComplexQry3> complexQry3s)
		{
			Console.WriteLine("Cities with Most Stores Report:\n");
			foreach (ComplexQry3 complexQry3 in complexQry3s)
			{
				Console.WriteLine($"City: {complexQry3.City}, NumberOfStores: {complexQry3.Store}");
			}
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
		}
		public void MostIngredientsByStore(List<ComplexQry4> complexQry4s)
		{
			Console.WriteLine("Most Ingredients by Store Report:\n");
			foreach (ComplexQry4 complexQry4 in complexQry4s)
			{
				Console.WriteLine($"City: {complexQry4.City}, Suburb: {complexQry4.Suburb},Store: {complexQry4.Store}, NumberOfIngredients: {complexQry4.Ingredient}");
			}
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
		}
		public void NumOfRecipesByRegion(List<ComplexQry5> complexQry5s)
		{
			Console.WriteLine("Number of Recipes by Region Report:\n");
			foreach (ComplexQry5 complexQry5 in complexQry5s)
			{
				Console.WriteLine($"Region: {complexQry5.Area}, NumberOfRecipes: {complexQry5.RecipeID}, TotalUniqueIngredients: {complexQry5.IngredientID}");
			}
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
		}
		//Advanced query reports
		public void ChefRecipeRegion(List<AdvancedQry1> advancedQry1s)
		{
			Console.WriteLine("Chef Recipe Region Report:\n");
			foreach (AdvancedQry1 advancedQry1 in advancedQry1s)
			{
				Console.WriteLine($"User: {advancedQry1.FirstName} {advancedQry1.LastName}, Recipe: {advancedQry1.Title}, Region: {advancedQry1.Area}");
			}
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
		}
		public void RecipeCategoryIngredients(List<AdvancedQry2> advancedQry2s)
		{
			Console.WriteLine("Recipe Category Ingredients Report:\n");
			foreach (AdvancedQry2 advancedQry2 in advancedQry2s)
			{
				Console.WriteLine($"Recipe: {advancedQry2.Title}, Category: {advancedQry2.Category}, Ingredients: {advancedQry2.Ingredients}");
			}
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
		}
		public void RecipeRegionCountry(List<AdvancedQry3> advancedQry3s)
		{
			Console.WriteLine("Recipe Region Country report\n");
			foreach (AdvancedQry3 advancedQry3 in advancedQry3s)
			{
				Console.WriteLine($"Region: {advancedQry3.Region}, Title: {advancedQry3.Title}, Country: {advancedQry3.Country}");
			}
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
		}
		public void RecipesUseGarlic(List<AdvancedQry4> advancedQry4s)
		{
			Console.WriteLine("Recipes that use garlic report\n");
			foreach (AdvancedQry4 advancedQry4 in advancedQry4s)
			{
				Console.WriteLine($"Title: {advancedQry4.Title}, Method: {advancedQry4.Method}, Ingredients: {advancedQry4.Ingredient}");
			}
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
		}
		public void StoreContainChicken(List<AdvancedQry5> advancedQry5s)
		{
			Console.WriteLine("Stores that contain chicken report\n");
			foreach (AdvancedQry5 advancedQry5 in advancedQry5s)
			{
				Console.WriteLine($"Store: {advancedQry5.StoreName}, Ingredient: {advancedQry5.IngredientName}");
			}
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
		}
		//display methods for each table
		public void DisplayCountries(List<Country> countries)
        {

            foreach (Country country in countries)
            {
                Console.WriteLine($"{country.countryID}, {country.countryName}");
            }
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
        }
		public void DisplayRoles(List<Role> roles)
		{
			foreach (Role role in roles)
			{
				Console.WriteLine($"{role.roleID}, {role.role}");
			}
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
		}
		public void DisplayRegions(List<Region> regions)
		{
			foreach (Region region in regions)
			{
				Console.WriteLine($"{region.regionID}, {region.Area},");
			}
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
		}
		public void DisplayCities(List<City> cities)
		{
			foreach (City city in cities)
			{
				Console.WriteLine($"{city.cityID}, {city.city}");
			}
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
		}
		public void DisplaySuburbs(List<Suburb> suburbs)
		{
			foreach (Suburb suburb in suburbs)
			{
				Console.WriteLine($"{suburb.suburbID}, {suburb.suburb}");
			}
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
		}
		public void DisplayStores(List<Store> stores)
		{
			foreach (Store store in stores)
			{
				Console.WriteLine($"{store.storeID}, {store.store}");
			}
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
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
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
		}
		public void DisplayRecipes(List<Recipe> recipes)
		{
			foreach (Recipe recipe in recipes)
			{
				Console.WriteLine($"{recipe.RecipeID}, {recipe.Title}");
			}
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
		}
		public void DisplayIngredients(List<Ingredient> ingredients)
		{
			foreach (Ingredient ingredient in ingredients)
			{
				Console.WriteLine($"{ingredient.IngredientID}, {ingredient.IngredientName}");
			}
			Console.WriteLine("Press any key to return");
			Console.ReadKey();
			Console.Clear();
			return;
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
