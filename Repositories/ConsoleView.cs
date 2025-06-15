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
            Console.WriteLine("--- RECIPE DATABASE ---");
            Console.WriteLine("MENU:");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
           
            return Console.ReadLine();
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
