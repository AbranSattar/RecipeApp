using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    internal class Recipe
    {

		public int RecipeID { get; set; }
		public string Title { get; set; }
		public string Method { get; set; }
		public int CategoryID { get; set; }
		public int ChefID { get; set; }
		public int RegionID { get; set; }

		public Recipe(int recipeID, string title, string method, int categoryID, int chefID, int regionID)
		{
			RecipeID = recipeID;
			Title = title;
			Method = method;
			CategoryID = categoryID;
			ChefID = chefID;
			RegionID = regionID;
		}
	}
}
