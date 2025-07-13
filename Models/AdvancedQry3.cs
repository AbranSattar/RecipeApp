using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
	public class AdvancedQry3
	{
		public string Region { get; set; }
		public string Title { get; set; }
		public string Country { get; set; }

		public AdvancedQry3(string region, string title, string country)
		{
			Region = region;
			Title = title;
			Country = country;
		}
	}
}
