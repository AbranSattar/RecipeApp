using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class Store
    {
        public int storeID { get; set; }
        public int suburbID { get; set; }
        public string store { get; set; }

        public Store(int stID, int suID, string st)
        {
            storeID = stID;
            suburbID = suID;
            store = st;
        }
    }
}
