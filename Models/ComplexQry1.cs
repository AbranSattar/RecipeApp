using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
	public class ComplexQry1
	{
		public string Title { get; set; }
		public string Method { get; set; }
		public string Ingredients { get; set; }

		public ComplexQry1(string title, string method, string ingredients)
		{
			Title = title;
			Method = method;
			Ingredients = ingredients;
		}
	}
}
