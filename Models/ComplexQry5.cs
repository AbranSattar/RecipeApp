using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
	public class ComplexQry5
	{
		public string Area { get; set; }
		public int RecipeID { get; set; }
		public int IngredientID { get; set; }

		public ComplexQry5(string area, int recipeID, int ingredientID)
		{
			Area = area;
			RecipeID = recipeID;
			IngredientID = ingredientID;
		}
	}
}
