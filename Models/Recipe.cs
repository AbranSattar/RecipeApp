using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class Recipe
    {

		public int RecipeID { get; set; }
		public string Title { get; set; }
		public string Method { get; set; }
		public int CategoryID { get; set; }
		public int UserID { get; set; }
		public int RegionID { get; set; }

		public Recipe(int recipeID, string title, string method, int categoryID, int userID, int regionID)
		{
			RecipeID = recipeID;
			Title = title;
			Method = method;
			CategoryID = categoryID;
			UserID = userID;
			RegionID = regionID;
		}
	}
}
