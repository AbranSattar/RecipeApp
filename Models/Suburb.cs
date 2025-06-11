using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class Suburb
    {
        public int suburbID { get; set; }
        public int cityID { get; set; }
        public string suburb { get; set; }
        public int Zipcode { get; set; }

        public Suburb(int sID, int cID, string su, int zip)
        {
            suburbID = sID;
            cityID = cID;
            suburb = su;
            Zipcode = zip;
        }

    }
}
