using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
	public class ComplexQry3
	{
		public string City { get; set; }
		public string Store { get; set; }

		public ComplexQry3(string city, string store)
		{
			City = city;
			Store = store;
		}
	}
}
