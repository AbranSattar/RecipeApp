using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
	public class AdvancedQry5
	{
		public string StoreName { get; set; }
		public string IngredientName { get; set; }

		public AdvancedQry5(string storeName, string ingredientName)
		{
			StoreName = storeName;
			IngredientName = ingredientName;
		}
	}
}
