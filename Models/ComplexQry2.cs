using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
	public class ComplexQry2
	{
		public int StoreID { get; set; }
		public string Store { get; set; }
		public int IngredientID { get; set; }

		public ComplexQry2(int storeID, string store, int ingredientID)
		{
			StoreID = storeID;
			Store = store;
			IngredientID = ingredientID;
		}
	}
}
