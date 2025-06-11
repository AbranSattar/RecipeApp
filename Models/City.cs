using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class City
    {
        public int cityID { get; set; }
        public string city { get; set; }

        public City(int ciID, string c)
        {
            cityID = ciID;
            city = c;
        }
    }
}
