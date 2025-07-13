using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
	public class ComplexQry4
	{
		public string Store { get; set; }
		public string Ingredient { get; set; }
		public string Suburb { get; set; }
		public string City { get; set; }
		public ComplexQry4(string store, string ingredient, string suburb, string city)
		{
			Store = store;
			Ingredient = ingredient;
			Suburb = suburb;
			City = city;
		}
	}
}
