using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
	public class AdvancedQry1
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Title { get; set; }
		public string Area { get; set; }

		public AdvancedQry1(string firstName, string lastName, string title, string area)
		{
			FirstName = firstName;
			LastName = lastName;
			Title = title;
			Area = area;
		}
	}
}
