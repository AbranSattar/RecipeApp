using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    internal class Ingredient
    {
		public int IngredientID { get; set; }
		public string Ingredient { get; set; }

		public Ingredient(int ingredientID, string ingredient)
		{
			IngredientID = ingredientID;
			Ingredient = ingredient;
		}
	}
}
