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
            Console.WriteLine("2. Register");
           
            return Console.ReadLine();
        }

        public void DisplayCountries(List<Country> countries)
        {
            foreach (Country country in countries)
            {
                Console.WriteLine($"{country.countryID}, {country.countryName}");
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
