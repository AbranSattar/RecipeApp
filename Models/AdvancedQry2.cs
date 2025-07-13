using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
	public class AdvancedQry2
	{
		public string Title { get; set; }
		public string Category { get; set; }
		public string Ingredients { get; set; }

		public AdvancedQry2(string title, string category, string ingredients)
		{
			Title = title;
			Category = category;
			Ingredients = ingredients;
		}
	}
}
