using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class Country
    {
        public int countryID { get; set; }
        public string countryName { get; set; }

        public Country(int cID, string c)
        {
            countryID = cID;
            countryName = c;
        }
    }
}
