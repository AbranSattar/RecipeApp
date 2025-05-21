using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Repositories
{
    internal class ConsoleView
    {
        public string DisplayMenu()
        {
            Console.WriteLine("Welcome to my Recipe Database");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. View all records in Countries");
            Console.WriteLine("2. Update a countries name by ID");
            Console.WriteLine("3. insert a new country");
            Console.WriteLine("4. delete a country by name");
            return Console.ReadLine();
        }

        public void DisplayCountries(List<Country> countries)
        {
            foreach (string country in countries)
            {
                Console.WriteLine($"{country.countryID}, {country.countryName}");
            }
        }
    }
}
