using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class Role
    {
        public int roleID { get; set; }
        public string role { get; set; }

        public Role(int rID, string r)
        {
            roleID = rID;
            role = r;
        }
    }
}
