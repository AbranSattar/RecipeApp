using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
	public class AdvancedQry4
	{
		public string Title { get; set; }
		public string Method { get; set; }
		public string Ingredient { get; set; }

		public AdvancedQry4(string title, string method, string ingredient)
		{
			Title = title;
			Method = method;
			Ingredient = ingredient;
		}
	}
}
