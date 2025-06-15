using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    internal class Category
    {
		public int CategoryID { get; set; }
		public string Category { get; set; }

		public Category(int categoryID, string category)
		{
			CategoryID = categoryID;
			Category = category;
		}
	}
}
