using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class Region
    {
        public int regionID { get; set; }
        public int countryID { get; set; }
        public string Area { get; set; }

        public Region(int rgID, int cID, string a)
        {
            regionID = rgID;
            countryID = cID;
            Area = a;
        }
    }
}
