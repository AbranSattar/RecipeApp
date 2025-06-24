using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class Category
    {
		public int CategoryID { get; set; }
		public string CategoryName { get; set; }

		public Category(int categoryID, string category)
		{
			CategoryID = categoryID;
			CategoryName = category;
		}
	}
}
